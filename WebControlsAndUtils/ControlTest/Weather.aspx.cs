using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;

public partial class Weather : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {      
        
            string city = Request.QueryString["city"];
            if (!String.IsNullOrEmpty(city))
                GetWeather(city);
            else
              
				GetWeather("北京");
        
    }


    private void GetWeather(string city)
    {
        string source = @"http://weather.tq121.com.cn/detail.php?city=";
        string startAt = "<table width=\"780\" height=\"190\"";
        string endAt = "<table width=\"740\" height=\"838\"";

        Regex imgReg = new Regex("<img src=\"([^\"]+)\"[^>]+>", RegexOptions.IgnoreCase);

        Regex htmlReg = new Regex("<[^>]+>", RegexOptions.IgnoreCase);

        WebClient wc = new WebClient();
        // string city = "北京";

        string gb2312City = HttpUtility.UrlEncode(city, Encoding.GetEncoding("gb2312"));
        string all = wc.DownloadString(source + gb2312City);

        if (all.IndexOf(city) < 0)
            Response.Write("没有该城市的数据");
        int start = all.IndexOf(startAt);
        int end = all.IndexOf(endAt);
        string cleanStr = all.Substring(start, end - start);

        Match m;
        for (m = imgReg.Match(cleanStr); m.Success; m = m.NextMatch())
        {
            //替换img标记,只保留图片地址
            cleanStr = cleanStr.Replace(m.Groups[0].ToString(), m.Groups[1].ToString());
        }

        //去除所有html标记
        cleanStr = htmlReg.Replace(cleanStr, "");
        //去除换行
        cleanStr = cleanStr.Replace("\n", "");
        cleanStr = cleanStr.Replace("images/hengxian.gif", "");
        //去除空格
        cleanStr = cleanStr.Replace(" ", "");
        if (cleanStr.StartsWith("&nbsp;"))
            cleanStr = cleanStr.Substring(6);
        if (cleanStr.EndsWith("&nbsp;"))
            cleanStr = cleanStr.Substring(0, cleanStr.Length - 6);

        cleanStr = cleanStr.Replace("&nbsp;&nbsp;", "&nbsp;");
        string[] s = Regex.Split(cleanStr, @"&nbsp;");
        Response.Clear();
        Response.ContentType = "text/xml";

        XmlTextWriter xtw = new XmlTextWriter(Response.OutputStream, Encoding.UTF8);
        xtw.Formatting = Formatting.Indented;
        //xtw.Indentation = 3;
        //  xtw.IndentChar = ' ';

        xtw.WriteStartDocument();
        xtw.WriteStartElement("WeatherCollection");
        xtw.WriteAttributeString("city", city);
        foreach (string ss in s)
        {
            xtw.WriteStartElement("Weather");
            xtw.WriteStartElement("Date");
            xtw.WriteString(ss.Substring(0, ss.LastIndexOf("日") + 1));
            xtw.WriteEndElement();
            xtw.WriteStartElement("Img");
            xtw.WriteString(ss.Substring(ss.LastIndexOf("日") + 1, ss.LastIndexOf("gif") - ss.LastIndexOf("日") + 2));
            xtw.WriteEndElement();
            xtw.WriteStartElement("Temperature");
            xtw.WriteString(ss.Substring(ss.LastIndexOf("gif") + 3, ss.LastIndexOf("℃") - ss.LastIndexOf("gif") - 2));
            xtw.WriteEndElement();
            xtw.WriteStartElement("Wind");
            xtw.WriteString(ss.Substring(ss.LastIndexOf("℃") + 1));
            xtw.WriteEndElement();
            xtw.WriteEndElement();

        }

        xtw.WriteEndElement();
        xtw.WriteEndDocument();

        xtw.Flush();
        xtw.Close();
    }
}
