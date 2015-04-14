<%@ WebHandler Language="C#" Class="SubjectHandler" %>

using System;
using System.Web;
using System.Data;
using System.IO;
using System.Web.SessionState;
public class SubjectHandler : IHttpHandler,IRequiresSessionState
{

    Admin adm = new Admin();
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        Lythen.BLL.subject BLLSub = new Lythen.BLL.subject();
        int myrole_id = adm.GetRoleId();
        if (myrole_id == 0)
        {
            context.Response.Write("nologin");
            return;
        }
        string type = context.Request.Form["type"];
        if (type == "edit")
        {
            int sub_id = WebUtility.FilterParam(context.Request.Form["id"]);
            string parent_title = WebUtility.InputText(context.Request.Form["parent_title"],100);
            string sub_title = WebUtility.InputText(context.Request.Form["sub_title"], 100);
            int parent_id = BLLSub.GetIdByText(parent_title.Trim());
            context.Response.Write(BLLSub.Update(sub_id, parent_id, sub_title));
            Global.DeleteSubjectCache();
            return;
        }
        else if (type == "delete")
        {
            int id = WebUtility.FilterParam(context.Request.Form["id"]);
            if (BLLSub.Delete(id))
                context.Response.Write("success");
            else context.Response.Write("error");
            Global.DeleteSubjectCache();
            return;
        }
        else if (type == "deletelist")
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
            return;
        }
        else if (type == "add")
        {
            string parent_title = WebUtility.InputText(context.Request.Form["parent_title"],100);
            string sub_title = WebUtility.InputText(context.Request.Form["sub_title"], 100);
            int parent_id = BLLSub.GetIdByText(parent_title.Trim());
            Global.DeleteSubjectCache();
            context.Response.Write(BLLSub.Add(parent_id, sub_title));
            return;
        }
        int pageindex, pagesize, size;
        pageindex = WebUtility.FilterParam(context.Request.Form["pageindex"]);
        pagesize = WebUtility.FilterParam(context.Request.Form["pagesize"]); ;
        size = WebUtility.FilterParam(context.Request.Form["size"]);
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
    void Edit()
    {
    }
    void Delete()
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