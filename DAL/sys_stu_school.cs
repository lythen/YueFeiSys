using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Lythen.DBUtility;//Please add references
namespace Lythen.DAL
{
	/// <summary>
	/// 数据访问类:sys_stu_school
	/// </summary>
	public partial class sys_stu_school
	{
		public sys_stu_school()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ss_id", "sys_stu_school"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ss_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sys_stu_school");
			strSql.Append(" where ss_id=@ss_id");
			SqlParameter[] parameters = {
					new SqlParameter("@ss_id", SqlDbType.Int,4)
			};
			parameters[0].Value = ss_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lythen.Model.sys_stu_school model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sys_stu_school(");
			strSql.Append("ss_title)");
			strSql.Append(" values (");
			strSql.Append("@ss_title)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ss_title", SqlDbType.VarChar,100)};
			parameters[0].Value = model.ss_title;

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
		public bool Update(Lythen.Model.sys_stu_school model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sys_stu_school set ");
			strSql.Append("ss_title=@ss_title");
			strSql.Append(" where ss_id=@ss_id");
			SqlParameter[] parameters = {
					new SqlParameter("@ss_title", SqlDbType.VarChar,100),
					new SqlParameter("@ss_id", SqlDbType.Int,4)};
			parameters[0].Value = model.ss_title;
			parameters[1].Value = model.ss_id;

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
		public bool Delete(int ss_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sys_stu_school ");
			strSql.Append(" where ss_id=@ss_id");
			SqlParameter[] parameters = {
					new SqlParameter("@ss_id", SqlDbType.Int,4)
			};
			parameters[0].Value = ss_id;

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
		public bool DeleteList(string ss_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sys_stu_school ");
			strSql.Append(" where ss_id in ("+ss_idlist + ")  ");
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
		public Lythen.Model.sys_stu_school GetModel(int ss_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ss_id,ss_title from sys_stu_school ");
			strSql.Append(" where ss_id=@ss_id");
			SqlParameter[] parameters = {
					new SqlParameter("@ss_id", SqlDbType.Int,4)
			};
			parameters[0].Value = ss_id;

			Lythen.Model.sys_stu_school model=new Lythen.Model.sys_stu_school();
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
		public Lythen.Model.sys_stu_school DataRowToModel(DataRow row)
		{
			Lythen.Model.sys_stu_school model=new Lythen.Model.sys_stu_school();
			if (row != null)
			{
				if(row["ss_id"]!=null && row["ss_id"].ToString()!="")
				{
					model.ss_id=int.Parse(row["ss_id"].ToString());
				}
				if(row["ss_title"]!=null)
				{
					model.ss_title=row["ss_title"].ToString();
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
			strSql.Append("select ss_id,ss_title ");
			strSql.Append(" FROM sys_stu_school ");
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
			strSql.Append(" ss_id,ss_title ");
			strSql.Append(" FROM sys_stu_school ");
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
			strSql.Append("select count(1) FROM sys_stu_school ");
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
				strSql.Append("order by T.ss_id desc");
			}
			strSql.Append(")AS Row, T.*  from sys_stu_school T ");
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
			parameters[0].Value = "sys_stu_school";
			parameters[1].Value = "ss_id";
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

