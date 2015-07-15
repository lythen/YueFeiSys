﻿<%@ WebHandler Language="C#" Class="StudentSchoolHandler" %>

using System;
using System.Web;
using System.Web.SessionState;
public class StudentSchoolHandler : IHttpHandler,IRequiresSessionState {

    Lythen.BLL.sys_stu_school bllSc = new Lythen.BLL.sys_stu_school();
    Admin adm = new Admin();
    int myrole_id;
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        myrole_id = adm.GetRoleId();
        if (myrole_id == 0)
        {
            context.Response.Write("nopower");
            return;
        }
        string type = context.Request.Form["type"];
        if (string.IsNullOrEmpty(type))
            type = context.Request.QueryString["type"];
        switch (type)
        {
            case "getjson": GetJson(context); break;
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
    void GetJson(HttpContext context)
    {
        context.Response.Write(bllSc.GetListJson());
        return;
    }
}