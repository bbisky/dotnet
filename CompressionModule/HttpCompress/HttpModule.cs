/// 
/// As a starting point for this module i used the Blowery module written by Ben Lowery.
/// his blog is located at : http://www.blowery.org/blog/
/// After studying the module that he wrote I couldn't see the point of all the inherited streams
/// because the one we use is already limited with a bunch of constraints.
/// http://www.blowery.org/code/HttpCompressionModule.html
/// The version he has for .net 2.0 is ported from .net 1.1 and the configuration properties don't follow 
/// the new schema anymore. 
/// Because of the change from #ziplib to the native .net 2.0 everything that has to do with quality 
/// doesn't count anymore.
/// I decided to rewrite his library to a .net 2.0 version of it which turned out to be much shorter.
/// So this module is copyrighted by Ivan Porto Carrero, Flanders International Marketing Ltd. 2006
/// Blog : http://www.flanders.co.nz/blog
/// You are free to use this module as long as you keep this notice in the source files
/// 
/// 23/01/2006
/// I changed the module to do work at the post release request state event in stead of at begin request.
/// When fired with begin request the parameters get zipped and form values get affected which kills the correct processing of the page.
/// The compression now takes place after the entire content has been created.
/// 
/// The above was written by Flanders.
/// The Items I added are marked with DC.
/// 
/// A quick explanation of the web resource compression.  A call to WebResource.axd using
/// the module breaks it for some reason.  I tried a lot of different things to get around this
/// but to no avail.  Finally I came up with the following solution.  Hook into the begin request
/// and check if it is a webResource.axd.  If it is then call CompleteRequest so it goes straight
/// to the EndRequest method.  This is so no processing is done on the request.  In EndRequest,
/// send it to the CompressWebResource object.  This then checks to see if there is an Etag (cached on browser),
/// if there is it sends a Not Modified header. (The webresource is loaded every time normally, this adds
/// browser cache ability to WebResource files.)  Then I check if a file is cached, if it is then I 
/// send the cached file.  Otherwise, I create a HttpWebRequest and request the WebResource.axd, but add a 'u=1'
/// to the query string so I know to let it pass through the above and retrieves the WebResource.
/// Then I check the content-type, if it is neither javascript or css then I send it to the 
/// browser, first adding an Etag to allow browser caching.  If it is javascript or css,
/// then get the allowed encoding and encode the data and cache it on disk.
/// 
/// 
/// I expect the credit to be given where credit is due.  The module is created by Flanders
/// and the above copyright applies.  The Compress.cs,CompressHandler.cs,and CompressWebResource.cs
/// were created by me, Darick Carpenter.  The CompressHandler is a port from PHP obtained here:
/// http://rakaz.nl/item/make_your_pages_load_faster_by_combining_and_compressing_javascript_and_css_files
/// and the copyright from that port is on CompressHandler.cs.  The CompressWebResource was
/// created by me and I echo the copyright notice in CompressHandler.cs offering no warranty.  
/// 
/// Darick Carpenter
///
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.IO;
using System.IO.Compression;
using System.Configuration;

namespace DC.Web.HttpCompress
{
    /// <summary>
    /// The Http Module that will compress the outputstream to the browser if it is supported by the browser.
    /// </summary>
    public class HttpModule : IHttpModule
    {
        #region IHttpModule Members

        public void Dispose()
        {

        }

        public void Init(HttpApplication context)
        {
            /* The Post Release Request State is the event most fitted for the task of adding a filter
            // Everything else is too soon or too late. At this point in the execution phase the entire 
             * response content is created and the page has fully executed but still has a few modules to go through
             * from an asp.net perspective.  We filter the content here and all of the javascript renders correctly.*/
            context.PostReleaseRequestState += new EventHandler(context_PostReleaseRequestState);
        }

        void context_PostReleaseRequestState(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;

            if (app.Request["HTTP_X_MICROSOFTAJAX"] != null)
                return;

            // fix to handle caching appropriately
            // see http://www.pocketsoap.com/weblog/2003/07/1330.html
            // Note, this header is added only when the request
            // has the possibility of being compressed...
            // i.e. it is not added when the request is excluded from
            // compression by CompressionLevel, Path, or MimeType            
            string realPath = "";
            Configuration settings = null;
            // get the config settings
            if (app.Context.Cache["DCCompressModuleConfig"] == null)
            {
                settings = (Configuration)ConfigurationManager.GetSection("DCWeb/HttpCompress");
                app.Context.Cache["DCCompressModuleConfig"] = settings;
            }
            else
                settings = (Configuration)app.Context.Cache["DCCompressModuleConfig"];
            if (settings != null)
            {
                app.Context.Cache.Insert("DCCompressModuleConfig", settings);
                // skip if the CompressionLevel is set to 'None'
                if (settings.CompressionType == CompressionType.None)
                    return;
                realPath = app.Request.Path.Remove(0, app.Request.ApplicationPath.Length);
                realPath = (realPath.StartsWith("/")) ? realPath.Remove(0, 1) : realPath;

                bool isIncludedPath, isIncludedMime;

                isIncludedPath = (settings.IncludedPaths.Contains(realPath) | settings.IncludedPaths.Contains("~/" + realPath));
                isIncludedMime = (settings.IncludedMimeTypes.Contains(app.Response.ContentType));

                // path was not included, so skip it
                if (!isIncludedPath && !isIncludedMime)
                    return;

                // skip if the file path excludes compression
                if (settings.ExcludedPaths.Contains(realPath) | settings.ExcludedPaths.Contains("~/" + realPath))
                    return;

                // skip if the MimeType excludes compression
                if (settings.ExcludedMimeTypes.Contains(app.Response.ContentType))
                    return;
            }
            app.Context.Response.Cache.VaryByHeaders["Accept-Encoding"] = true;
            string acceptedTypes = app.Request.Headers["Accept-Encoding"];

            // if we couldn't find the header, bail out
            if (acceptedTypes == null)
                return;

            // Current response stream

            //Stream baseStream = app.Response.Filter;
            CompressionPageFilter filter = new CompressionPageFilter(app.Response.Filter);
            filter.App = app;
            app.Response.Filter = filter;

            // check for buggy versions of Internet Explorer
            if (app.Context.Request.Browser.Browser == "IE")
            {
                if (app.Context.Request.Browser.MajorVersion < 6)
                    return;
                else if (app.Context.Request.Browser.MajorVersion == 6 &&
                    !string.IsNullOrEmpty(app.Context.Request.ServerVariables["HTTP_USER_AGENT"]) &&
                    app.Context.Request.ServerVariables["HTTP_USER_AGENT"].Contains("EV1"))
                    return;
            }

            // If there are more than one possibility offered by the browser default to the preffered one from the web.config
            // If nothing is specified in the web.config default to GZip
            acceptedTypes = acceptedTypes.ToLower();
            if ((acceptedTypes.Contains("gzip") || acceptedTypes.Contains("x-gzip") || acceptedTypes.Contains("*")) && (settings.CompressionType != CompressionType.Deflate))
                filter.Compress = "gzip";
            else if (acceptedTypes.Contains("deflate"))
                filter.Compress = "deflate";
            if (filter.Compress != "none")
                app.Response.AppendHeader("Content-Encoding", filter.Compress);
        }





        #endregion


        #region Stream filter

        private class CompressionPageFilter : Stream
        {
            private HttpApplication app;
            public HttpApplication App
            {
                get { return app; }
                set { app = value; }
            }
            private string compress = "none";
            public string Compress
            {
                get { return compress; }
                set { compress = value; }
            }
            StringBuilder responseHtml;

            const string _cssPattern = "(?<HTML><link[^>]*href\\s*=\\s*[\\\"\\']?(?<HRef>[^\"'>\\s]*)[\\\"\\']?[^>]*>)";
            const string _jsPattern = "(?<HTML><script[^>]*src\\s*=\\s*[\\\"\\']?(?<SRC>[^\"'>\\s]*)[\\\"\\']?[^>]*></script>)";
            public CompressionPageFilter(Stream sink)
            {
                _sink = sink;
                responseHtml = new StringBuilder();
            }

            private Stream _sink;

            #region Properites

            public override bool CanRead
            {
                get { return true; }
            }

            public override bool CanSeek
            {
                get { return true; }
            }

            public override bool CanWrite
            {
                get { return true; }
            }

            public override void Flush()
            {
                _sink.Flush();
            }

            public override long Length
            {
                get { return 0; }
            }

            private long _position;
            public override long Position
            {
                get { return _position; }
                set { _position = value; }
            }

            #endregion

            #region Methods

            public override int Read(byte[] buffer, int offset, int count)
            {
                return _sink.Read(buffer, offset, count);
            }

            public override long Seek(long offset, SeekOrigin origin)
            {
                return _sink.Seek(offset, origin);
            }

            public override void SetLength(long value)
            {
                _sink.SetLength(value);
            }

            public override void Close()
            {
                _sink.Close();
            }

            public override void Write(byte[] buffer, int offset, int count)
            {
                string strBuffer = UTF8Encoding.UTF8.GetString(buffer, offset, count);

                // ---------------------------------
                // Wait for the closing </html> tag
                // ---------------------------------
                Regex eof = new Regex("</html>", RegexOptions.IgnoreCase);

                responseHtml.Append(strBuffer);

                if (eof.IsMatch(strBuffer))
                {
                    // when compressing the html, some end characters are cut off.  Add some spaces so it cuts the spaces off instead of important characters
                    responseHtml.Append(Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine);
                    string html = responseHtml.ToString();

                    // replace the css and js with HttpHandlers that compress the output                    
                    html = ReplaceJS(html);
                    html = ReplaceCss(html);

                    byte[] data = UTF8Encoding.UTF8.GetBytes(html);

                    // if compression is enabled
                    if (compress == "gzip")
                    {
                        GZipStream gzip = new GZipStream(_sink, CompressionMode.Compress);
                        gzip.Write(data, 0, data.Length);
                    }
                    else if (compress == "deflate")
                    {
                        DeflateStream deflate = new DeflateStream(_sink, CompressionMode.Compress);
                        deflate.Write(data, 0, data.Length);
                    }
                    else
                        _sink.Write(data, 0, data.Length);
                }
            }

            /// <summary>
            /// Replcase stylesheet links with ones pointing to HttpHandlers that compress and cache the css
            /// </summary>
            /// <param name="html"></param>
            /// <returns></returns>
            public string ReplaceCss(string html)
            {
                // create a list of the stylesheets
                List<string> stylesheets = new List<string>();
                // create a dictionary used for combining css in the same directory
                Dictionary<string, List<string>> css = new Dictionary<string, List<string>>();

                // create a base uri which will be used to get the uris to the css
                Uri baseUri = new Uri(app.Request.Url.AbsoluteUri);

                // loop through each match
                foreach (Match match in Regex.Matches(html, _cssPattern, RegexOptions.IgnoreCase))
                {
                    // this is the enire match and will be used to replace the link
                    string linkHtml = match.Groups[0].Value;
                    // this is the href of the link
                    string href = match.Groups[2].Value;

                    // get a uri from the base uri, this will resolve any relative and absolute links
                    Uri uri = new Uri(baseUri, href);
                    string file = "";
                    // check to see if it is a link to a local file
                    if (uri.Host == baseUri.Host)
                    {
                        // check to see if it is local to the application
                        if (uri.AbsolutePath.ToLower().StartsWith(app.Context.Request.ApplicationPath.ToLower()))
                        {
                            // this combines css files in the same directory into one file (actual combining done in HttpHandler)
                            int index = uri.AbsolutePath.LastIndexOf("/");
                            string path = uri.AbsolutePath.Substring(0, index + 1);
                            file = uri.AbsolutePath.Substring(index + 1);
                            if (!css.ContainsKey(path))
                                css.Add(path, new List<string>());
                            css[path].Add(file + (href.Contains("?") ? href.Substring(href.IndexOf("?")) : ""));
                            // replace the origianl links with blanks
                            html = html.Replace(linkHtml, "");
                            // continue to next link
                            continue;
                        }
                        else
                            file = uri.AbsolutePath + uri.Query;
                    }
                    else
                        file = uri.AbsoluteUri;
                    string newLinkHtml = linkHtml.Replace(href, "css.axd?files=" + file);

                    // just replace the link with the new link
                    html = html.Replace(linkHtml, newLinkHtml);
                }

                StringBuilder link = new StringBuilder();
                link.AppendLine("");
                foreach (string key in css.Keys)
                {
                    link.AppendLine(string.Format("<link href='{0}css.axd?files={1}' type='text/css' rel='stylesheet' />", key, string.Join(",", css[key].ToArray())));

                }

                // find the head tag and insert css in the head tag
                //int x = html.IndexOf("<head");
                //mod by sky: insert after title tag
                int x = html.IndexOf("</title");
                if (x < 0)
                    x = html.IndexOf("<head");
                int num = 0;
                if (x > -1)
                {
                    num = html.Substring(x).IndexOf(">");
                    html = html.Insert(x + num + 1, link.ToString());
                }
                return html;
            }

            /// <summary>
            /// Replcase javascript links with ones pointing to HttpHandlers that compress and cache the javascript
            /// </summary>
            /// <param name="html"></param>
            /// <returns></returns>
            public string ReplaceJS(string html)
            {
                // if the javascript is in the head section of the html, then try to combine the javascript into one
                int start, end;
                if (html.Contains("<head") && html.Contains("</head>"))
                {
                    start = html.IndexOf("<head");
                    end = html.IndexOf("</head>");
                    string head = html.Substring(start, end - start);

                    head = ReplaceJSInHead(head);

                    html = html.Substring(0, start) + head + html.Substring(end);
                }

                // javascript that is referenced in the body is usually used to write content to the page via javascript, 
                // we don't want to combine these and place them in the header since it would cause problems
                // or it is a WebResource.axd or ScriptResource.axd
                if (html.Contains("<body") && html.Contains("</body>"))
                {
                    start = html.IndexOf("<body");
                    end = html.IndexOf("</body>");
                    string head = html.Substring(start, end - start);

                    head = ReplaceJSInBody(head);

                    html = html.Substring(0, start) + head + html.Substring(end);
                }

                return html;
            }

            /// <summary>
            /// Replaces the js in the head tag. (see ReplaceCss for comments)
            /// </summary>
            /// <param name="html"></param>
            /// <returns></returns>
            public string ReplaceJSInHead(string html)
            {
                List<string> javascript = new List<string>();
                Dictionary<string, List<string>> js = new Dictionary<string, List<string>>();

                Uri baseUri = new Uri(app.Request.Url.AbsoluteUri);
                foreach (Match match in Regex.Matches(html, _jsPattern, RegexOptions.IgnoreCase))
                {
                    string linkHtml = match.Groups[0].Value;
                    string src = match.Groups[2].Value;

                    Uri uri = new Uri(baseUri, src);
                    if (!Path.GetExtension(uri.AbsolutePath).Equals("js") && uri.AbsolutePath.Contains("WebResource.axd"))
                        continue;
                    if (uri.Host == baseUri.Host)
                    {
                        if (uri.AbsolutePath.ToLower().StartsWith(app.Context.Request.ApplicationPath.ToLower()))
                        {
                            int index = uri.AbsolutePath.LastIndexOf("/");
                            string path = uri.AbsolutePath.Substring(0, index + 1);
                            string file = uri.AbsolutePath.Substring(index + 1);
                            if (!js.ContainsKey(path))
                                js.Add(path, new List<string>());
                            js[path].Add(file + (src.Contains("?") ? src.Substring(src.IndexOf("?")) : ""));
                        }
                        else
                            javascript.Add(uri.AbsolutePath + uri.Query);

                    }
                    else
                        javascript.Add(uri.AbsoluteUri);
                    html = html.Replace(linkHtml, "");
                }

                //int x = html.IndexOf("<head");
                //mod by sky: insert after title tag
                int x = html.IndexOf("</title");
                if(x <0)
                    x = html.IndexOf("<head");
                int num = html.Substring(x).IndexOf(">");
                string link = "";

                foreach (string key in js.Keys)
                {
                    link = string.Format("<script src='{0}js.axd?files={1}' type='text/javascript' ></script>", key, string.Join(",", js[key].ToArray()));
                    html = html.Insert(x + num + 1, link + Environment.NewLine);

                }
                if (javascript.Count > 0)
                {
                    link = string.Format("<script src='js.axd?files={0}' type='text/javascript' /></script>", string.Join(",", javascript.ToArray()));
                    html = html.Insert(x + num + 1, link + Environment.NewLine);
                }
                return html;
            }

            /// <summary>
            /// Replaces the js in the body. (see ReplaceCss for comments)
            /// </summary>
            /// <param name="html"></param>
            /// <returns></returns>
            public string ReplaceJSInBody(string html)
            {
                Uri baseUri = new Uri(app.Request.Url.AbsoluteUri);
                foreach (Match match in Regex.Matches(html, _jsPattern, RegexOptions.IgnoreCase))
                {
                    string linkHtml = match.Groups[0].Value;
                    string src = match.Groups[2].Value;


                    Uri uri = new Uri(baseUri, src);
                    if (!uri.AbsolutePath.EndsWith(".js") && !uri.AbsolutePath.Contains("WebResource.axd"))
                        continue;
                    string file = "";
                    string path = "";
                    if (uri.Host == baseUri.Host)
                    {
                        if (uri.AbsolutePath.ToLower().StartsWith(app.Context.Request.ApplicationPath.ToLower()))
                        {
                            int index = uri.AbsolutePath.LastIndexOf("/");
                            path = uri.AbsolutePath.Substring(0, index + 1);
                            file = uri.AbsolutePath.Substring(index + 1) + (src.Contains("?") ? src.Substring(src.IndexOf("?")) : "");
                        }
                        else
                            file = uri.AbsolutePath + uri.Query;
                    }
                    else
                        file = uri.AbsoluteUri;
                    string newLinkHtml = linkHtml.Replace(src, path + "js.axd?files=" + file);
                    html = html.Replace(linkHtml, newLinkHtml);
                }
                return html;
            }

            #endregion

        }

        #endregion
    }
}
