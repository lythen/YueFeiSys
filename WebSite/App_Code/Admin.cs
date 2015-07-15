using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///Admin 的摘要说明
/// </summary>
public class Admin
{
    public Admin()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    /// <summary>
    /// 获取ID
    /// </summary>
    /// <returns></returns>
    public int GetTeacherId()
    {
        int id = 0;
        if (HttpContext.Current.Session["id"] != null)
            id = WebUtility.FilterParam(HttpContext.Current.Session["id"].ToString());
        return id;
    }
    /// <summary>
    /// 获取用户名
    /// </summary>
    /// <returns></returns>
    public string GetUserName()
    {
        string username = "";
        if (HttpContext.Current.Session["username"] != null)
            username = WebUtility.InputText(HttpContext.Current.Session["username"].ToString(), 30);
        return username;
    }
    /// <summary>
    /// 获取真实姓名
    /// </summary>
    /// <returns></returns>
    public string GetRealName()
    {
        string username = "";
        if (HttpContext.Current.Session["realname"] != null)
            username = WebUtility.InputText(HttpContext.Current.Session["realname"].ToString(), 50);
        return username;
    }
    /// <summary>
    /// 获取角色ID
    /// </summary>
    /// <returns></returns>
    public int GetRoleId()
    {
        int id = 0;
        if (HttpContext.Current.Session["role_id"] != null)
            id = WebUtility.FilterParam(HttpContext.Current.Session["role_id"].ToString());
        return id;
    }
    /// <summary>
    /// 获取角色名
    /// </summary>
    /// <returns></returns>
    public string GetRoleName()
    {
        string username = "";
        if (HttpContext.Current.Session["role_name"] != null)
            username = WebUtility.InputText(HttpContext.Current.Session["role_name"].ToString(), 50);
        return username;
    }
    /// <summary>
    /// 是否是超级管理员
    /// </summary>
    /// <returns></returns>
    public bool isSuperAdmin()
    {
        int id = 0;
        if (HttpContext.Current.Session["role_id"] != null)
            id = WebUtility.FilterParam(HttpContext.Current.Session["role_id"].ToString());
        return id == 1;
    }
    /// <summary>
    /// 是否有报名权限
    /// </summary>
    /// <returns></returns>
    public bool isPayAdmin()
    {
        int id = 0;
        if (HttpContext.Current.Session["role_id"] != null)
            id = WebUtility.FilterParam(HttpContext.Current.Session["role_id"].ToString());
        return id == 1 || id == 2;
    }
    /// <summary>
    /// 是否有报名权限
    /// </summary>
    /// <returns></returns>
    public bool isParent()
    {
        int id = 0;
        if (HttpContext.Current.Session["role_id"] != null)
            id = WebUtility.FilterParam(HttpContext.Current.Session["role_id"].ToString());
        return id == 3;
    }
}