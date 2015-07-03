using System;
using System.Data;
using System.Collections.Generic;
using Lythen.Common;
using Lythen.Model;
using System.Web;
using System.IO;
using System.Text;
namespace Lythen.BLL
{
	/// <summary>
	/// sys_grade
	/// </summary>
	public partial class sys_grade
	{
		private readonly Lythen.DAL.sys_grade dal=new Lythen.DAL.sys_grade();
        private string CachePath = HttpContext.Current.Server.MapPath("~/DataCache/Grade/");
		public sys_grade()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int g_id)
		{
			return dal.Exists(g_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Lythen.Model.sys_grade model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Lythen.Model.sys_grade model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int g_id)
		{
			
			return dal.Delete(g_id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string g_idlist )
		{
			return dal.DeleteList(Lythen.Common.PageValidate.SafeLongFilter(g_idlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Lythen.Model.sys_grade GetModel(int g_id)
		{
			
			return dal.GetModel(g_id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Lythen.Model.sys_grade GetModelByCache(int g_id)
		{
			
			string CacheKey = "sys_gradeModel-" + g_id;
			object objModel = Lythen.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(g_id);
					if (objModel != null)
					{
						int ModelCache = Lythen.Common.ConfigHelper.GetConfigInt("ModelCache");
						Lythen.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Lythen.Model.sys_grade)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Lythen.Model.sys_grade> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Lythen.Model.sys_grade> DataTableToList(DataTable dt)
		{
			List<Lythen.Model.sys_grade> modelList = new List<Lythen.Model.sys_grade>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Lythen.Model.sys_grade model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod
        /// <summary>
        /// 返回下拉列表所需要的JSON
        /// </summary>
        /// <param name="IdIsTxt">ID的参数是否为科目的title，即ID，与txt一样，都是名称</param>
        /// <returns></returns>
        public string GetListJson()
        {
            DataTable dtGrade = dal.GetAllLiteList().Tables[0];
            if (!Directory.Exists(CachePath)) Directory.CreateDirectory(CachePath);
            string file_path = CachePath + "Grade.txt";
            StringBuilder sb = new StringBuilder();
            if (!File.Exists(file_path))
            {
                sb.Append("[{\"id\":0,\"text\":\"请选择年级\"}");
                DataTable dtSub = new Lythen.BLL.subject().GetList("").Tables[0];
                if (dtGrade.Rows.Count == 0)
                {
                    sb.Append("]");
                    return sb.ToString();
                }
                else
                {
                    foreach (DataRow dr in dtGrade.Rows)
                    {
                        sb.Append(",{\"id\":\"").Append(dr["g_id"]).Append("\",\"text\":\"").Append(dr["g_title"]).Append("\"}");
                    }
                }
                sb.Append("]");
                StreamWriter sw = new StreamWriter(file_path);
                sw.Write(sb.ToString());
                sw.Flush();
                sw.Close();
                return sb.ToString();
            }
            else
            {

                StreamReader sr = new StreamReader(file_path);
                string str = sr.ReadToEnd();
                sr.Close();
                return str;
            }
        }
		#endregion  ExtensionMethod
	}
}

