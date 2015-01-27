﻿using System;
using System.Data;
using System.Collections.Generic;
using Lythen.Common;
using Lythen.Model;
namespace Lythen.BLL
{
	/// <summary>
	/// course
	/// </summary>
	public partial class course
	{
		private readonly Lythen.DAL.course dal=new Lythen.DAL.course();
		public course()
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
		public bool Exists(int Course_id)
		{
			return dal.Exists(Course_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Lythen.Model.course model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Lythen.Model.course model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Course_id)
		{
			
			return dal.Delete(Course_id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Course_idlist )
		{
			return dal.DeleteList(Lythen.Common.PageValidate.SafeLongFilter(Course_idlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Lythen.Model.course GetModel(int Course_id)
		{
			
			return dal.GetModel(Course_id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Lythen.Model.course GetModelByCache(int Course_id)
		{
			
			string CacheKey = "courseModel-" + Course_id;
			object objModel = Lythen.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Course_id);
					if (objModel != null)
					{
						int ModelCache = Lythen.Common.ConfigHelper.GetConfigInt("ModelCache");
						Lythen.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Lythen.Model.course)objModel;
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
		public List<Lythen.Model.course> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Lythen.Model.course> DataTableToList(DataTable dt)
		{
			List<Lythen.Model.course> modelList = new List<Lythen.Model.course>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Lythen.Model.course model;
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

		#endregion  ExtensionMethod
	}
}

