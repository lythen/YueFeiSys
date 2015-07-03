<%@ WebHandler Language="C#" Class="StudentVsCourseHandler" %>

using System;
using System.Web;
using System.Web.SessionState;
public class StudentVsCourseHandler : IHttpHandler, IRequiresSessionState
{
    Admin adm = new Admin();
    Lythen.BLL.stu_vs_course svcBLL = new Lythen.BLL.stu_vs_course();
    int myrole_id;
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        myrole_id = adm.GetRoleId();
        if (myrole_id == 0)
        {
            context.Response.Write("nologin");
            return;
        }
        string type = context.Request.Form["type"];
        if (string.IsNullOrEmpty(type)) type = context.Request.QueryString["type"];
        switch (type)
        {
            case "gettable": GetTable(context); break;
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
    void GetTable(HttpContext context)
    {
        string stu_id = WebUtility.InputText(context.Request.Form["stu_id"], 20);
        context.Response.Write(Lythen.Common.JsonEmitter.WriteResult(svcBLL.GetStudentCourse(stu_id),null));
    }
}