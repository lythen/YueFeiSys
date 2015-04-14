<%@ WebHandler Language="C#" Class="RoleHandler" %>

using System;
using System.Web;
using System.Web.SessionState;
public class RoleHandler : IHttpHandler,IRequiresSessionState {
    Lythen.BLL.sys_role BLLRole = new Lythen.BLL.sys_role();
    Admin adm = new Admin();
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string type = context.Request.Form["type"];
        switch (type)
        {
            case "add": Add(context); break;
            case "edit": Edit(context); break;
            case "delete": Delete(context); break;
            case "getlist": GetList(context); break;
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
    void Add(HttpContext context)
    {
        string parent_title = WebUtility.InputText(context.Request.Form["parent_title"], 30);
        if (String.IsNullOrEmpty(parent_title))
        {
            context.Response.Write("noparent");
            return;
        }
        string role_name = WebUtility.InputText(context.Request.Form["role_name"], 30);
        if (String.IsNullOrEmpty(role_name))
        {
            context.Response.Write("noname");
            return;
        }
        int myrole_id = WebUtility.FilterParam(context.Session["role_id"].ToString());
        if (myrole_id == 0)
        {
            context.Response.Write("nologin");
            return;
        }
        context.Response.Write(BLLRole.Add(myrole_id,role_name, parent_title));
    }
    void Edit(HttpContext context)
    {
        int edrole_id = WebUtility.FilterParam(context.Request.Form["role_id"]);
        if (edrole_id == 0)
        {
            context.Response.Write("iderror");
            return;
        }
        string parent_title = WebUtility.InputText(context.Request.Form["parent_title"], 30);
        if (String.IsNullOrEmpty(parent_title))
        {
            context.Response.Write("noparent");
            return;
        }
        string role_name = WebUtility.InputText(context.Request.Form["role_name"], 30);
        if (String.IsNullOrEmpty(role_name))
        {
            context.Response.Write("noname");
            return;
        }
        int myrole_id = adm.GetRoleId();
        if (myrole_id == 0)
        {
            context.Response.Write("nologin");
            return;
        }
        context.Response.Write(BLLRole.Edit(myrole_id, edrole_id, role_name, parent_title));
    }
    void Delete(HttpContext context)
    {
        int derole_id = WebUtility.FilterParam(context.Request.Form["role_id"]);
        if (derole_id == 0)
        {
            context.Response.Write("iderror");
            return;
        }
        int myrole_id = adm.GetRoleId();
        if (myrole_id == 0)
        {
            context.Response.Write("nologin");
            return;
        }
        context.Response.Write(BLLRole.Delete(myrole_id, derole_id));
    }
    void GetList(HttpContext context)
    {
        int myrole_id = adm.GetRoleId();
        if (myrole_id == 0)
        {
            context.Response.Write("nologin");
            return;
        }
        context.Response.ContentType = "text/json;charset=UTF-8;";
        context.Response.Write(BLLRole.GetJsonList(myrole_id));
    }
}