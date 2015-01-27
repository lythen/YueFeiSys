using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Lythen.DBUtility;//Please add references
namespace Lythen.DAL
{
	/// <summary>
	/// 数据访问类:sys_role
	/// </summary>
	public partial class sys_role
	{
		public sys_role()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Role_id", "sys_role"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Role_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sys_role");
			strSql.Append(" where Role_id=@Role_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Role_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Role_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lythen.Model.sys_role model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sys_role(");
			strSql.Append("Role_name)");
			strSql.Append(" values (");
			strSql.Append("@Role_name)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Role_name", SqlDbType.VarChar,30)};
			parameters[0].Value = model.Role_name;

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
		public bool Update(Lythen.Model.sys_role model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sys_role set ");
			strSql.Append("Role_name=@Role_name");
			strSql.Append(" where Role_id=@Role_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Role_name", SqlDbType.VarChar,30),
					new SqlParameter("@Role_id", SqlDbType.Int,4)};
			parameters[0].Value = model.Role_name;
			parameters[1].Value = model.Role_id;

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
		public bool Delete(int Role_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sys_role ");
			strSql.Append(" where Role_id=@Role_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Role_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Role_id;

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
		public bool DeleteList(string Role_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sys_role ");
			strSql.Append(" where Role_id in ("+Role_idlist + ")  ");
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
		public Lythen.Model.sys_role GetModel(int Role_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Role_id,Role_name from sys_role ");
			strSql.Append(" where Role_id=@Role_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Role_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Role_id;

			Lythen.Model.sys_role model=new Lythen.Model.sys_role();
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
		public Lythen.Model.sys_role DataRowToModel(DataRow row)
		{
			Lythen.Model.sys_role model=new Lythen.Model.sys_role();
			if (row != null)
			{
				if(row["Role_id"]!=null && row["Role_id"].ToString()!="")
				{
					model.Role_id=int.Parse(row["Role_id"].ToString());
				}
				if(row["Role_name"]!=null)
				{
					model.Role_name=row["Role_name"].ToString();
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
			strSql.Append("select Role_id,Role_name ");
			strSql.Append(" FROM sys_role ");
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
			strSql.Append(" Role_id,Role_name ");
			strSql.Append(" FROM sys_role ");
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
			strSql.Append("select count(1) FROM sys_role ");
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
				strSql.Append("order by T.Role_id desc");
			}
			strSql.Append(")AS Row, T.*  from sys_role T ");
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
			parameters[0].Value = "sys_role";
			parameters[1].Value = "Role_id";
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

