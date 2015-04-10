<%@ WebHandler Language="C#" Class="SubjectComboTreeHandler" %>

using System;
using System.Web;
using System.IO;
using System.Data;
using System.Text;
public class SubjectComboTreeHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string path = context.Server.MapPath("~/DataCache/subject.txt");
        StringBuilder sb = new StringBuilder();
        context.Response.ContentType = "text/json;charset=UTF-8;";
        if (!File.Exists(path))
        {
            sb.Append("[{\"id\":0,\"text\":\"请选择科目\",\"children\":[");
            DataTable dtSub = new Lythen.BLL.subject().GetList("").Tables[0];
            if (dtSub.Rows.Count == 0)
            {
                sb.Append("	]}]");
                context.Response.Write(sb.ToString());
            }
            else
            {
                DataRow[] drs = dtSub.Select("Subject_parent=0");
                int len = drs.Length;
                foreach (DataRow dr in drs)
                {
                    len--;
                    WriteNode(dr, dtSub, sb,len);
                }
            }
            sb.Append("]}]");
            StreamWriter sw = new StreamWriter(path);
            sw.Write(sb.ToString());
            sw.Flush();
            sw.Close();
            context.Response.Write(sb.ToString());
        }
        else
        {

            StreamReader sr = new StreamReader(path);
            string str = sr.ReadToEnd();
            sr.Close();
            context.Response.Write(str);
        }
    }
    void WriteNode(DataRow dr,DataTable dtsub,StringBuilder sb,int len)
    {
        sb.Append("{\"id\":").Append(dr["Subject_id"]).Append(",\"text\":\"").Append(dr["Subject_title"]).Append("\",\"children\":[");
        DataRow[] drs = dtsub.Select("Subject_parent=" + dr["Subject_id"].ToString());
        if (drs.Length == 0)
        {
            sb.Append("]}");
            if (len > 0) sb.Append(",");
            return;
        }
        int lenc = drs.Length;
        foreach (DataRow drc in drs)
        {
            lenc--;
            WriteNode(drc, dtsub, sb,lenc);
        }
        sb.Append("]}");
        if (len > 0) sb.Append(",");
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}