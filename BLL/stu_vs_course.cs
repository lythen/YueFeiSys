using System;
using System.Data;
using System.Collections.Generic;
using Lythen.Common;
using Lythen.Model;
using System.Text;
namespace Lythen.BLL
{
	/// <summary>
	/// stu_vs_course
	/// </summary>
	public partial class stu_vs_course
	{
		private readonly Lythen.DAL.stu_vs_course dal=new Lythen.DAL.stu_vs_course();
		public stu_vs_course()
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
		public bool Exists(string Sc_stu_id,int Sc_course_id)
		{
			return dal.Exists(Sc_stu_id,Sc_course_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Lythen.Model.stu_vs_course model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Lythen.Model.stu_vs_course model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string Sc_stu_id,int Sc_course_id)
		{
			
			return dal.Delete(Sc_stu_id,Sc_course_id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Lythen.Model.stu_vs_course GetModel(string Sc_stu_id,int Sc_course_id)
		{
			
			return dal.GetModel(Sc_stu_id,Sc_course_id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Lythen.Model.stu_vs_course GetModelByCache(string Sc_stu_id,int Sc_course_id)
		{
			
			string CacheKey = "stu_vs_courseModel-" + Sc_stu_id+Sc_course_id;
			object objModel = Lythen.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Sc_stu_id,Sc_course_id);
					if (objModel != null)
					{
						int ModelCache = Lythen.Common.ConfigHelper.GetConfigInt("ModelCache");
						Lythen.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Lythen.Model.stu_vs_course)objModel;
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
		public List<Lythen.Model.stu_vs_course> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Lythen.Model.stu_vs_course> DataTableToList(DataTable dt)
		{
			List<Lythen.Model.stu_vs_course> modelList = new List<Lythen.Model.stu_vs_course>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Lythen.Model.stu_vs_course model;
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


		#endregion  BasicMethod
		#region  ExtensionMethod
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetList(int PageSize, int PageIndex, int school_id, int subject_id, int course_id, string stu_id, string stu_name, int role_id)
        {
            DataSet ds = dal.GetList(PageSize, PageIndex, school_id, subject_id, course_id, stu_id, stu_name);
            DataTable dtCount = new DataTable("table");
            dtCount.Columns.Add(new DataColumn("total", typeof(int)));
            dtCount.Columns.Add(new DataColumn("rows", typeof(DataTable)));
            if (role_id != 1) ds.Tables[0].Columns.Remove("Sc_pay");
            DataRow dr = dtCount.NewRow();
            dr[0] = (int)ds.Tables[1].Rows[0][0];
            dr[1] = ds.Tables[0];
            dtCount.Rows.Add(dr);
            return dtCount;
        }
        public string AddorDeleteStudentCourse(string addlist,string deletelist, decimal cost, string stu_id)
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(addlist))
                if (AddStudentCourse(addlist, cost, stu_id))
                {
                    sb.Append("报名成功。\r\n");
                }
                else sb.Append("报名失败。\r\n");
                
            if (!string.IsNullOrEmpty(deletelist))
                sb.Append(DeleteStudentCourse(deletelist, stu_id));
            return sb.ToString(); ;
        }
        /// <summary>
        /// 报名课程
        /// </summary>
        /// <param name="listCourse"></param>
        /// <param name="cost"></param>
        /// <returns></returns>
        public bool AddStudentCourse(string listCourse, decimal cost, string stu_id)
        {
            if (string.IsNullOrEmpty(listCourse)) return false;
            if (listCourse.EndsWith(","))
                listCourse = listCourse.Substring(0, listCourse.Length - 1);
            string[] list = listCourse.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            int len = list.Length;
            int[] cids = new int[len];

            for (int i = 0; i < len; i++)
            {
                cids[i] = WebUtility.FilterParam(list[i]);
                if (cids[i] == 0) return false;
            }
            DataSet dsCost = new course().getSUMCost(listCourse);
            DataTable dtCost = dsCost.Tables[1];
            if (dtCost.Rows.Count != len) return false;
            decimal[] cost_list = new decimal[len];
            
            decimal allCost;
            decimal per;
            if (dsCost.Tables[0].Rows.Count == 0)
            {
                allCost = 0;
                per = 0;
            }
            else
            {
                allCost = (decimal)dsCost.Tables[0].Rows[0][0];
                per = cost / allCost;
            }

            int thispay;
            for (int i = 0; i < len; i++)
            {
                thispay = (int)((decimal)dtCost.Rows[i]["Course_cost"] * per);
                cost_list[i] = thispay;
                allCost = allCost - thispay;
            }
            if (allCost != 0) cost_list[len - 1] = cost_list[len - 1] + allCost;
            return dal.AddStudentCourse(cids, cost_list, stu_id);

        }
        public string DeleteStudentCourse(string listCourse, string stu_id)
        {
            if (string.IsNullOrEmpty(listCourse)) return "";
            if (listCourse.EndsWith(","))
                listCourse = listCourse.Substring(0, listCourse.Length - 1);
            string[] list = listCourse.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            int len = list.Length;
            int[] cids = new int[len];

            for (int i = 0; i < len; i++)
            {
                cids[i] = WebUtility.FilterParam(list[i]);
                if (cids[i] == 0) return "退费失败，课程获取失败。";
            }

            int row = dal.DeleteStudentCourse(cids, stu_id);
            if (row == len) return "退费成功。";
            else return "退费失败，请检查。";
        }
        public DataTable GetStudentCourse(string stu_id,int role_id)
        {
            DataSet ds = dal.GetStudentCourse(stu_id);
            DataTable dtStudent = ds.Tables[0];
            DataTable dtCount = new DataTable("table");
            dtCount.Columns.Add(new DataColumn("total", typeof(int)));
            dtCount.Columns.Add(new DataColumn("rows", typeof(DataTable)));
            if (role_id != 1) dtStudent.Columns.Remove("Sc_pay");
            DataRow dr = dtCount.NewRow();
            dr[0] = dtStudent.Rows.Count;
            dr[1] = dtStudent;
            dtCount.Rows.Add(dr);
            return dtCount;
        }
        #endregion  ExtensionMethod
	}
}

