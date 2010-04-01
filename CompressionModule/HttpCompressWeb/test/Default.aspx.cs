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

public partial class test_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string realPath = Request.Path.Remove(0, Request.ApplicationPath.Length);
        realPath = (realPath.StartsWith("/")) ? realPath.Remove(0, 1) : realPath;
        lblTest.Text = realPath + "<br/>";
    }
}
