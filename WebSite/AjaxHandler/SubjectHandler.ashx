<%@ WebHandler Language="C#" Class="SubjectHandler" %>

using System;
using System.Web;
using System.Data;
using System.IO;
public class SubjectHandler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string type = context.Request.Form["type"];
        if (type == "edit")
        {
            Edit();
            return;
        }
        else if (type == "delete")
        {
            Delete();
            return;
        }
        else if (type == "deletelist")
        {
            DeleteList();
            return;
        }
        else if (type == "add")
        {
            int parent_id = WebUtility.FilterParam(context.Request.Form["parent_id"]);
            string sub_title = WebUtility.InputText(context.Request.Form["sub_title"], 100);
            Global.DeleteSubjectCache();
            context.Response.Write(new Lythen.BLL.subject().Add(parent_id, sub_title));
            return;
        }
        int pageindex, pagesize, size;
        pageindex = WebUtility.FilterParam(context.Request.Form["pageindex"]);
        pagesize = WebUtility.FilterParam(context.Request.Form["pagesize"]); ;
        size = WebUtility.FilterParam(context.Request.Form["size"]);
        DataSet ds = new Lythen.BLL.subject().GetListByPage("", "Subject_id", pageindex, pagesize);
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
    void Edit()
    {
    }
    void Delete()
    {
    }
    void DeleteList()
    {
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}