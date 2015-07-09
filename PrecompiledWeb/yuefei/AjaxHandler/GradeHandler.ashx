<%@ WebHandler Language="C#" Class="GradeHandler" %>

using System;
using System.Web;
using System.Web.SessionState;
public class GradeHandler : IHttpHandler, IRequiresSessionState
{
    Lythen.BLL.sys_grade bllSg = new Lythen.BLL.sys_grade();
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
        context.Response.Write(bllSg.GetListJson());
        return;
    }
}