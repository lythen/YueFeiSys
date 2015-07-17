<%@ WebHandler Language="C#" Class="SubjectHandler" %>

using System;
using System.Web;
using System.Data;
using System.IO;
using System.Web.SessionState;
public class SubjectHandler : IHttpHandler,IRequiresSessionState
{

    Admin adm = new Admin();
    Lythen.BLL.subject BLLSub = new Lythen.BLL.subject();
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        int myrole_id = adm.GetRoleId();
        if (myrole_id == 0)
        {
            context.Response.Write("nologin");
            return;
        }
        string type = context.Request.Form["type"];
        if (string.IsNullOrEmpty(type)) type = context.Request.QueryString["type"];
        switch (type)
        {
            case "getjson": getJson(context); break;
            case "edit": Edit(context); break;
            case "delete": Delete(context); break;
            case "deletelist": DeleteList(context); break;
            case "add": Add(context); break;
            case "getlist": GetList(context); break;
        }
    }
    void Edit(HttpContext context)
    {
        int sub_id = WebUtility.FilterParam(context.Request.Form["sub_id"]);
        string sub_title = WebUtility.InputText(context.Request.Form["title"], 100);
        int parent_id = WebUtility.FilterParam(context.Request.Form["parent_id"]);
        context.Response.Write(BLLSub.Update(sub_id, parent_id, sub_title));
        Global.DeleteSubjectCache();
    }
    void Delete(HttpContext context)
    {
        int id = WebUtility.FilterParam(context.Request.Form["id"]);
        if (BLLSub.Delete(id))
            context.Response.Write("success");
        else context.Response.Write("error");
        Global.DeleteSubjectCache();
    }
    void DeleteList(HttpContext context)
    {
        string ids = WebUtility.InputText(context.Request.Form["ids"], context.Request.Form["ids"].Length);
        if (String.IsNullOrEmpty(ids))
        {
            context.Response.Write(0);
            return;
        }
        ids = ids.Remove(ids.Length - 1, 1);
        int deRow = BLLSub.DeleteList(ids);
        Global.DeleteSubjectCache();
        context.Response.Write(deRow);
    }
    void getJson(HttpContext context)
    {
        context.Response.Write(BLLSub.GetListJson());
    }
    void GetList(HttpContext context)
    {
        int pageindex, pagesize;
        pageindex = WebUtility.FilterParam(context.Request.Form["page"]);
        pagesize = WebUtility.FilterParam(context.Request.Form["rows"]); ;
        //DataSet ds = new Lythen.BLL.subject().GetListByPage("", "Subject_id", pageindex, pagesize);
        DataSet ds = BLLSub.GetListForTable();
        DataTable dtSub = ds.Tables[0];
        DataTable dtCount = new DataTable("table");
        dtCount.Columns.Add(new DataColumn("total", typeof(int)));
        dtCount.Columns.Add(new DataColumn("rows", typeof(DataTable)));

        DataRow dr = dtCount.NewRow();
        dr[0] = ds.Tables[1].Rows[0][0];
        dr[1] = dtSub;
        dtCount.Rows.Add(dr);
        context.Response.Write(Lythen.Common.JsonEmitter.WriteResult(dtCount, null));
    }
    void Add(HttpContext context)
    {
        string parent_title = WebUtility.InputText(context.Request.Form["parent_title"], 100);
        string sub_title = WebUtility.InputText(context.Request.Form["sub_title"], 100);
        int parent_id = BLLSub.GetIdByText(parent_title.Trim());
        Global.DeleteSubjectCache();
        context.Response.Write(BLLSub.Add(parent_id, sub_title));
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}