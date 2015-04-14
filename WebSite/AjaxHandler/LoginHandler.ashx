<%@ WebHandler Language="C#" Class="LoginHandler" %>

using System;
using System.Web;
using System.Web.Security;
using Lythen.Common;
using System.Web.SessionState;
using System.Data;
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
        Lythen.BLL.teacher BLLTe = new Lythen.BLL.teacher();
        bool isRight = new Lythen.BLL.teacher().Login(User_Name, Password);
        if (isRight)
        {
            context.Session["username"] = User_Name;
            DataTable dtTe = BLLTe.GetTeacherRole(User_Name).Tables[0];
            if (dtTe.Rows.Count == 0) return false;
            foreach (DataRow dr in dtTe.Rows)
            {
                context.Session["id"] = (int)dr["Teacher_id"];
                context.Session["realname"] = dr["Teacher_realname"].ToString();
                context.Session["role_id"] = (int)dr["Teacher_role"];
                context.Session["role_name"] = dr["Role_name"].ToString();
            }
        }
        return isRight;
    }
    private void Logout(HttpContext context)
    {
        context.Session["username"] = "";
    }
}