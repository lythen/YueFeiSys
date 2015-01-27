<%@ WebHandler Language="C#" Class="CourseHandler" %>

using System;
using System.Web;
using System.Data;
public class CourseHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.Write("Hello World");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
    public DataTable GetTable(string sub_id)
    {
        DataTable dt = new DataTable();
        dt.TableName = "rows";
        return dt;
        
    }
}