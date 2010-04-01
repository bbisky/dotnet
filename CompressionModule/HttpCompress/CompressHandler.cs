///
/// This is based on the article found here: http://rakaz.nl/item/make_your_pages_load_faster_by_combining_and_compressing_javascript_and_css_files
/// which talks about the benefits of combining javascript and css into one file as well as 
/// compressing it. I am including the 'copyright' from the php file which this was ported from
///    /************************************************************************ 
///     * CSS and Javascript Combinator 0.5
///     * Copyright 2006 by Niels Leenheer 
///     * 
///     * Permission is hereby granted, free of charge, to any person obtaining 
///     * a copy of this software and associated documentation files (the 
///     * "Software"), to deal in the Software without restriction, including 
///     * without limitation the rights to use, copy, modify, merge, publish, 
///     * distribute, sublicense, and/or sell copies of the Software, and to 
///     * permit persons to whom the Software is furnished to do so, subject to 
///     * the following conditions: 
///     *  
///     * The above copyright notice and this permission notice shall be 
///     * included in all copies or substantial portions of the Software. 
///     * 
///     * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
///     * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF 
///     * MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
///     * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE 
///     * LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION 
///     * OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION 
///     * WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE. 
///     */ 
/// I echo the copy right for this software
/// 

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Net;
using System.Web.Caching;
using util;

namespace DC.Web.HttpCompress
{
    public class CompressionHandler : IHttpHandler
    {

        #region IHttpHandler Members
        private string encoding, hash;
        private HttpContext context;
        private List<string> fileNames = new List<string>();

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext httpContext)
        {
            context = httpContext;
            // create a string for the cache
            string cache = context.Request.Url.AbsoluteUri; 
            StringBuilder sb = new StringBuilder();
            // check what type of file it is (js or css)
            string path = Path.GetFileNameWithoutExtension(context.Request.Path);

            encoding = "none";
            // get the accepted encoding
            SetEncoding();

            // set the content type
            string contentType = path == "js" || path == "javascript" ? "text/javascript" : (path == "css" ? "text/css" : "");

            // create the hash used for the etag
            hash = GetMd5Sum(cache);

            Uri baseUri = new Uri(context.Request.Url.AbsoluteUri);

            // check if file is in server cache
            if (context.Cache[cache] == null)
            {
                // get the names of the requested files
                string[] tempFiles = context.Request.Url.Query.Replace("?files=", "").Replace("&nostrip=1", "").Split(',');

                foreach (string file in tempFiles)
                {

                    // try getting the file locally, if not local, download the file
                    string temp = GetLocalFile(new Uri(baseUri, file));
                    // some files throw errors when the whitespace is stripped.  If this is the case, just add a query string of nostrip=1
                    if (contentType == "text/javascript" && !file.Contains("nostrip=1"))
                        sb.AppendLine(MyMin.parse(temp));
                    else if (contentType == "text/css" && !file.Contains("nostrip=1"))
                        sb.AppendLine(MyMin.parse(temp, true, true));
                    else
                        sb.AppendLine(temp);

                }

                // if there were local files, put in cache and set dependency to the files.  This will ensure that if files have changed, we get the latest versions
                // otherwise, just cache the files for three days.                
                                    
                if (fileNames.Count > 0)
                    context.Cache.Insert(cache, sb.ToString(), new CacheDependency(fileNames.ToArray()));
                else
                    context.Cache.Insert(cache, sb.ToString(), null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(3, 0, 0, 0));
            }
            //  if it's in the server cache then it might be in the browser cache, if it is, send the not modified header and exit
            else if (IsCachedOnBrowser())
                return;

            // set the headers.  Etag is for caching on browser
            context.Response.ClearHeaders();
            context.Response.AppendHeader("Etag", hash);
            context.Response.Write(context.Cache[cache]);
            context.Response.ContentType = contentType;

            // if compression is accepted compress the output
            if (encoding != "none")
            {
                if (encoding == "gzip")
                    context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
                else
                    context.Response.Filter = new DeflateStream(context.Response.Filter, CompressionMode.Compress);
                context.Response.AppendHeader("Content-encoding", encoding);
            }
        }

        // tries to get the file locally
        private string GetLocalFile(Uri uri)
        {

            string html = "";
            try
            {
                // try to use MapPath to get the file, this throws an error if the file doesn't exist
                string path2 = context.Server.MapPath(uri.AbsolutePath);
                //by sky: only allow js css axd files
                string ext = Path.GetExtension(path2).ToLower();
                if (".js" == ext || ".css" == ext || ".axd" == ext)
                {
                    html = File.ReadAllText(path2);
                    fileNames.Add(path2);
                }
            }
            catch
            {
                // file doesn't exist locally try to get it remotely
                html = GetRemoteFile(uri);
            }
            return html;
        }

        private string GetRemoteFile(Uri uri)
        {
            StringBuilder html = new StringBuilder();
            try
            {
                // set up the request and response objects
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Credentials = CredentialCache.DefaultNetworkCredentials;
                using (HttpWebResponse resp = request.GetResponse() as HttpWebResponse)
                {
                    using (Stream recDataStream = resp.GetResponseStream())
                    {
                        // get and read the response stream
                        byte[] buffer = new byte[1024];
                        int read = 0;

                        do
                        {
                            read = recDataStream.Read(buffer, 0, buffer.Length);
                            // convert the response to text
                            html.Append(UTF8Encoding.UTF8.GetString(buffer, 0, read));
                        }
                        while (read > 0);
                    }
                }
            }
            catch
            {
                // The remote site is currently down. Try again next time.
            }
            return html.ToString();
        }

        private void SetEncoding()
        {
            bool gzip, deflate;

            // get the type of compression to use
            if (!string.IsNullOrEmpty(context.Request.ServerVariables["HTTP_ACCEPT_ENCODING"]))
            {
                // get supported compression methods
                string acceptedTypes = context.Request.ServerVariables["HTTP_ACCEPT_ENCODING"].ToLower();
                gzip = acceptedTypes.Contains("gzip") || acceptedTypes.Contains("x-gzip") || acceptedTypes.Contains("*");
                deflate = acceptedTypes.Contains("deflate");
            }
            else
                gzip = deflate = false;

            //determin which to use
            encoding = gzip ? "gzip" : (deflate ? "deflate" : "none");

            // check for buggy versions of Internet Explorer
            if (context.Request.Browser.Browser == "IE")
            {
                if (context.Request.Browser.MajorVersion < 6)
                    encoding = "none";
                else if (context.Request.Browser.MajorVersion == 6 &&
                    !string.IsNullOrEmpty(context.Request.ServerVariables["HTTP_USER_AGENT"]) &&
                    context.Request.ServerVariables["HTTP_USER_AGENT"].Contains("EV1"))
                    encoding = "none";
            }
        }

        private bool IsCachedOnBrowser()
        {
            // check if the requesting browser sent an etag
            if (!string.IsNullOrEmpty(context.Request.ServerVariables["HTTP_IF_NONE_MATCH"]) &&
                context.Request.ServerVariables["HTTP_IF_NONE_MATCH"].Equals(hash))
            {
                context.Response.ClearHeaders();
                context.Response.AppendHeader("Etag", hash);
                context.Response.Status = "304 Not Modified";
                context.Response.AppendHeader("Content-Length", "0");
                return true;
            }
            return false;
        }

        private string GetMd5Sum(string str)
        {
            // First we need to convert the string into bytes, which
            // means using a text encoder.
            Encoder enc = System.Text.Encoding.Unicode.GetEncoder();

            // Create a buffer large enough to hold the string
            byte[] unicodeText = new byte[str.Length * 2];
            enc.GetBytes(str.ToCharArray(), 0, str.Length, unicodeText, 0, true);

            // Now that we have a byte array we can ask the CSP to hash it
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(unicodeText);

            // Build the final string by converting each byte
            // into hex and appending it to a StringBuilder
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                sb.Append(result[i].ToString("X2"));
            }

            // And return it
            return sb.ToString();
        }

        #endregion
    }
}
