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
            case "adddelete": AddorDeleteStudentCourse(context); break;
            case "getlist": GetList(context); break;
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
    void AddorDeleteStudentCourse(HttpContext context)
    {
        string newCourse = WebUtility.InputText(context.Request.Form["addlist"], 1000);
        string deleteCourse = WebUtility.InputText(context.Request.Form["deletelist"], 1000);
        if (string.IsNullOrEmpty(newCourse) && string.IsNullOrEmpty(deleteCourse))
        {
            context.Response.Write("未选择课程。");
            return;
        }
        decimal cost;
        string strCost = context.Request.Form["regpay"];
        if (!string.IsNullOrEmpty(strCost))
        {
            try
            {
                cost = decimal.Parse(strCost);
            }
            catch (FormatException)
            {
                context.Response.Write("金额输入不正确。");
                return;
            }
        }
        else
        {
            context.Response.Write("请输入报名金额。");
            return;
        }
        string stu_id = WebUtility.InputText(context.Request.Form["stu_id"], 20);
        if (string.IsNullOrEmpty(stu_id))
        {
            context.Response.Write("学生ID获取失败，刷新页面后重试。");
            return;
        }
        string res = svcBLL.AddorDeleteStudentCourse(newCourse, deleteCourse, cost, stu_id);
        context.Response.Write(res);
    }
    void GetList(HttpContext context)
    {
        int PageSize = WebUtility.FilterParam(context.Request.Form["rows"]);
        int PageIndex = WebUtility.FilterParam(context.Request.Form["page"]);
        int subject_id = WebUtility.FilterParam(context.Request.Form["subject_id"]);
        int course_id = WebUtility.FilterParam(context.Request.Form["course_id"]);
        string stu_id = WebUtility.InputText(context.Request.Form["stu_id"], 20);
        string stu_name = WebUtility.InputText(context.Request.Form["stu_name"], 30);
        context.Response.Write(Lythen.Common.JsonEmitter.WriteResult(svcBLL.GetList(PageSize, PageIndex, subject_id, course_id, stu_id, stu_name, myrole_id),null));
    }
}