<%@ WebHandler Language="C#" Class="CommonHandler" %>

using System;
using System.Web;
using System.Web.SessionState;
using System.Data;

public class CommonHandler : IHttpHandler, IRequiresSessionState
{
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
            case "getlink": GetLink(context); break;
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
    void GetLink(HttpContext context)
    {
        int id = WebUtility.FilterParam(context.Request.QueryString["id"]);
        if (id == 0)
        {
            context.Response.Write("iderror");
            return;
        }
        string link = string.Format("{0},{1}", myrole_id, id);
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