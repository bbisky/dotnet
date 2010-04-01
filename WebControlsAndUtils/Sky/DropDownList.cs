using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.ComponentModel;
using System.Collections;
using System.Web.UI.WebControls;
using System.Data;

[assembly: WebResource("Sky.WebControls.sky.ddl.js","application/javascript")]
[assembly: WebResource("Sky.WebControls.sky.ddl.css", "text/css", PerformSubstitution=true)]
[assembly: WebResource("Sky.WebControls.sky.ddl.arrow.gif", "image/gif")]   
namespace Sky.WebControls
{
    /// <summary>
    /// 高级下拉菜单
    /// </summary>
    [
  //  System.ComponentModel.Designer(typeof(PagerDesigner)),
    ToolboxData("<{0}:DropdownList runat=\"server\" />")
    ]
    public class DropDownList : Control, IPostBackDataHandler
    {
        #region 公共属性
        private int m_SelectedIndex = -1;
        private IList<ListItem> m_Data;
        [Browsable(false)]
        [Description("获取或设置选择项索引")]
        public int SelectedIndex
        {
            get { return m_SelectedIndex; }
            set { m_SelectedIndex = value; }
        }

        private string m_SelectedValue = "";
        [Browsable(false)]
        [Description("获取或设置选择项的值")]
        public string SelectedValue
        {
            get { return m_SelectedValue; }
            set { m_SelectedValue = value; }
        }
        private string m_SelectedText = "";

        [Browsable(false)]
        [Description("获取选择项的文本")]       
        public string SelectedText
        {
            get { return m_SelectedText; }
          //  set { m_SelectedText = value; }
        }

        //data
        private IEnumerable m_ds;
        [Browsable(false)]
        [Description("获取选择项的文本")]   
        [Category("数据")]
        public object DataSource
        {
            get { return this.m_ds; }
            set{
                this.m_ds = GetResolvedDataSource(value);                
            }
        }

        private string m_DataTextField;
        [Browsable(true)]
        [Description("数据源中提供项文本字段")]
        [Category("数据")]
        public string DataTextField
        {
            set { this.m_DataTextField = value; }
            get { return this.m_DataTextField; }
        }

        private string m_DataValueField;
        [Browsable(true)]
        [Description("数据源中提供项值字段")]
        [Category("数据")]
        public string DataValueField
        {
            set { this.m_DataValueField = value; }
            get { return this.m_DataValueField; }
        }

        #endregion

        #region protected attribute
        protected virtual string DropDownListDataListName
        {
            get { return this.UniqueID + ":List"; }
        }

        protected virtual string DropDownListSelectedTextName
        {
            get { return this.UniqueID + ":SelectedText"; }
        }
        protected virtual string DropDownListSelectedIndexName
        {
            get { return this.UniqueID + ":SelectedIndex"; }
        }

        protected virtual string DropDownListDataListId
        {
            get { return this.ClientID + "_List"; }
        }

        protected virtual string DropDownListSelectedTextId
        {
            get { return this.ClientID + "_SelectedText"; }
        }

        protected virtual string DropDownListSelectedIndexId
        {
            get { return this.ClientID + "_SelectedIndex"; }
        }
        #endregion

        #region Render
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (!this.DesignMode)
            {
                if (!Page.ClientScript.IsClientScriptIncludeRegistered("Sky.WebControls.DropDownList"))
                {
                    Page.ClientScript.RegisterClientScriptInclude(this.GetType(),
                        "Sky.WebControls.DropDownList", Page.ClientScript.GetWebResourceUrl(this.GetType(), "Sky.WebControls.sky.ddl.js"));
                    string css = Page.ClientScript.GetWebResourceUrl(this.GetType(), "Sky.WebControls.sky.ddl.css");
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Sky.WebControls.CSS", "<link href=\"" + css + "\" rel=\"stylesheet\" type=\"text/css\"/>");
                }
            }
        }

        public override void RenderControl(HtmlTextWriter writer)
        {
            base.RenderControl(writer);
        }

        protected virtual void RenderList(HtmlTextWriter writer)
        {
            if (this.m_Data != null)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "sky__ddl_itemlist");
                writer.AddAttribute(HtmlTextWriterAttribute.Id, this.DropDownListDataListId);
                writer.RenderBeginTag(HtmlTextWriterTag.Ul);                
                foreach (ListItem li in this.m_Data)
                {
                    writer.AddAttribute(HtmlTextWriterAttribute.Value, li.Value);
                    writer.RenderBeginTag(HtmlTextWriterTag.Li);                    
                    writer.Write(li.Text);
                    writer.RenderEndTag();
                }
                writer.RenderEndTag();
            }
        }
        protected override void RenderChildren(HtmlTextWriter writer)
        {
            base.RenderChildren(writer);
            //
            //

         //   string sInput = "<input type=\"text\" class=\"dropdown_tbx\" onfocus=\"skyddl.showList(this);\" id=\"" + this.ClientID + "\" />";
       //     string sArrow = "<input class=\"dropdown_btn\" onclick=\"skyddl.showList(document.getElementById('"+this.ClientID+"'));\" type=\"button\" />";
            StringBuilder listHtml = new StringBuilder();
            listHtml.Append("<ul class=\"sky__ddl_itemlist\" id=\"")                
                .Append(this.DropDownListDataListId)

                .Append("\"><li value=\"1001\">Alfa</li>")
                .Append("<li value=\"1002\">Alpha</li>")
                .Append("<li value=\"1003\">Bissotwo</li>")
                .Append("<li value=\"1004\">Bravo</li>")
                .Append("<li value=\"1005\">Charlie</li>")
                .Append("</ul>");

           
            
            StringBuilder containerHtml = new StringBuilder();
           
            containerHtml.Append("<table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" style=\"border-style: none; border-width: 0px; border-collapse: collapse; display: inline-block; position: relative; top: 5px;\" class=\"sky__ddl_container\" >")
                        .Append("<tbody><tr>")
                        .Append("<td class=\"sky__ddl_textboxcontainer\">")
                        .Append("<input type=\"text\" onfocus=\"skyddl.showList(this);\" id=\"" + this.DropDownListSelectedTextId + "\" name=\""+this.DropDownListSelectedTextName+"\" />")
                        .Append("<input type=\"hidden\" id=\"" + this.ClientID + "\" name=\"" + this.UniqueID + "\" />")
                         .Append("<input type=\"hidden\" id=\"" + this.DropDownListSelectedIndexId + "\" name=\"" + this.DropDownListSelectedIndexName + "\" />")
                        .Append("</td>")
                        .Append("<td class=\"sky__ddl_buttoncontainer\">")
                        .Append("<button onclick=\"skyddl.showList(document.getElementById('" + this.DropDownListSelectedTextId + "'));\" type=\"button\" />")
                        .Append("</td>")
                        .Append("</tr>")
                        .Append("</tbody>")
                        .Append("</table>");

            StringBuilder onloadScript = new StringBuilder();
            onloadScript.Append("<script language=\"javascript\">")
                        .Append("skyddl.list = document.getElementById(\"" + this.DropDownListDataListId + "\");")
                        .Append("skyddl.children = skyddl.list.children;")
                        .Append("skyddl.ipt_textbox = document.getElementById(\"" + this.DropDownListSelectedTextId + "\");")
                        .Append("skyddl.ipt_value = document.getElementById(\"" + this.ClientID + "\");")
                        .Append("skyddl.ipt_index = document.getElementById(\"" + this.DropDownListSelectedIndexId + "\");")
                        .Append("skyddl.ipt_textbox.onblur = function(){skyddl.hidelist();};")
                        .Append("document.onkeydown =skyddl.keydown;")
                        .Append(" for(var i=0;i<skyddl.children.length;i++)")
                        .Append("{")
                        .Append("var item = skyddl.children[i];")
                        .Append("item.i = i;")
                        .Append("item.onmouseover = function(){skyddl.hilightListItem(this.i);};")
                        .Append("item.onmouseout = function(){this.className=\"\";};")
                        .Append("item.onclick = function(){skyddl.selectedItem(this.i);};")
                        .Append("}")
                        .Append("</script>");
           // writer.Write(sInput);
            //writer.Write(sArrow);
            writer.Write(containerHtml.ToString());
            //writer.Write(listHtml.ToString());
            RenderList(writer);
            writer.Write(onloadScript.ToString());
        }
        #endregion

        #region IPostBackDataHandler 成员

        public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            if (postCollection[this.DropDownListSelectedIndexName] != this.m_SelectedIndex.ToString())
            {
                this.m_SelectedValue = postCollection[this.UniqueID];
                this.m_SelectedIndex = Int32.Parse(postCollection[this.DropDownListSelectedIndexName]);
                this.m_SelectedText = postCollection[this.DropDownListSelectedTextName];
                return true;
            }
            return false;
        }

        public void RaisePostDataChangedEvent()
        {
           
        }

        #endregion

        #region 受保护成员
        protected virtual void ValidateDataSource(object dataSource)
        {
            if (!(dataSource is IEnumerable))
                throw new Exception("不支持该类型的数据源");
        }
        #endregion

        protected IEnumerable GetResolvedDataSource(object source)
        {
            if (source is IEnumerable)
                return (IEnumerable)source;
            else if (source is IList)
                return (IEnumerable)source;
            else if (source is DataSet)
                return (IEnumerable)(((DataSet)source).Tables[0].DefaultView);
            else if (source is DataTable)
                return (IEnumerable)(((DataTable)source).DefaultView);
            else
                throw new Exception("不支持该类型的数据源");
        }

        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);
            //cache list
            EnumerateDataAndCreateControlHierarchy();
        }

        protected virtual void EnumerateDataAndCreateControlHierarchy()
        {
            if (this.m_ds != null)
            {

                IEnumerator iter = this.m_ds.GetEnumerator();
                if (this.m_Data == null)
                    this.m_Data = new List<ListItem>();
                while (iter.MoveNext()) {
                    
                    Object record = iter.Current;
                    this.m_Data.Add(GetDataItem(record));
                   // PropertyDescriptorCollection pds = TypeDescriptor.GetProperties(recore);                    
                    
                }
            }
        }

        private ListItem GetDataItem(object dataItem)
        {
            ListItem li = new ListItem();
            if (dataItem is IDataRecord)
            {
                if (string.IsNullOrEmpty(this.m_DataValueField) || string.IsNullOrEmpty(this.m_DataTextField))
                {
                    throw new Exception("请设置控件的DataValueField和DataTextField属性");
                }
                li.Value = ((IDataRecord)dataItem)[this.m_DataValueField].ToString();
                li.Text = ((IDataRecord)dataItem)[this.m_DataTextField].ToString();
            }
            else if (dataItem is DataRowView)
            {
                if (string.IsNullOrEmpty(this.m_DataValueField) || string.IsNullOrEmpty(this.m_DataTextField))
                {
                    throw new Exception("请设置控件的DataValueField和DataTextField属性");
                }
                li.Value = ((DataRowView)dataItem)[this.m_DataValueField].ToString();
                li.Text = ((DataRowView)dataItem)[this.m_DataTextField].ToString();
            }
            else if (dataItem is IList)
            {
                IList listItem = (IList)dataItem;
                if (listItem.Count < 1)
                    throw new Exception("不支持此类型的数据源，数组至少为2维");
               
                li.Value = listItem[0].ToString();
                li.Text = listItem[1].ToString();
            }
            else
                li.Value = li.Text = dataItem.ToString();
            return li;
        }

    }

    

    ///// <summary>
    ///// PagerDesigner
    ///// </summary>
    //public class PagerDesigner : System.Web.UI.Design.ControlDesigner
    //{
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <returns></returns>
    //    public override string GetDesignTimeHtml()
    //    {
    //        return base.GetDesignTimeHtml();
    //    }

    //    /// <summary>
    //    /// Initialize
    //    /// </summary>
    //    /// <param name="component"></param>
    //    public override void Initialize(System.ComponentModel.IComponent component)
    //    {
    //        if (component is IPager)
    //        {
    //            IPager context = component as IPager;
    //            context.PageSize = 20;
    //            // context.ItemCount = 120;
    //            context.PageIndex++;
    //        }

    //        base.Initialize(component);
    //    }

    //}
}
