﻿<%@ WebHandler Language="C#" Class="CourseHandler" %>

using System;
using System.Web;
using System.Data;
using System.Web.SessionState;
public class CourseHandler : IHttpHandler, IRequiresSessionState
{
    Admin adm = new Admin();
    Lythen.BLL.course cBLL = new Lythen.BLL.course();
    int myrole_id;
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        Lythen.BLL.subject BLLSub = new Lythen.BLL.subject();
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
            case "add": Add(context); break;
            case "getlist": GetJsonList(context); break;
            case "edit": Edit(context); break;
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
        int school_id = WebUtility.FilterParam(context.Request.Form["school_id"]);
        context.Response.Write(Lythen.Common.JsonEmitter.WriteResult(cBLL.GetListForTable(subject_id, teacher_id, status, myrole_id, adm.GetTeacherId(), school_id), null));
    }
    void Add(HttpContext context)
    {
        int subject_id = WebUtility.FilterParam(context.Request.Form["sub_id"]);
        if (subject_id == 0)
        {
            context.Response.Write("请选择科目。");
            return;
        }
        string title = WebUtility.InputText(context.Request.Form["title"], 50);
        if (string.IsNullOrEmpty(title))
        {
            context.Response.Write("请填写课程标题。");
            return;
        }
        if (cBLL.Exists(subject_id, title))
        {
            context.Response.Write("hasname");
            return;
        }
        decimal cost;
        try
        {
            cost = decimal.Parse(context.Request.Form["cost"]);
        }
        catch (FormatException)
        {
            context.Response.Write("请输入正确的课程价格。");
            return;
        }
        if (cost == 0)
        {
            context.Response.Write("请输入课程价格。");
            return;
        }
        string datainfo = WebUtility.InputText(context.Request.Form["data"], 1000);
        int teacher_id = WebUtility.FilterParam(context.Request.Form["teacher"]);
        if (teacher_id == 0)
        {
            context.Response.Write("请选择任课老师");
            return;
        }
        string cinfo = WebUtility.InputText(context.Request.Form["info"], 5000);
        string status = WebUtility.InputText(context.Request.Form["status"],1);
        if (cBLL.Add(1, cost, datainfo, cinfo, status, subject_id, teacher_id, title)) context.Response.Write("success");
        else context.Response.Write("添加失败。");
    }
    void Edit(HttpContext context)
    {
        decimal cost;
        try
        {
            cost = decimal.Parse(context.Request.Form["cost"]);
        }
        catch (FormatException)
        {
            context.Response.Write("金额输入不正确，请重新输入。");
            return;
        }
        int c_id = WebUtility.FilterParam(context.Request.Form["c_id"]);
        int school_id = WebUtility.FilterParam(context.Request.Form["school"]);
        int t_id = WebUtility.FilterParam(context.Request.Form["t_id"]);
        int sub_id = WebUtility.FilterParam(context.Request.Form["sub_id"]);
        string info = WebUtility.InputText(context.Request.Form["info"], 5000);
        string title = WebUtility.InputText(context.Request.Form["c_title"], 50);
        context.Response.Write(cBLL.Edit(c_id, t_id, sub_id, school_id, title, info, cost));
    }
    void Delete()
    {
    }
    void GetJsonList(HttpContext context)
    {
        int subject_id = WebUtility.FilterParam(context.Request.QueryString["subject_id"]);
        context.Response.Write(cBLL.GetJsonList(subject_id));
    }
}