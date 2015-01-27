using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Lythen.DBUtility;//Please add references
namespace Lythen.DAL
{
	/// <summary>
	/// 数据访问类:Sys_job
	/// </summary>
	public partial class Sys_job
	{
		public Sys_job()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Job_id", "Sys_job"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Job_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_job");
			strSql.Append(" where Job_id=@Job_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Job_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Job_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lythen.Model.Sys_job model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_job(");
			strSql.Append("Job_title)");
			strSql.Append(" values (");
			strSql.Append("@Job_title)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Job_title", SqlDbType.VarChar,20)};
			parameters[0].Value = model.Job_title;

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
		public bool Update(Lythen.Model.Sys_job model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_job set ");
			strSql.Append("Job_title=@Job_title");
			strSql.Append(" where Job_id=@Job_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Job_title", SqlDbType.VarChar,20),
					new SqlParameter("@Job_id", SqlDbType.Int,4)};
			parameters[0].Value = model.Job_title;
			parameters[1].Value = model.Job_id;

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
		public bool Delete(int Job_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_job ");
			strSql.Append(" where Job_id=@Job_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Job_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Job_id;

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
		public bool DeleteList(string Job_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_job ");
			strSql.Append(" where Job_id in ("+Job_idlist + ")  ");
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
		public Lythen.Model.Sys_job GetModel(int Job_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Job_id,Job_title from Sys_job ");
			strSql.Append(" where Job_id=@Job_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Job_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Job_id;

			Lythen.Model.Sys_job model=new Lythen.Model.Sys_job();
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
		public Lythen.Model.Sys_job DataRowToModel(DataRow row)
		{
			Lythen.Model.Sys_job model=new Lythen.Model.Sys_job();
			if (row != null)
			{
				if(row["Job_id"]!=null && row["Job_id"].ToString()!="")
				{
					model.Job_id=int.Parse(row["Job_id"].ToString());
				}
				if(row["Job_title"]!=null)
				{
					model.Job_title=row["Job_title"].ToString();
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
			strSql.Append("select Job_id,Job_title ");
			strSql.Append(" FROM Sys_job ");
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
			strSql.Append(" Job_id,Job_title ");
			strSql.Append(" FROM Sys_job ");
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
			strSql.Append("select count(1) FROM Sys_job ");
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
				strSql.Append("order by T.Job_id desc");
			}
			strSql.Append(")AS Row, T.*  from Sys_job T ");
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
			parameters[0].Value = "Sys_job";
			parameters[1].Value = "Job_id";
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

