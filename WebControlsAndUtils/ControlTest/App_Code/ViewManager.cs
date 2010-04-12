using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

/// <summary>
/// ViewManager 的摘要说明
/// </summary>
public class ViewManager<T> where T : UserControl
{
    private Page m_pageHolder;

    public T LoadViewControl(string path)
    {
        this.m_pageHolder = new Page();
        return (T)this.m_pageHolder.LoadControl(path);
    }

    public string RenderView(T control)
    {
        StringWriter output = new StringWriter();

        this.m_pageHolder.Controls.Add(control);
        HttpContext.Current.Server.Execute(this.m_pageHolder, output, false);

        return output.ToString();
    }
}

