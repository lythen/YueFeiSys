<%@ WebHandler Language="C#" Class="RoleHandler" %>

using System;
using System.Web;
using System.Web.SessionState;
using System.Data;
public class RoleHandler : IHttpHandler,IRequiresSessionState {
    Lythen.BLL.sys_role BLLRole = new Lythen.BLL.sys_role();
    Admin adm = new Admin();
    int myrole_id;
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        myrole_id = adm.GetRoleId();
        if (myrole_id == 0)
        {
            context.Response.Write("nologin");
            return;
        }
        string type = context.Request.QueryString["type"];
        switch (type)
        {
            case "add": Add(context); break;
            case "edit": Edit(context); break;
            case "delete": Delete(context); break;
            case "getlist": GetList(context); break;
            case "gettable": GetTable(context); break;
            case "getlink": GetLink(context); break;
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
    void GetTable(HttpContext context)
    {
        int size = WebUtility.FilterParam(context.Request.Form["size"]);
        DataTable dtRole = BLLRole.GetManagerRoleByCache(myrole_id);
        
        DataTable dtCount = new DataTable("table");
        dtCount.Columns.Add(new DataColumn("total", typeof(int)));
        dtCount.Columns.Add(new DataColumn("rows", typeof(DataTable)));

        DataRow dr = dtCount.NewRow();
        dr[0] = dtRole.Rows.Count;
        dr[1] = dtRole;
        dtCount.Rows.Add(dr);
        context.Response.Write(Lythen.Common.JsonEmitter.WriteResult(dtCount, null));
    }
    void GetLink(HttpContext context)
    {
        int role_id = WebUtility.FilterParam(context.Request.QueryString["role_id"]);
        if (role_id == 0)
        {
            context.Response.Write("iderror");
            return;
        }
        string link = string.Format("{0},{1}", myrole_id, role_id);
        try
        {
            context.Response.Write(Lythen.Common.DEncrypt.DESEncrypt.Encrypt(link));
        }
        catch
        {
            context.Response.Write("error");
        }
    }
}