using System;
using System.Data;
using System.Collections.Generic;
using Lythen.Common;
using Lythen.Model;
using System.Text;
using System.IO;
namespace Lythen.BLL
{
	/// <summary>
	/// teacher
	/// </summary>
	public partial class teacher
	{
		private readonly Lythen.DAL.teacher dal=new Lythen.DAL.teacher();
        private string CachePath = System.Web.HttpContext.Current.Server.MapPath("~/DataCache/teacher/");
		public teacher()
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
		public bool Exists(int Teacher_id)
		{
			return dal.Exists(Teacher_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Lythen.Model.teacher model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Lythen.Model.teacher model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Teacher_id)
		{
			
			return dal.Delete(Teacher_id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Teacher_idlist )
		{
			return dal.DeleteList(Lythen.Common.PageValidate.SafeLongFilter(Teacher_idlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Lythen.Model.teacher GetModel(int Teacher_id)
		{
			
			return dal.GetModel(Teacher_id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Lythen.Model.teacher GetModelByCache(int Teacher_id)
		{
			
			string CacheKey = "teacherModel-" + Teacher_id;
			object objModel = Lythen.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Teacher_id);
					if (objModel != null)
					{
						int ModelCache = Lythen.Common.ConfigHelper.GetConfigInt("ModelCache");
						Lythen.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Lythen.Model.teacher)objModel;
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
		public List<Lythen.Model.teacher> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Lythen.Model.teacher> DataTableToList(DataTable dt)
		{
			List<Lythen.Model.teacher> modelList = new List<Lythen.Model.teacher>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Lythen.Model.teacher model;
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
        /// 登陆
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Login(string username, string password)
        {
            return dal.Login(username, password);
        }
        /// <summary>
        /// 获取教师角色和个人信息
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public DataSet GetTeacherRole(string username)
        {
            return dal.GetTeacherRole(username);
        }
        /// <summary>
        /// 获取教师列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetTeacherList()
        {
            return dal.GetTeacherList();
        }
        /// <summary>
        /// 获取教师详细信息
        /// </summary>
        /// <param name="Teacher_id"></param>
        /// <returns></returns>
        public DataSet GetDetail(int Teacher_id)
        {
            return dal.GetDetail(Teacher_id);
        }
        public string getJson(int role_id)
        {
            Lythen.BLL.sys_role roleBll = new sys_role();
            string roles = roleBll.GetOwnRole(role_id);
            if (roles == "") return "";
            DataTable dtTeacher = dal.GetTeacherByRoles(roles).Tables[0];
            if (dtTeacher.Rows.Count == 0) return "";

            if (!Directory.Exists(CachePath)) Directory.CreateDirectory(CachePath);
            string file_path = string.Format("{0}teacher_{1}.txt", CachePath,role_id);
            StringBuilder sb = new StringBuilder();
            if (!File.Exists(file_path))
            {
                sb.Append("[{\"id\":0,\"text\":\"请选择老师\"}");
                DataTable dtSub = new Lythen.BLL.subject().GetList("").Tables[0];
                if (dtTeacher.Rows.Count == 0)
                {
                    sb.Append("]");
                    return sb.ToString();
                }
                else
                {
                    foreach (DataRow dr in dtTeacher.Rows)
                    {
                        sb.Append(",{\"id\":\"").Append(dr["Teacher_id"]).Append("\",\"text\":\"").Append(dr["Teacher_realname"]).Append("\"}");
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

