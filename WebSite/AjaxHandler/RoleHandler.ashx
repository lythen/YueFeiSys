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
            DataTable dtRole = new DataTable();
            dtRole.Columns.Add(new DataColumn("error", typeof(string)));
            DataRow dr1 = dtRole.NewRow();
            dr1[0] = "nologin";
            dtRole.Rows.Add(dr1);
            DataTable dtCount = new DataTable("table");
            dtCount.Columns.Add(new DataColumn("total", typeof(int)));
            dtCount.Columns.Add(new DataColumn("rows", typeof(DataTable)));

            DataRow dr = dtCount.NewRow();
            dr[0] = 1;
            dr[1] = dtRole;
            dtCount.Rows.Add(dr);
            context.Response.Write(Lythen.Common.JsonEmitter.WriteResult(dtCount, null));
            return;
        }
        string type = context.Request.QueryString["type"];
        if (String.IsNullOrEmpty(type)) type = context.Request.Form["type"];
        switch (type)
        {
            case "add": Add(context); break;
            case "edit": Edit(context); break;
            case "delete": Delete(context); break;
            case "getlist": GetList(context); break;
            case "gettable": GetTable(context); break;
            case "getdetail": GetDetail(context); break;
            case "check": CheckRole(context); break;
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
    void Add(HttpContext context)
    {
        int parent_id = WebUtility.FilterParam(context.Request.Form["parent_id"]);
        if (parent_id==0)
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
        context.Response.Write(BLLRole.Add(myrole_id, role_name, parent_id));
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
        bool istxt = WebUtility.InputText(context.Request.QueryString["istxt"], 5).ToLower() == "true";
        context.Response.ContentType = "text/json;charset=UTF-8;";
        context.Response.Write(BLLRole.GetJsonList(myrole_id, istxt));
    }
    void GetTable(HttpContext context)
    {
        int role_id = WebUtility.FilterParam(context.Request.Form["role_id"]);
        int PageSize = WebUtility.FilterParam(context.Request.Form["rows"]);
        int PageIndex = WebUtility.FilterParam(context.Request.Form["page"]);
        if (role_id == 0) role_id = myrole_id;
        context.Response.Write(Lythen.Common.JsonEmitter.WriteResult(BLLRole.GetRoleTable(role_id, PageIndex, PageSize), null));
    }
    
    void GetDetail(HttpContext context)
    {
        string link = context.Request.Form["link"];
        string[] ids;
        int myid, role_id;
        try
        {
            ids = Lythen.Common.DEncrypt.DESEncrypt.Decrypt(link).Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
        }
        catch (Exception)
        {
            context.Response.Write("error");
            return;
        }
        if (ids.Length != 2)
        {
            context.Response.Write("error");
            return;
        }
        myid = WebUtility.FilterParam(ids[0]);
        role_id = WebUtility.FilterParam(ids[1]);
        if (myid != adm.GetRoleId())
        {
            context.Response.Write("nopower");
            return;
        }
        if (role_id == 0)
        {
            context.Response.Write("iderror");
            return;
        }
        DataTable dt = BLLRole.GetList(myrole_id, role_id);
        if (dt == null)
        {
            context.Response.Write("nodata");
            return;
        }
        context.Response.Write(Lythen.Common.JsonEmitter.WriteResult(dt, null));
    }
    void CheckRole(HttpContext context)
    {
        string check = context.Request.Form["check"];
        bool isCheck = false;
        switch (check)
        {
            case "pay": isCheck = adm.isPayAdmin(); break;
            case "sa": isCheck = adm.isSuperAdmin(); break;
            case "parent": isCheck = adm.isParent(); break;
        }
        if (isCheck) context.Response.Write("success");
        else context.Response.Write("error");
    }
}