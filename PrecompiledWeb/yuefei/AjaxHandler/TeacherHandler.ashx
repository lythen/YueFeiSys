<%@ WebHandler Language="C#" Class="TeacherHandler" %>

using System;
using System.Web;
using Lythen;
using System.Data;
using System.Web.SessionState;
using System.Web.Security;
public class TeacherHandler : IHttpHandler, IRequiresSessionState
{
    Lythen.BLL.teacher bllTe = new Lythen.BLL.teacher();
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
            case "getlist": getlist(context); break;
            case "add": Add(context); break;
            case "getdetail": GetDetail(context); break;
            case "edit": Edit(context); break;
            case "getjson": GetJson(context); break;
        }
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
    private void getlist(HttpContext context)
    {
        DataTable dtTeacher = bllTe.GetTeacherList().Tables[0];

        DataTable dtCount = new DataTable("table");
        dtCount.Columns.Add(new DataColumn("total", typeof(int)));
        dtCount.Columns.Add(new DataColumn("rows", typeof(DataTable)));

        DataRow dr = dtCount.NewRow();
        dr[0] = dtTeacher.Rows.Count;
        dr[1] = dtTeacher;
        dtCount.Rows.Add(dr);
        context.Response.Write(Lythen.Common.JsonEmitter.WriteResult(dtCount, null));
    }
    private void Add(HttpContext context)
    {
        string name = WebUtility.InputText(context.Request.Form["realname"], 50);
        string username = WebUtility.InputText(context.Request.Form["username"],32);
        string sex = WebUtility.InputText(context.Request.Form["sex"],1);
        string phone = WebUtility.InputText(context.Request.Form["phone"],20);
        string email = WebUtility.InputText(context.Request.Form["mail"],200);
        string info = WebUtility.InputText(context.Request.Form["info"],5000);
        string password = WebUtility.InputText(context.Request.Form["password"],16);
        string password2 = WebUtility.InputText(context.Request.Form["password2"],16);
        int role = WebUtility.FilterParam(context.Request.Form["role"]);
        int age = WebUtility.FilterParam(context.Request.Form["age"]);
        if (role == 0)
        {
            context.Response.Write("powererror");
            return;
        }
        //判断是否有管理该角色的权限
        if (adm.GetRoleId() != role)
        {
            DataTable dtRole = new Lythen.BLL.sys_role().GetDataTableByCache();
            Lythen.Common.Tree.RoleTree tree = new Lythen.Common.Tree.RoleTree(dtRole, 0, "Role_parent_id", "Role_id");
            tree.Creat();
            if (!tree.isParent(myrole_id, role))
            {
                context.Response.Write("nopower");
                return;
            }
        }
        if (password != password2)
        {
            context.Response.Write("pwderror");
            return;
        }
        string job = context.Request.Form["job"];
        if (String.IsNullOrEmpty(name) ||
            String.IsNullOrEmpty(sex) ||
            String.IsNullOrEmpty(phone) ||
            String.IsNullOrEmpty(email) ||
            String.IsNullOrEmpty(info))
        {
            context.Response.Write("msgempty");
            return;
        }
        
        Lythen.Model.teacher model = new Lythen.Model.teacher();
        model.Teacher_info = info;
        model.Teacher_mobile = phone;
        model.Teacher_name = username;
        model.Teacher_email = email;
        //model.Teacher_job = job;
        model.Teacher_password = FormsAuthentication.HashPasswordForStoringInConfigFile(FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5"), "MD5");
        model.Teacher_realname = name;
        model.Teacher_sex = sex;
        model.Teacher_role = role;
        model.Teacher_age = age;
        int row = bllTe.Add(model);
        if (row > 0) context.Response.Write("success");
        else context.Response.Write("faild");
    }
    void Edit(HttpContext context)
    {
        int tid = WebUtility.FilterParam(context.Request.Form["tid"]);
        Lythen.Model.teacher model = bllTe.GetModel(tid);
        if (model == null)
        {
            context.Response.Write("nodata");
            return;
        }
        string name = WebUtility.InputText(context.Request.Form["realname"], 50);
        string username = WebUtility.InputText(context.Request.Form["username"], 32);
        int age = WebUtility.FilterParam(context.Request.Form["age"]);
        string sex = WebUtility.InputText(context.Request.Form["sex"], 1);
        string phone = WebUtility.InputText(context.Request.Form["phone"], 20);
        string email = WebUtility.InputText(context.Request.Form["mail"], 200);
        string info = WebUtility.InputText(context.Request.Form["info"], 5000);
        string password = WebUtility.InputText(context.Request.Form["password"], 16);
        string password2 = WebUtility.InputText(context.Request.Form["password2"], 16);
        string job = context.Request.Form["job"];
        int role = WebUtility.FilterParam(context.Request.Form["role"]);
        if (role == 0)
        {
            context.Response.Write("powererror");
            return;
        }
        //判断是否有管理该角色的权限
        if (adm.GetRoleId() != role)
        {
            DataTable dtRole = new Lythen.BLL.sys_role().GetDataTableByCache();
            Lythen.Common.Tree.RoleTree tree = new Lythen.Common.Tree.RoleTree(dtRole, 0, "Role_parent_id", "Role_id");
            tree.Creat();
            if (!tree.isParent(myrole_id, role))
            {
                context.Response.Write("nopower");
                return;
            }

        }
        if (String.IsNullOrEmpty(name) ||
            String.IsNullOrEmpty(sex) ||
            String.IsNullOrEmpty(phone) ||
            String.IsNullOrEmpty(email) ||
            String.IsNullOrEmpty(info))
        {
            context.Response.Write("msgempty");
            return;
        }

        if (!string.IsNullOrEmpty(password))
        {
            if (password != password2)
            {
                context.Response.Write("pwderror");
                return;
            }
            model.Teacher_password = FormsAuthentication.HashPasswordForStoringInConfigFile(FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5"), "MD5");
        }
        model.Teacher_id = tid;
        model.Teacher_info = info;
        model.Teacher_mobile = phone;
        model.Teacher_name = username;
        model.Teacher_email = email;
        //model.Teacher_job = job;
        model.Teacher_realname = name;
        model.Teacher_sex = sex;
        model.Teacher_role = role;
        model.Teacher_age = age;
        if (bllTe.Update(model)) context.Response.Write("success");
        else context.Response.Write("faild");
    }
    void GetDetail(HttpContext context){
        string link = context.Request.Form["link"];
        string[] ids;
        int myid, Teacher_id;
        try
        {
            ids = Lythen.Common.DEncrypt.DESEncrypt.Decrypt(link).Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
        }
        catch (Exception)
        {
            context.Response.Write("error");
            return;
        }
        if (ids.Length != 2)
        {
            context.Response.Write("error");
            return;
        }
        myid = WebUtility.FilterParam(ids[0]);
        Teacher_id = WebUtility.FilterParam(ids[1]);
        if (myid != adm.GetRoleId())
        {
            context.Response.Write("nopower");
            return;
        }
        if (Teacher_id == 0)
        {
            context.Response.Write("iderror");
            return;
        }

        DataTable dtTe = bllTe.GetDetail(Teacher_id).Tables[0];
        if (dtTe.Rows.Count == 0)
        {
            context.Response.Write("nodata");
            return;
        }
        context.Response.Write(Lythen.Common.JsonEmitter.WriteResult(dtTe, null));
    }
    void GetJson(HttpContext context)
    {
        context.Response.Write(bllTe.getJson(myrole_id));
        return;
    }
}