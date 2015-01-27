<%@ WebHandler Language="C#" Class="SubjectHandler" %>

using System;
using System.Web;
using System.Data;
using System.IO;
public class SubjectHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //string path = context.Server.MapPath("~/Scripts/tablejson.txt");
        //StreamReader sr = new StreamReader(path);
        //string str = sr.ReadToEnd();
        //sr.Close();
        //context.Response.ContentType = "text/json;charset=UTF-8;";
        //context.Response.Write(str);
        
        context.Response.Write(Lythen.Common.JsonEmitter.WriteResult(GetTable(""),null));
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
    public DataTable GetTable(string sub_id)
    {
        DataTable dt = new DataTable("rows");
        dt.Columns.Add(new DataColumn("sub_id", typeof(int)));
        dt.Columns.Add(new DataColumn("sub_title", typeof(string)));
        dt.Columns.Add(new DataColumn("sub_parent", typeof(string)));
        DataRow dr;
        for (int i = 0; i < 10; i++)
        {
            dr = dt.NewRow();
            dr[0] = i+1;
            dr[1] = "标题题"+i+"1";
            dr[2] = "没有";
            dt.Rows.Add(dr);
        }
        DataTable dt2 = new DataTable("table");
        dt2.Columns.Add(new DataColumn("total", typeof(int)));
        dt2.Columns.Add(new DataColumn("rows", typeof(DataTable)));
        dr = dt2.NewRow();
        dr[0] = 100;
        dr[1] = dt;
        dt2.Rows.Add(dr);
        return dt2;

    }
}