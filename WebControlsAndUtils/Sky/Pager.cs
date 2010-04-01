#region Disclaimer/Info
///////////////////////////////////////////////////////////////////////////////////////////////////
// Ndot WebControls
// Ndot is a free C# lib for asp.net web apps!
//
// title: Pager web controls.general pager control
// author:Denghaibo
// date:2006-7-26
// at:cuc china
// support:http://www.ndot.cn
///////////////////////////////////////////////////////////////////////////////////////////////////
#endregion

#undef Diagnostic

using System;
using System.Collections;
using System.Web.UI;
using System.Drawing;

namespace Sky.WebControls
{

	/// <summary>
	/// 显示方式
	/// </summary>4
	public enum DisplayType
	{
		/// <summary>
		/// div
		/// </summary>
		Block,
		/// <summary>
		/// span
		/// </summary>
		Inline		
	}
    /// <summary>
    /// 页码格式
    /// </summary>
    public enum PagerType
    {
        /// <summary>
        /// 下拉菜单显示页码
        /// </summary>
        DropDown,
        /// <summary>
        /// 数字页码 
        /// </summary>
        Numberic,
      
        /// <summary>
        /// 不显示页码列表
        /// </summary>
        None
    }

	/// <summary>
	/// 分页控件
	/// writer by:Denghb
	/// date:2006-7-26
	/// </summary>
	[
	System.ComponentModel.Designer(typeof(PagerDesigner)),
	ToolboxData("<{0}:Pager runat=\"server\" />")	
	]
	public class Pager : Control, IPager
	{
		private const string VSKEY_ITEMCOUNT = "ItemCount";
        private const string VSKEY_PAGEINDEX = "PageIndex";
        private const string VSKEY_PAGESIZE = "PageSize";
        private const string VSKEY_DISPLAYPAGES = "DisplayPages";

        private const int FIRST_PAGE_INDEX = 1;
        private const int PAGESIZE_MIN = 1;
        private const int PAGESIZE_DEFAULT = 20;
        private const int ITEMCOUNT_DEFAULT = 120;
        private const int DISPLAYPAGES_MIN = 3;
        private const int DISPLAYPAGES_DEFAULT = 9;

        private const string SPACER_DEFAULT = "&nbsp;";
        private const string PREVTEXT_DEFAULT = "上一页";
        private const string NEXTTEXT_DEFAULT = "下一页";

        private const string URLFORMAT_DEFAULT = "/?pageid={0}";
        private const string LINKFORMAT_DEFAULT = "<a href=\"{0}\">{1}</a>";

        private const string NUMBER_LINKFORMAT_DEFAULT = "<a href=\"{0}\" class=\"n\">{1}</a>";

        private DisplayType _displayMode = DisplayType.Block;

        private string _cssClass = "pager";

       // private bool _useSpacer = true;
        private string _spacer = SPACER_DEFAULT;

        private string _urlFormat = URLFORMAT_DEFAULT;
        private string _linkFormat = LINKFORMAT_DEFAULT;
		//protected string _linkFormatActive = LINKFORMAT_ACTIVE_DEFAULT;

     //   private bool _useFirstLast = true;
        private string _prevText = PREVTEXT_DEFAULT;
        private string _nextText = NEXTTEXT_DEFAULT;
        private Color _statfontcolor = Color.Red;
        private PagerType _pagerType;
        private string _summaryText = "共有{0}条记录  每页{1}条";


		/// <summary>
		/// pager
		/// </summary>
		public Pager()
		{
            ViewState[VSKEY_ITEMCOUNT] = ITEMCOUNT_DEFAULT;
			ViewState[VSKEY_PAGEINDEX] = FIRST_PAGE_INDEX;
			ViewState[VSKEY_PAGESIZE] = PAGESIZE_DEFAULT;
		//	this.DisplayPages = DISPLAYPAGES_DEFAULT;
		}

		#region Accessors
		/// <summary>
		/// 显示方式,Block 或Inline
		/// </summary>
		public DisplayType DisplayMode
		{
			get { return _displayMode; }
			set { _displayMode = value; }
		}
        /// <summary>
        /// 页码显示格式
        /// </summary>
        public PagerType PagerType
        {
            get { return _pagerType; }
            set { _pagerType = value; }
        }
        /// <summary>
        /// 总页数描述文本
        /// </summary>
        public string SummaryText
        {
            get { return _summaryText; }
            set { _summaryText = value; }
        }

		/// <summary>
		/// Css类
		/// </summary>
		public string CssClass
		{
			get { return _cssClass; }
			set { _cssClass = value; }
		}

		/// <summary>
		/// 总记录数
		/// </summary>
		public int ItemCount
		{
			get 
			{ 				
				return (int)ViewState[VSKEY_ITEMCOUNT];
			}
			set 
			{ 
				if (value < 0)
					ViewState[VSKEY_ITEMCOUNT] = 0;
				else
					ViewState[VSKEY_ITEMCOUNT] = value;
			}
		}

		/// <summary>
		/// 当前页码
		/// </summary>
		public int PageIndex
		{
			get 
			{ 
				return (int)ViewState[VSKEY_PAGEINDEX]; 
			}
			set 
			{ 
				if (value >= FIRST_PAGE_INDEX)
					ViewState[VSKEY_PAGEINDEX] = value; 
				else
					ViewState[VSKEY_PAGEINDEX] = FIRST_PAGE_INDEX;
			}
		}

		/// <summary>
		/// 页面大小
		/// </summary>
		public int PageSize
		{
			get 
			{ 
				return (int)ViewState[VSKEY_PAGESIZE];
			}
			set 
			{ 
				if (value >= PAGESIZE_MIN)
					ViewState[VSKEY_PAGESIZE] = value; 
				else
					ViewState[VSKEY_PAGESIZE] = PAGESIZE_MIN;
			}
		}

        /// <summary>
        /// 统计信息字体颜色
        /// </summary>
        public System.Drawing.Color StatFontColor
        {
            get { return this._statfontcolor; }
            set { _statfontcolor = value; }
        }

		/// <summary>
		/// 默认空格
		/// </summary>
		public string Spacer
		{	
			get 
			{ 
				if (null == _spacer || _spacer.Length == 0) 
					_spacer = SPACER_DEFAULT;

				return _spacer; 
			}
			set { _spacer = value; }
		}

		/// <summary>
		/// 链接格式,即翻页时跳转的地址格式
		/// </summary>
		public string UrlFormat
		{	
			get { return _urlFormat; }
			set { _urlFormat = value; }
		}

		/// <summary>
		/// 链接格式
		/// </summary>
		public string LinkFormat
		{
			get { return _linkFormat; }
			set { _linkFormat = value; }
		}

		/// <summary>
		/// "上一页"文字
		/// </summary>
		public string PrevText
		{
			get { return _prevText; }
			set { _prevText = value; }
		}

		/// <summary>
		/// "下一页"文字
		/// </summary>
		public string NextText
		{
			get { return _nextText; }
			set { _nextText = value; }
		}

		/// <summary>
		/// 页面总数
		/// </summary>
		private int PageCount
		{
			get
			{
				return CalcPageCount(PageSize,ItemCount);
			}
		}

		#endregion

		// TODO: linkcss
		// TODO: linkherecss
		
		/// <summary>
		/// 计算页数
		/// </summary>
		/// <param name="pageSize"></param>
		/// <param name="itemCount"></param>
		/// <returns></returns>
		public int CalcPageCount(int pageSize,int itemCount)
		{
			int pageCount = itemCount/pageSize;
			if(itemCount%pageSize>0)
				pageCount ++;
			return pageCount;
		}
		
		/// <summary>
		/// 一般链接
		/// </summary>
		/// <param name="linkIndex"></param>
		/// <returns></returns>
		protected string RenderLink(int linkIndex)
		{
			string url= String.Format(_urlFormat,linkIndex);
            return String.Format(NUMBER_LINKFORMAT_DEFAULT + _spacer, url, linkIndex);
		}
        /// <summary>
        /// 当前页
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        protected string RenderCurrentPage(int index)
        {
            string sp = "<span class=\"current\">{0}</span>" + _spacer;
            return  String.Format(sp,index);
        }
		/// <summary>
		/// 上一页链接
		/// </summary>
		/// <param name="PageIndex"></param>
		/// <returns></returns>
		protected string RenderPrevLink(int PageIndex)
		{
			string url = String.Format(_urlFormat,PageIndex-1,ItemCount);
			return String.Format(PageIndex<=1 ? _prevText :_linkFormat,url,_prevText);
		}

		/// <summary>
		/// 下一页链接
		/// </summary>
		/// <param name="_pageIndex"></param>
		/// <returns></returns>
		protected string RenderNextLink(int _pageIndex)
		{
			string url = String.Format(_urlFormat, PageIndex+1,ItemCount);
            return String.Format(PageIndex >= PageCount ? _nextText : _linkFormat, url, _nextText) + _spacer;
		}

		/// <summary>
		/// 指示当前位置链接
		/// </summary>
		/// <returns></returns>
		protected string RenderLocationStr()
		{
			string str = "&nbsp;&nbsp;第<span id='spCurrentPage'>{0}</span>页/共{1}页&nbsp;&nbsp;";
			return String.Format(str,PageIndex,PageCount);
		}

		/// <summary>
		/// 统计信息链接
		/// </summary>
		/// <returns></returns>
		protected string RenderStatStr()
		{

            //string str = "&nbsp;&nbsp;共有<span style='font-weight:bold; color:" + ColorTranslator.ToHtml(this._statfontcolor) + "'>{0}</span>条记录&nbsp;&nbsp;每页<span style='font-weight:bold;color:" + ColorTranslator.ToHtml(this._statfontcolor) + "'>{1}</span>条";

            return String.Format(_summaryText, ItemCount, PageSize);
		}

		/// <summary>
		/// 写入脚本至页面
		/// </summary>
		/// <param name="writer"></param>
		/// <param name="script"></param>
		protected void RenderScript(HtmlTextWriter writer,string script)
		{
			writer.AddAttribute("language","javascript");
			writer.RenderBeginTag(HtmlTextWriterTag.Script);
			
			writer.Write(script);
			writer.RenderEndTag();		
		}

		/// <summary>
		/// 下拉跳转菜单
		/// </summary>
		/// <param name="writer"></param>
		protected void RenderDropDownList(HtmlTextWriter writer)
		{
            switch (PagerType)
            {
                case PagerType.DropDown:
                    string script = @"function jumpTo(obj)
							        {
								        window.location.href=obj.options[obj.selectedIndex].value;
        								
							        }";

                    RenderScript(writer, script);
                    writer.Write("跳至第");

                    writer.AddAttribute("onchange", "jumpTo(this)");
                    writer.AddAttribute("id", "ddlJumpTO");
                    writer.RenderBeginTag(HtmlTextWriterTag.Select);

                    for (int i = 1; i <= PageCount; i++)
                    {
                        writer.AddAttribute("value", String.Format(_urlFormat, i, ItemCount));
                        writer.RenderBeginTag(HtmlTextWriterTag.Option);

                        writer.Write(i);
                        writer.RenderEndTag();
                    }
                    writer.RenderEndTag();
                    writer.Write("页&nbsp;&nbsp;");
                    break;
                case PagerType.Numberic:
                    int start = 1;
                    int end = 8;
                    if (PageIndex >= 8)
                    {
                        start = PageIndex - 3;
                        end = PageIndex + 3;
                    }
                    if (end > PageCount) end = PageCount;
                    if (start > 3)
                    {//跳至第1页
                        writer.Write(RenderLink(1));
                        writer.Write("...");
                    }
                    for (; start <= end; start++)
                    {
                        if (start == PageIndex)
                            writer.Write(RenderCurrentPage(start));
                        else
                            writer.Write(RenderLink(start));
                    }
                    if (PageCount - end > 1)
                    {
                        writer.Write("...");
                        writer.Write(RenderLink(PageCount));
                    }
                    else if(PageCount != end)
                        writer.Write(RenderLink(PageCount));
                    break;
                default:
                    break;

            }
		}


        #region Render
        /// <summary>
        /// Render
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
		{	
			// 只有一页
			if (FIRST_PAGE_INDEX == PageCount || ItemCount ==0) return;

			if (_cssClass.Length > 0)
				writer.AddAttribute("class", _cssClass);
		
			if (_displayMode == DisplayType.Block)
				writer.RenderBeginTag(HtmlTextWriterTag.Div);
			else
				writer.RenderBeginTag(HtmlTextWriterTag.Span);
			
			
			writer.Write(RenderPrevLink(PageIndex));
			writer.Write(RenderLocationStr());
			RenderDropDownList(writer);
			writer.Write(RenderNextLink(PageIndex));
			
			writer.Write(RenderStatStr());
            if(PagerType == PagerType.DropDown)
			    RenderScript(writer,"document.getElementById('ddlJumpTO').selectedIndex =document.getElementById('spCurrentPage').innerHTML-1");
            writer.RenderEndTag();

            #if Diagnostic
			            writer.Write("<br>PageIndex={0}, _padLeft={1}, _padRight={2}, MaxPages={3}, DisplayPages={4}, ItemCount={5}<br>", 
				            PageIndex, _padLeft, _padRight, MaxPages, DisplayPages, ItemCount);
            #endif
			
		}
		#endregion
	}
    
	/// <summary>
	/// PagerDesigner
	/// </summary>
	public class PagerDesigner : System.Web.UI.Design.ControlDesigner
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string GetDesignTimeHtml()
		{			
			return base.GetDesignTimeHtml();
		}

		/// <summary>
		/// Initialize
		/// </summary>
		/// <param name="component"></param>
		public override void Initialize(System.ComponentModel.IComponent component)
		{
			if (component is IPager)
			{
				IPager context = component as IPager;
				context.PageSize = 20;
               // context.ItemCount = 120;
				context.PageIndex++;
			}

			base.Initialize(component);
		}

	}
}

