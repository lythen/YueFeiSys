<%@ WebHandler Language="C#" Class="SchoolHandler" %>

using System;
using System.Web;
using System.Web.SessionState;

public class SchoolHandler : IHttpHandler, IRequiresSessionState
{
    Lythen.BLL.schools bllSc = new Lythen.BLL.schools();
    Admin adm = new Admin();
    int myrole_id;
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        myrole_id = adm.GetRoleId();
        if (myrole_id == 0)
        {
            context.Response.Write("nopower");
            return;
        }
        string type = context.Request.Form["type"];
        if (string.IsNullOrEmpty(type))
            type = context.Request.QueryString["type"];
        switch (type)
        {
            case "getjson": GetJson(context); break;
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
    void GetJson(HttpContext context)
    {
        context.Response.Write(bllSc.GetListJson());
        return;
    }
}