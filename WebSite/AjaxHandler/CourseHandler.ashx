<%@ WebHandler Language="C#" Class="CourseHandler" %>

using System;
using System.Web;
using System.Data;
using System.Web.SessionState;
public class CourseHandler : IHttpHandler, IRequiresSessionState
{
    Admin adm = new Admin();
    Lythen.BLL.course cBLL = new Lythen.BLL.course();
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        Lythen.BLL.subject BLLSub = new Lythen.BLL.subject();
        int myrole_id = adm.GetRoleId();
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
        context.Response.ContentType = "text/json;charset=UTF-8;";
        int subject_id = WebUtility.FilterParam(context.Request.Form["subject_id"]);
        int teacher_id = WebUtility.FilterParam(context.Request.Form["teacher_id"]);
        string status = WebUtility.InputText(context.Request.Form["status"], 1);
        context.Response.Write(Lythen.Common.JsonEmitter.WriteResult(cBLL.GetListForTable(subject_id, teacher_id, status), null));
    }
    void Add()
    {
        Lythen.Model.course model = new Lythen.Model.course();
    }
    void Edit()
    {
    }
    void Delete()
    {
    }
}