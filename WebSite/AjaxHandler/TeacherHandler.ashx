<%@ WebHandler Language="C#" Class="TeacherHandler" %>

using System;
using System.Web;
using Lythen;
public class TeacherHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.Write("Hello World");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
    public void Add(HttpContext context)
    {
        string name = context.Request.Form["name"];
        string age = context.Request.Form["age"];
        string sex = context.Request.Form["sex"];
        string phone = context.Request.Form["phone"];
        string email = context.Request.Form["email"];
        string info = context.Request.Form["info"];
        string role = context.Request.Form["role"];
        if (String.IsNullOrEmpty(name) ||
            String.IsNullOrEmpty(age) ||
            String.IsNullOrEmpty(sex) ||
            String.IsNullOrEmpty(phone) ||
            String.IsNullOrEmpty(email) ||
            String.IsNullOrEmpty(info) ||
            String.IsNullOrEmpty(role))
        {
            context.Response.Write("msgempty");
            return;
        }
        Lythen.Model.teacher model = new Lythen.Model.teacher();
    }
}