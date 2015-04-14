using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Lythen.DBUtility;//Please add references
namespace Lythen.DAL
{
	/// <summary>
	/// 数据访问类:teacher_vs_subject
	/// </summary>
	public partial class teacher_vs_subject
	{
		public teacher_vs_subject()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("teacher_id", "teacher_vs_subject"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int teacher_id,int sub_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from teacher_vs_subject");
			strSql.Append(" where teacher_id=@teacher_id and sub_id=@sub_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@teacher_id", SqlDbType.Int,4),
					new SqlParameter("@sub_id", SqlDbType.Int,4)			};
			parameters[0].Value = teacher_id;
			parameters[1].Value = sub_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Lythen.Model.teacher_vs_subject model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into teacher_vs_subject(");
			strSql.Append("teacher_id,sub_id)");
			strSql.Append(" values (");
			strSql.Append("@teacher_id,@sub_id)");
			SqlParameter[] parameters = {
					new SqlParameter("@teacher_id", SqlDbType.Int,4),
					new SqlParameter("@sub_id", SqlDbType.Int,4)};
			parameters[0].Value = model.teacher_id;
			parameters[1].Value = model.sub_id;

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
		public bool Update(Lythen.Model.teacher_vs_subject model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update teacher_vs_subject set ");
#warning 系统发现缺少更新的字段，请手工确认如此更新是否正确！ 
			strSql.Append("teacher_id=@teacher_id,");
			strSql.Append("sub_id=@sub_id");
			strSql.Append(" where teacher_id=@teacher_id and sub_id=@sub_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@teacher_id", SqlDbType.Int,4),
					new SqlParameter("@sub_id", SqlDbType.Int,4)};
			parameters[0].Value = model.teacher_id;
			parameters[1].Value = model.sub_id;

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
		public bool Delete(int teacher_id,int sub_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from teacher_vs_subject ");
			strSql.Append(" where teacher_id=@teacher_id and sub_id=@sub_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@teacher_id", SqlDbType.Int,4),
					new SqlParameter("@sub_id", SqlDbType.Int,4)			};
			parameters[0].Value = teacher_id;
			parameters[1].Value = sub_id;

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
		/// 得到一个对象实体
		/// </summary>
		public Lythen.Model.teacher_vs_subject GetModel(int teacher_id,int sub_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 teacher_id,sub_id from teacher_vs_subject ");
			strSql.Append(" where teacher_id=@teacher_id and sub_id=@sub_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@teacher_id", SqlDbType.Int,4),
					new SqlParameter("@sub_id", SqlDbType.Int,4)			};
			parameters[0].Value = teacher_id;
			parameters[1].Value = sub_id;

			Lythen.Model.teacher_vs_subject model=new Lythen.Model.teacher_vs_subject();
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
		public Lythen.Model.teacher_vs_subject DataRowToModel(DataRow row)
		{
			Lythen.Model.teacher_vs_subject model=new Lythen.Model.teacher_vs_subject();
			if (row != null)
			{
				if(row["teacher_id"]!=null && row["teacher_id"].ToString()!="")
				{
					model.teacher_id=int.Parse(row["teacher_id"].ToString());
				}
				if(row["sub_id"]!=null && row["sub_id"].ToString()!="")
				{
					model.sub_id=int.Parse(row["sub_id"].ToString());
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
			strSql.Append("select teacher_id,sub_id ");
			strSql.Append(" FROM teacher_vs_subject ");
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
			strSql.Append(" teacher_id,sub_id ");
			strSql.Append(" FROM teacher_vs_subject ");
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
			strSql.Append("select count(1) FROM teacher_vs_subject ");
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
				strSql.Append("order by T.sub_id desc");
			}
			strSql.Append(")AS Row, T.*  from teacher_vs_subject T ");
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
			parameters[0].Value = "teacher_vs_subject";
			parameters[1].Value = "sub_id";
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

