#region Disclaimer/Info
///////////////////////////////////////////////////////////////////////////////////////////////////
// Ndot WebControls
// Ndot is a free C# lib for asp.net web apps!
// 
// title: Weather web controls. weather data get from http://weather.tq121.com.cn
// author:Denghaibo
// date:2007-1-8
// at:cuc china
// support:http://www.ndot.cn
///////////////////////////////////////////////////////////////////////////////////////////////////
#endregion


using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Drawing;
using System.Collections.Specialized;
using System.Web.UI.WebControls;

namespace Sky.WebControls
{
    /// <summary>
    /// Weather web controls
    /// </summary>
    [
    System.ComponentModel.Designer(typeof(PagerDesigner)),
    ToolboxData("<{0}:Weather runat=\"server\" />")
    ]
    public class Weather : Control
    {
        private readonly string CITY_DATA_NOT_FOUND = "没有该城市数据";
        private readonly string IMG_HTML = "<img src=\"{0}\" border=\"0\" alt=\"{0}\" title=\"{1}\" />";
        private readonly string BR = "<br/>";
        private string m_city = "北京";
        private string m_imgpath = "images/";
        private string m_cssclass;
        
        #region Accessors
        /// <summary>
        /// 城市名称
        /// </summary>
        public string City
        {
            set { this.m_city = value; }
            get { return this.m_city; }
        }

        /// <summary>
        /// 天气图标路径
        /// </summary>
        public string ImgPath
        {
            set { this.m_imgpath = value; }
            get { return this.m_imgpath; }
        }

        /// <summary>
        /// 样式
        /// </summary>
        public string CssClass
        {
            set { this.m_cssclass = value; }
            get { return this.m_cssclass; }
        }
        #endregion


        /// <summary>
        /// Render the img html code
        /// </summary>
        /// <returns></returns>
        protected string RenderImgStr(string img)
        {
            string imgPath = this.m_imgpath + img;
            return String.Format(IMG_HTML,imgPath,Util.Weather.GetWeatherStatusText(img));
        }
       
        #region Render
        /// <summary>
        /// Render
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            Util.Weather weather = new Sky.WebControls.Util.Weather();
            IList<Components.WeatherInfo> wic = weather.GetWeather(this.m_city);
            if(wic==null)
            {
                writer.Write(CITY_DATA_NOT_FOUND);
                return;
            }
            if (!String.IsNullOrEmpty(this.m_cssclass))
                writer.AddAttribute(HtmlTextWriterAttribute.Class, this.m_cssclass);
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
            writer.AddAttribute(HtmlTextWriterAttribute.Style, "font-weight:bold;");
            writer.RenderBeginTag(HtmlTextWriterTag.Span);           
            writer.Write(this.m_city);
            writer.RenderEndTag();
            writer.Write(BR);
            writer.Write(wic[0].Date);
            writer.Write(BR);
            writer.Write(RenderImgStr(wic[0].Img1));
            writer.Write(RenderImgStr(wic[0].Img2));
            writer.Write(BR);
            writer.Write(wic[0].Temperature);
            writer.Write(BR);
            writer.Write(wic[0].Wind);
            writer.Write(BR);           
            writer.RenderEndTag();


        }
        #endregion

       // #region IPostBackDataHandler 成员

       // /// <summary>
       // /// 为了访问回送数据，服务器控件要实现IPostBackDataHandler接口，有二个方法 
       // /// </summary>
       // public void RaisePostDataChangedEvent()
       // {
       //     //如果用户回送的数据发生改变则，发生事件 
       //     if (OnCityChanged != null)
       //     {
       //         OnCityChanged(this, EventArgs.Empty);
       //     }
       // }

       ///// <summary>
       ///// 
       ///// </summary>
       ///// <param name="postDataKey"></param>
       ///// <param name="postCollection"></param>
       ///// <returns></returns>
       // public bool LoadPostData(string postDataKey, NameValueCollection postCollection)
       // {
       //     bool raiseEvent = false; //要不要触发事件的标志 
       //     //如果上一次的文本与回送的文本不一样 
       //     if (City != postCollection[postDataKey])
       //     {
       //         raiseEvent = true;
       //         City = postCollection[postDataKey];//将回送的值保存 
       //     }
       //     return raiseEvent;
       // }
       // /// <summary>
       // /// 
       // /// </summary>
       // public event EventHandler OnCityChanged; 
       // #endregion 

    }
}
