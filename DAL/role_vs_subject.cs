using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Lythen.DBUtility;//Please add references
namespace Lythen.DAL
{
	/// <summary>
	/// 数据访问类:role_vs_subject
	/// </summary>
	public partial class role_vs_subject
	{
		public role_vs_subject()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("role_id", "role_vs_subject"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int role_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from role_vs_subject");
			strSql.Append(" where role_id=@role_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@role_id", SqlDbType.Int,4)			};
			parameters[0].Value = role_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Lythen.Model.role_vs_subject model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into role_vs_subject(");
			strSql.Append("role_id,sub_list)");
			strSql.Append(" values (");
			strSql.Append("@role_id,@sub_list)");
			SqlParameter[] parameters = {
					new SqlParameter("@role_id", SqlDbType.Int,4),
					new SqlParameter("@sub_list", SqlDbType.VarChar,100)};
			parameters[0].Value = model.role_id;
			parameters[1].Value = model.sub_list;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(Lythen.Model.role_vs_subject model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update role_vs_subject set ");
			strSql.Append("sub_list=@sub_list");
			strSql.Append(" where role_id=@role_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@sub_list", SqlDbType.VarChar,100),
					new SqlParameter("@role_id", SqlDbType.Int,4)};
			parameters[0].Value = model.sub_list;
			parameters[1].Value = model.role_id;

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
		public bool Delete(int role_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from role_vs_subject ");
			strSql.Append(" where role_id=@role_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@role_id", SqlDbType.Int,4)			};
			parameters[0].Value = role_id;

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
		public bool DeleteList(string role_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from role_vs_subject ");
			strSql.Append(" where role_id in ("+role_idlist + ")  ");
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
		public Lythen.Model.role_vs_subject GetModel(int role_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 role_id,sub_list from role_vs_subject ");
			strSql.Append(" where role_id=@role_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@role_id", SqlDbType.Int,4)			};
			parameters[0].Value = role_id;

			Lythen.Model.role_vs_subject model=new Lythen.Model.role_vs_subject();
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
		public Lythen.Model.role_vs_subject DataRowToModel(DataRow row)
		{
			Lythen.Model.role_vs_subject model=new Lythen.Model.role_vs_subject();
			if (row != null)
			{
				if(row["role_id"]!=null && row["role_id"].ToString()!="")
				{
					model.role_id=int.Parse(row["role_id"].ToString());
				}
				if(row["sub_list"]!=null)
				{
					model.sub_list=row["sub_list"].ToString();
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
			strSql.Append("select role_id,sub_list ");
			strSql.Append(" FROM role_vs_subject ");
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
			strSql.Append(" role_id,sub_list ");
			strSql.Append(" FROM role_vs_subject ");
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
			strSql.Append("select count(1) FROM role_vs_subject ");
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
				strSql.Append("order by T.role_id desc");
			}
			strSql.Append(")AS Row, T.*  from role_vs_subject T ");
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
			parameters[0].Value = "role_vs_subject";
			parameters[1].Value = "role_id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod
        public DataSet GetManagerSubject(int role_id)
        {
            string sql = "select sub_list from role_vs_subject where role_id=@role_id";
            SqlParameter[] parameters = {
					new SqlParameter("@role_id", SqlDbType.Int,4)			};
            parameters[0].Value = role_id;
            return DbHelperSQL.Query(sql, parameters);
        }
		#endregion  ExtensionMethod
	}
}

