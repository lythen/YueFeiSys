<%@ WebHandler Language="C#" Class="StudentHandler" %>

using System;
using System.Web;
using System.Web.SessionState;

public class StudentHandler : IHttpHandler, IRequiresSessionState
{
    Lythen.BLL.student stuBLL = new Lythen.BLL.student();
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
            case "add": add(context); break;
            case "getlist": getList(context); break;
            case "getdetail": getDetail(context); break;
            case "edit": edit(context); break;
            case "deletelist": delete(context); break;
        }
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

        string parent_name = WebUtility.InputText(context.Request.Form["pname"], 32);
        string parent_phone = WebUtility.InputText(context.Request.Form["pphone"], 12);
        string parent_email = WebUtility.InputText(context.Request.Form["pemail"], 150);
        string parent_dept = WebUtility.InputText(context.Request.Form["pdep"], 100);
        string address = WebUtility.InputText(context.Request.Form["paddress"], 250);

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
        stuModel.parent_dep = parent_dept;
        stuModel.parent_mobile = parent_phone;
        stuModel.parent_name = parent_name;
        stuModel.stu_grade = grade;
        stuModel.stu_name = name;
        stuModel.stu_school_id = school;
        stuModel.stu_Status = true;
        stuModel.parent_email = parent_email;
        stuModel.stu_sex = sex;
        stuModel.address = address;
        stuModel.stu_age = age;
        string stu_id = stuBLL.AddStudent(stuModel);
        if (string.IsNullOrEmpty(stu_id))
        {
            context.Response.Write("添加学生失败。");
            return;
        }
        //添加报名科目
        string courses = WebUtility.InputText(context.Request.Form["regsub"], 1000);
        if (string.IsNullOrEmpty(courses) || courses.Length == 0)
        {
            context.Response.Write("添加学生成功，请手动报名课程。");
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
                context.Response.Write("学生添加成功，但是金额添加失败，报名失败，请手动报名。");
                return;
            }
        }
        else
        {
            context.Response.Write("学生添加成功，但是金额添加失败，报名失败，请手动报名。");
            return;
        }
        if (new Lythen.BLL.stu_vs_course().AddStudentCourse(courses, cost, stu_id))
            context.Response.Write("success");
        else context.Response.Write("学生添加成功，但是报名失败，请手动报名。");
        
    }
    void edit(HttpContext context)
    {
        string stu_id = WebUtility.InputText(context.Request.Form["stu_id"], 20);
        Lythen.Model.student stuModel = stuBLL.GetModel(stu_id);
        if (stuModel == null)
        {
            context.Response.Write("学生信息查询出错或者学生被删除。");
            return;
        }
        string name = WebUtility.InputText(context.Request.Form["name"], 32);
        int age = WebUtility.FilterParam(context.Request.Form["age"]);
        string sex = WebUtility.InputText(context.Request["sex"], 1);
        int school = WebUtility.FilterParam(context.Request.Form["school"]);
        int grade = WebUtility.FilterParam(context.Request.Form["grade"]);

        string parent_name = WebUtility.InputText(context.Request.Form["pname"], 32);
        string parent_phone = WebUtility.InputText(context.Request.Form["pphone"], 12);
        string parent_email = WebUtility.InputText(context.Request.Form["pemail"], 150);
        string parent_dept = WebUtility.InputText(context.Request.Form["pdep"], 100);
        string address = WebUtility.InputText(context.Request.Form["paddress"], 250);

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
        stuModel.parent_dep = parent_dept;
        stuModel.parent_mobile = parent_phone;
        stuModel.parent_name = parent_name;
        stuModel.stu_grade = grade;
        stuModel.stu_name = name;
        stuModel.stu_school_id = school;
        stuModel.stu_Status = true;
        stuModel.parent_email = parent_email;
        stuModel.stu_sex = sex;
        stuModel.address = address;
        stuModel.stu_age = age;
        if (stuBLL.Update(stuModel))
            context.Response.Write("success");
        else context.Response.Write("修改失败。");
    }
    void delete(HttpContext context)
    {
        string ids = WebUtility.InputText(context.Request.Form["ids"], 5000);
        context.Response.Write(stuBLL.DeleteStudent(ids, myrole_id));
    }
    void getList(HttpContext context)
    {
        int PageSize = WebUtility.FilterParam(context.Request.Form["rows"]);
        int PageIndex = WebUtility.FilterParam(context.Request.Form["page"]);
        int school_id = WebUtility.FilterParam(context.Request.Form["school_id"]);
        int grade = WebUtility.FilterParam(context.Request.Form["grade"]);
        string sex = WebUtility.InputText(context.Request.Form["sex"], 1);
        string stu_name = WebUtility.InputText(context.Request.Form["stu_name"], 30);
        string parent_name = WebUtility.InputText(context.Request.Form["parent_name"], 30);
        context.Response.Write(Lythen.Common.JsonEmitter.WriteResult(stuBLL.GetStudentList(PageSize, PageIndex,school_id,grade,sex,stu_name,parent_name), null));
    }
    void getDetail(HttpContext context)
    {
        string stu_id = WebUtility.InputText(context.Request.Form["stu_id"], 20);
        context.Response.Write(Lythen.Common.JsonEmitter.WriteResult(stuBLL.GetStudent(stu_id), null));
    }
}