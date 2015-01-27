﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Lythen.DBUtility;//Please add references
namespace Lythen.DAL
{
	/// <summary>
	/// 数据访问类:sys_log
	/// </summary>
	public partial class sys_log
	{
		public sys_log()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Log_id", "sys_log"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Log_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sys_log");
			strSql.Append(" where Log_id=@Log_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Log_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Log_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lythen.Model.sys_log model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sys_log(");
			strSql.Append("Log_user,Log_event,Log_date)");
			strSql.Append(" values (");
			strSql.Append("@Log_user,@Log_event,@Log_date)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Log_user", SqlDbType.VarChar,50),
					new SqlParameter("@Log_event", SqlDbType.VarChar,100),
					new SqlParameter("@Log_date", SqlDbType.DateTime)};
			parameters[0].Value = model.Log_user;
			parameters[1].Value = model.Log_event;
			parameters[2].Value = model.Log_date;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Lythen.Model.sys_log model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sys_log set ");
			strSql.Append("Log_user=@Log_user,");
			strSql.Append("Log_event=@Log_event,");
			strSql.Append("Log_date=@Log_date");
			strSql.Append(" where Log_id=@Log_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Log_user", SqlDbType.VarChar,50),
					new SqlParameter("@Log_event", SqlDbType.VarChar,100),
					new SqlParameter("@Log_date", SqlDbType.DateTime),
					new SqlParameter("@Log_id", SqlDbType.Int,4)};
			parameters[0].Value = model.Log_user;
			parameters[1].Value = model.Log_event;
			parameters[2].Value = model.Log_date;
			parameters[3].Value = model.Log_id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Log_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sys_log ");
			strSql.Append(" where Log_id=@Log_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Log_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Log_id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string Log_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sys_log ");
			strSql.Append(" where Log_id in ("+Log_idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Lythen.Model.sys_log GetModel(int Log_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Log_id,Log_user,Log_event,Log_date from sys_log ");
			strSql.Append(" where Log_id=@Log_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Log_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Log_id;

			Lythen.Model.sys_log model=new Lythen.Model.sys_log();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Lythen.Model.sys_log DataRowToModel(DataRow row)
		{
			Lythen.Model.sys_log model=new Lythen.Model.sys_log();
			if (row != null)
			{
				if(row["Log_id"]!=null && row["Log_id"].ToString()!="")
				{
					model.Log_id=int.Parse(row["Log_id"].ToString());
				}
				if(row["Log_user"]!=null)
				{
					model.Log_user=row["Log_user"].ToString();
				}
				if(row["Log_event"]!=null)
				{
					model.Log_event=row["Log_event"].ToString();
				}
				if(row["Log_date"]!=null && row["Log_date"].ToString()!="")
				{
					model.Log_date=DateTime.Parse(row["Log_date"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Log_id,Log_user,Log_event,Log_date ");
			strSql.Append(" FROM sys_log ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" Log_id,Log_user,Log_event,Log_date ");
			strSql.Append(" FROM sys_log ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM sys_log ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.Log_id desc");
			}
			strSql.Append(")AS Row, T.*  from sys_log T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "sys_log";
			parameters[1].Value = "Log_id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

