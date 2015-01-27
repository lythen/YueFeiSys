using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Lythen.DBUtility;//Please add references
namespace Lythen.DAL
{
	/// <summary>
	/// 数据访问类:subject
	/// </summary>
	public partial class subject
	{
		public subject()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Subject_id", "subject"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Subject_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from subject");
			strSql.Append(" where Subject_id=@Subject_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Subject_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Subject_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lythen.Model.subject model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into subject(");
			strSql.Append("Subject_title,Subject_info,Subject_parent)");
			strSql.Append(" values (");
			strSql.Append("@Subject_title,@Subject_info,@Subject_parent)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Subject_title", SqlDbType.VarChar,20),
					new SqlParameter("@Subject_info", SqlDbType.VarChar,500),
					new SqlParameter("@Subject_parent", SqlDbType.Int,4)};
			parameters[0].Value = model.Subject_title;
			parameters[1].Value = model.Subject_info;
			parameters[2].Value = model.Subject_parent;

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
		public bool Update(Lythen.Model.subject model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update subject set ");
			strSql.Append("Subject_title=@Subject_title,");
			strSql.Append("Subject_info=@Subject_info,");
			strSql.Append("Subject_parent=@Subject_parent");
			strSql.Append(" where Subject_id=@Subject_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Subject_title", SqlDbType.VarChar,20),
					new SqlParameter("@Subject_info", SqlDbType.VarChar,500),
					new SqlParameter("@Subject_parent", SqlDbType.Int,4),
					new SqlParameter("@Subject_id", SqlDbType.Int,4)};
			parameters[0].Value = model.Subject_title;
			parameters[1].Value = model.Subject_info;
			parameters[2].Value = model.Subject_parent;
			parameters[3].Value = model.Subject_id;

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
		public bool Delete(int Subject_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from subject ");
			strSql.Append(" where Subject_id=@Subject_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Subject_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Subject_id;

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
		public bool DeleteList(string Subject_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from subject ");
			strSql.Append(" where Subject_id in ("+Subject_idlist + ")  ");
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
		public Lythen.Model.subject GetModel(int Subject_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Subject_id,Subject_title,Subject_info,Subject_parent from subject ");
			strSql.Append(" where Subject_id=@Subject_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Subject_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Subject_id;

			Lythen.Model.subject model=new Lythen.Model.subject();
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
		public Lythen.Model.subject DataRowToModel(DataRow row)
		{
			Lythen.Model.subject model=new Lythen.Model.subject();
			if (row != null)
			{
				if(row["Subject_id"]!=null && row["Subject_id"].ToString()!="")
				{
					model.Subject_id=int.Parse(row["Subject_id"].ToString());
				}
				if(row["Subject_title"]!=null)
				{
					model.Subject_title=row["Subject_title"].ToString();
				}
				if(row["Subject_info"]!=null)
				{
					model.Subject_info=row["Subject_info"].ToString();
				}
				if(row["Subject_parent"]!=null && row["Subject_parent"].ToString()!="")
				{
					model.Subject_parent=int.Parse(row["Subject_parent"].ToString());
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
			strSql.Append("select Subject_id,Subject_title,Subject_info,Subject_parent ");
			strSql.Append(" FROM subject ");
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
			strSql.Append(" Subject_id,Subject_title,Subject_info,Subject_parent ");
			strSql.Append(" FROM subject ");
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
			strSql.Append("select count(1) FROM subject ");
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
				strSql.Append("order by T.Subject_id desc");
			}
			strSql.Append(")AS Row, T.*  from subject T ");
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
			parameters[0].Value = "subject";
			parameters[1].Value = "Subject_id";
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

