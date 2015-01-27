<%@ WebHandler Language="C#" Class="SubjectComboTreeHandler" %>

using System;
using System.Web;
using System.IO;

public class SubjectComboTreeHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string path = context.Server.MapPath("~/Scripts/city_data.txt");
        StreamReader sr = new StreamReader(path);
        string str = sr.ReadToEnd();
        sr.Close();
        context.Response.ContentType = "text/json;charset=UTF-8;";
        context.Response.Write(str);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}