using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
/// <summary>
///Global 的摘要说明
/// </summary>
public class Global
{
	public Global()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    static string CachePath = HttpContext.Current.Server.MapPath("~/DataCache/");
    public static void DeleteSubjectCache()
    {
        string sub_file = CachePath + "subject.txt";
        string xml_file = CachePath + "cache_subject.xml";
        if (File.Exists(sub_file))
        {
            try
            {
                File.Delete(sub_file);
            }
            catch (IOException) { }
        }
        if (File.Exists(xml_file))
        {
            try
            {
                File.Delete(xml_file);
            }
            catch (IOException) { }
        }
    }
}