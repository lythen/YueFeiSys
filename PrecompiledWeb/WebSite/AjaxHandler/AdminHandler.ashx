<%@ WebHandler Language="C#" Class="AdminHandler" %>

using System;
using System.Web;
using System.Web.SessionState;
public class AdminHandler : IHttpHandler, IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string type = context.Request.Form["type"];
        if (type == "check")
            if (context.Session["username"] != null && context.Session["username"].ToString() != "") context.Response.Write("true");
            else context.Response.Write("nologin");

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}