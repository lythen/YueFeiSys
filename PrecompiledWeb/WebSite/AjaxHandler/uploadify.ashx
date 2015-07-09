<%@ WebHandler Language="C#" Class="uploadify" %>

using System;
using System.Web;
using System.IO;
using System.Configuration;
using System.Web.Security;
public class uploadify : IHttpHandler {
    private string uploads = ConfigurationManager.AppSettings["UploadFilePath"];
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);
        HttpFileCollection files = context.Request.Files;
        int fileLenght = files.Count;
        if (fileLenght == 0)
        {
            context.Response.Write("no file");
            return;
        }
        //string timestamp = context.Request.Form["timestamp"];
        //string token = context.Request.Form["token"].ToUpper();
        //string md5 = FormsAuthentication.HashPasswordForStoringInConfigFile("timestamp", "MD5");
        //if (token != md5)
        //{
        //    context.Response.Write("timestamp error");
        //    return;
        //}
        try
        {
            for (int i = 0; i < fileLenght; i++)
            {
                files[i].SaveAs(uploads + files[i].FileName);
            }
        }
        catch (Exception e)
        {
            context.Response.Write(e.ToString());
        }
        context.Response.Write(1);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}