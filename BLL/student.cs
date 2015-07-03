using System;
using System.Data;
using System.Collections.Generic;
using Lythen.Common;
using Lythen.Model;
namespace Lythen.BLL
{
	/// <summary>
	/// student
	/// </summary>
	public partial class student
	{
		private readonly Lythen.DAL.student dal=new Lythen.DAL.student();
		public student()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string stu_id)
		{
			return dal.Exists(stu_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Lythen.Model.student model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Lythen.Model.student model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string stu_id)
		{
			
			return dal.Delete(stu_id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string stu_idlist )
		{
			return dal.DeleteList(Lythen.Common.PageValidate.SafeLongFilter(stu_idlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Lythen.Model.student GetModel(string stu_id)
		{
			
			return dal.GetModel(stu_id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Lythen.Model.student GetModelByCache(string stu_id)
		{
			
			string CacheKey = "studentModel-" + stu_id;
			object objModel = Lythen.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(stu_id);
					if (objModel != null)
					{
						int ModelCache = Lythen.Common.ConfigHelper.GetConfigInt("ModelCache");
						Lythen.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Lythen.Model.student)objModel;
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
		public List<Lythen.Model.student> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Lythen.Model.student> DataTableToList(DataTable dt)
		{
			List<Lythen.Model.student> modelList = new List<Lythen.Model.student>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Lythen.Model.student model;
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
        /// 增加一条数据
        /// </summary>
        public string AddStudent(Lythen.Model.student model)
        {
            for (int i = 0; i < 5; i++)
            {
                model.stu_id = DateTime.Now.ToString("yyyyMMddHHmmssff");
                if (dal.Add(model)) return model.stu_id;
            }
            return "";
        }
        /// <summary>
        /// 获取全体学生列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetStudentList(int PageSize, int PageIndex, int school_id, int grade, string sex, string stu_name, string parent_name)
        {
            DataSet ds = dal.GetStudentList(PageSize, PageIndex, school_id, grade, sex, stu_name, parent_name);
            DataTable Student = ds.Tables[0];

            DataTable dtCount = new DataTable("table");
            dtCount.Columns.Add(new DataColumn("total", typeof(int)));
            dtCount.Columns.Add(new DataColumn("rows", typeof(DataTable)));

            DataRow dr = dtCount.NewRow();
            dr[0] = (int)ds.Tables[1].Rows[0][0];
            dr[1] = Student;
            dtCount.Rows.Add(dr);
            return dtCount;
        }
        public DataTable GetStudent(string stu_id)
        {
            return dal.GetStudent(stu_id).Tables[0];
        }
        public string DeleteStudent(string stu_list,int role_id)
        {
            if (role_id != 1) return "没有权限。";
            if (stu_list.EndsWith(",")) stu_list = stu_list.Substring(0, stu_list.Length - 1);
            stu_list = string.Format("'{0}'", stu_list.Replace(",", "','"));
            if (dal.DeleteStudent(stu_list)) return "删除成功。";
            else return "删除失败。";
        }
        public DataTable GetStudent(string stu_id, string stu_name)
        {
            return dal.GetStudent(stu_id, stu_name).Tables[0];
        }
		#endregion  ExtensionMethod
	}
}

