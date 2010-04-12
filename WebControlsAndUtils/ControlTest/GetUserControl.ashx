<%@ WebHandler Language="C#" Class="GetUserControl" %>

using System;
using System.Web;

public class GetUserControl : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";       

        ViewManager<ItemComments> viewManager = new ViewManager<ItemComments>();
        ItemComments control = viewManager.LoadViewControl("~/ItemComments.ascx");

        //control.PageIndex = Int32.Parse(context.Request.QueryString["page"]);
        //control.PageSize = 3;

        context.Response.Write(viewManager.RenderView(control));

    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}