using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;

namespace Sky.WebControls.Util
{
    /// <summary>
    /// Weather��ȡ
    /// </summary>
    public class Weather
    {
        private const string CITY_NOT_FOUND = "������ѯ�ĳ��в�����";
        private const string A0_TXT = "��";
        private const string A1_TXT = "����";
        private const string A2_TXT = "��";
        private const string A3_TXT = "С��";
        private const string A4_TXT = "С��";
        private const string A5_TXT = "С��";
        private const string A6_TXT = "С��";
        private const string A7_TXT = "С��";
        private const string A8_TXT = "С��";
        private const string A9_TXT = "С��";
        private const string A10_TXT = "С��";
        private const string A11_TXT = "С��";
        private const string A12_TXT = "С��";
        private const string A13_TXT = "��ѩ"; 
        private const string A14_TXT = "С��";
        private const string A15_TXT = "С��";
        private const string A16_TXT = "С��";
        private const string A17_TXT = "С��";
        private const string A18_TXT = "С��";
        private const string A19_TXT = "С��";
        private const string A20_TXT = "С��";
        private const string A21_TXT = "С��";
        private const string A22_TXT = "С��";
        private const string A23_TXT = "С��";
        private const string A24_TXT = "С��";
        private const string A25_TXT = "С��";
        private const string A26_TXT = "С��";
        private const string A27_TXT = "С��";
        private const string A28_TXT = "С��";
        private const string A29_TXT = "С��";
        private const string A30_TXT = "С��";
        private const string A31_TXT = "С��";
        
        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public IList<Components.WeatherInfo> GetWeather(string city)
        {
            string cacheKey = "weather_" + city;
            if (System.Web.HttpRuntime.Cache[cacheKey] != null)
            {
                return (IList<Components.WeatherInfo>)System.Web.HttpRuntime.Cache[cacheKey];
            }
            string source = @"http://weather.tq121.com.cn/detail.php?city=";
            string startAt = "<table width=\"780\" height=\"190\"";
            string endAt = "<table width=\"740\" height=\"838\"";
            
            Regex imgReg = new Regex("<img src=\"([^\"]+)\"[^>]+>", RegexOptions.IgnoreCase);

            Regex htmlReg = new Regex("<[^>]+>", RegexOptions.IgnoreCase);

            WebClient wc = new WebClient();
            // string city = "����";

            //������ת��Ϊurl����
            string gb2312City = System.Web.HttpUtility.UrlEncode(city, Encoding.GetEncoding("gb2312"));
            string all = wc.DownloadString(source + gb2312City);
            //��ѯ�ĳ��в�����
            if (all.IndexOf(CITY_NOT_FOUND) >= 0)
                return null;
            
            if (all.IndexOf(city) < 0)
            {
                return null;
            }
            int start = all.IndexOf(startAt);
            int end = all.IndexOf(endAt);
            string cleanStr = all.Substring(start, end - start);

            Match m;
            for (m = imgReg.Match(cleanStr); m.Success; m = m.NextMatch())
            {
                //�滻img���,ֻ����ͼƬ��ַ
                cleanStr = cleanStr.Replace(m.Groups[0].ToString(), m.Groups[1].ToString());
            }

            //ȥ������html���
            cleanStr = htmlReg.Replace(cleanStr, "");
            //ȥ������
            cleanStr = cleanStr.Replace("\n", "");
            cleanStr = cleanStr.Replace("images/hengxian.gif", "");
            //ȥ���ո�
            cleanStr = cleanStr.Replace(" ", "");
            if (cleanStr.StartsWith("&nbsp;"))
                cleanStr = cleanStr.Substring(6);
            if (cleanStr.EndsWith("&nbsp;"))
                cleanStr = cleanStr.Substring(0, cleanStr.Length - 6);

            cleanStr = cleanStr.Replace("&nbsp;&nbsp;", "&nbsp;");
            string[] s = Regex.Split(cleanStr, @"&nbsp;");


            IList<Components.WeatherInfo> wic = new List<Components.WeatherInfo>();
            
            foreach (string ss in s)
            {
                Components.WeatherInfo wi = new Sky.WebControls.Components.WeatherInfo();
                wi.Date = ss.Substring(0, ss.LastIndexOf("��") + 1);
                string img = ss.Substring(ss.LastIndexOf("��") + 1, ss.LastIndexOf("gif") - ss.LastIndexOf("��") + 2);

                wi.Img1 = img.Substring(0, img.IndexOf("gif") + 3);
                wi.Img2 = img.Substring(img.IndexOf("gif")+3);
                wi.Img1 = wi.Img1.Substring(wi.Img1.LastIndexOf("/") + 1);
                wi.Img2 = wi.Img2.Substring(wi.Img2.LastIndexOf("/") + 1);

                wi.Temperature = ss.Substring(ss.LastIndexOf("gif") + 3, ss.LastIndexOf("��") - ss.LastIndexOf("gif") - 2);
                wi.Wind = ss.Substring(ss.LastIndexOf("��") + 1);
                wic.Add(wi);
               
            }
            System.Web.HttpRuntime.Cache.Insert(cacheKey, wic, null, DateTime.Now.AddHours(1), TimeSpan.Zero);
            return wic;
            
        }

        /// <summary>
        /// ����ͼƬȡ������״������
        /// </summary>
        /// <param name="imgFile"></param>
        /// <returns></returns>
        public static string GetWeatherStatusText(string imgFile)
        { 
            switch(imgFile.Substring(0,imgFile.LastIndexOf(".")).ToLower())
            {
                case "a0":
                    return A0_TXT;
                case "a1":
                    return A1_TXT;
                case "a2": return A2_TXT;
                case "a3": return A3_TXT;
                case "a4": return A4_TXT;
                case "a5": return A5_TXT;
                case "a6": return A6_TXT;
                case "a7": return A7_TXT;
                case "a8": return A8_TXT;
                case "a9": return A9_TXT;
                case "a10": return A10_TXT;
                case "a11": return A11_TXT;
                case "a12": return A12_TXT;
                case "a13": return A13_TXT;
                case "a14": return A14_TXT;
                case "a15": return A15_TXT;
                case "a16": return A16_TXT;
                case "a17": return A17_TXT;
                case "a18": return A18_TXT;
                case "a19": return A19_TXT;
                case "a20": return A20_TXT;
                case "a21": return A21_TXT;
                case "a22": return A22_TXT;
                case "a23": return A23_TXT;
                case "a24": return A24_TXT;
                case "a25": return A25_TXT;
                case "a26": return A26_TXT;
                case "a27": return A27_TXT;
                case "a28": return A28_TXT;
                case "a29": return A29_TXT;
                case "a30": return A30_TXT;
                case "a31": return A31_TXT;
                default:
                    return "";

            }
        }
    }
}
