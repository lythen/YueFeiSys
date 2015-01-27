<%@ WebHandler Language="C#" Class="LoginHandler" %>

using System;
using System.Web;
using System.Web.Security;
using Lythen.Common;
using System.Web.SessionState;
public class LoginHandler : IHttpHandler, IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string type = context.Request.Form["type"];
        if (type == "login")
            context.Response.Write(Login(context).ToString().ToLower());
        else Logout(context);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
    private bool Login(HttpContext context)
    {
        string User_Name = context.Request.Form["username"];
        string Password = context.Request.Form["password"];
        if (String.IsNullOrEmpty(User_Name) || String.IsNullOrEmpty(Password))
            return false;
        User_Name = PageValidate.InputText(User_Name.Trim(), 20);
        Password = FormsAuthentication.HashPasswordForStoringInConfigFile(PageValidate.InputText(Password.Trim(), 16), "MD5");
        Password = FormsAuthentication.HashPasswordForStoringInConfigFile(Password, "MD5");
        bool isRight = new Lythen.BLL.teacher().Login(User_Name, Password);
        if (isRight)
            context.Session["username"] = User_Name;
        return isRight;
    }
    private void Logout(HttpContext context)
    {
        context.Session["username"] = "";
    }
}