<%@ WebHandler Language="C#" Class="StudentHandler" %>

using System;
using System.Web;

public class StudentHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.Write("Hello World");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
    void add(HttpContext context)
    {
        Lythen.Model.student stuModel = new Lythen.Model.student();
        string name = WebUtility.InputText(context.Request.Form["name"], 32);
        int age = WebUtility.FilterParam(context.Request.Form["age"]);
        string sex = WebUtility.InputText(context.Request["sex"], 1);
        int school = WebUtility.FilterParam(context.Request.Form["school"]);
        int grade = WebUtility.FilterParam(context.Request.Form["grade"]);

        string parent_name = WebUtility.InputText(context.Request.Form["parent_name"], 32);
        string parent_phone = WebUtility.InputText(context.Request.Form["parent_phone"], 12);
        string parent_email = WebUtility.InputText(context.Request.Form["parent_email"], 150);
        string parent_dept = WebUtility.InputText(context.Request.Form["parent_dept"], 100);
        string address = WebUtility.InputText(context.Request.Form["address"], 250);

        if (string.IsNullOrEmpty(name)
            || string.IsNullOrEmpty(sex)
            || school == 0
            || string.IsNullOrEmpty(parent_name)
            || string.IsNullOrEmpty(parent_phone)
            || string.IsNullOrEmpty(address)
            || age == 0
            || grade == 0)
        {
            context.Response.Write("请把信息补充完整。");
            return;
        }
        stuModel.Parent_dep = parent_dept;
        stuModel.Parent_mobile = parent_phone;
        stuModel.Parent_name = parent_name;
        stuModel.Stu_grade = grade;
        stuModel.Stu_name = name;
        stuModel.Stu_school_id = school;
        stuModel.Stu_Status = true;
        
    }
    void edit(HttpContext context)
    {
    }
    void delete(HttpContext context)
    {
    }
    void getList(HttpContext context)
    {
    }
}