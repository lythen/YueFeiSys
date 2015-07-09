<%@ WebHandler Language="C#" Class="RolevsSubjectHandler" %>

using System;
using System.Web;
using System.Web.SessionState;
public class RolevsSubjectHandler : IHttpHandler,IRequiresSessionState {

    Admin adm = new Admin();
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
        if (type == "update")
            Update(context);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
    private void Update(HttpContext context)
    {
        string subList = WebUtility.InputText(context.Request.Form["subList"], 200);
        if (String.IsNullOrEmpty(subList))
        {
            context.Response.Write("noselect");
            return;
        }
        subList = subList.Substring(0, subList.Length - 1);
        int role_id = WebUtility.FilterParam(context.Request.Form["role_id"]);
        context.Response.Write(new Lythen.BLL.role_vs_subject().Update(subList, myrole_id, role_id));
    }
}