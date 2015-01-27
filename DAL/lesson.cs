using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Lythen.DBUtility;//Please add references
namespace Lythen.DAL
{
	/// <summary>
	/// 数据访问类:lesson
	/// </summary>
	public partial class lesson
	{
		public lesson()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Lesson_id", "lesson"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Lesson_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from lesson");
			strSql.Append(" where Lesson_id=@Lesson_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Lesson_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Lesson_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lythen.Model.lesson model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into lesson(");
			strSql.Append("Lesson_subject_id,Lesson_title,Lesson_info)");
			strSql.Append(" values (");
			strSql.Append("@Lesson_subject_id,@Lesson_title,@Lesson_info)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Lesson_subject_id", SqlDbType.Int,4),
					new SqlParameter("@Lesson_title", SqlDbType.VarChar,100),
					new SqlParameter("@Lesson_info", SqlDbType.Text)};
			parameters[0].Value = model.Lesson_subject_id;
			parameters[1].Value = model.Lesson_title;
			parameters[2].Value = model.Lesson_info;

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
		public bool Update(Lythen.Model.lesson model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update lesson set ");
			strSql.Append("Lesson_subject_id=@Lesson_subject_id,");
			strSql.Append("Lesson_title=@Lesson_title,");
			strSql.Append("Lesson_info=@Lesson_info");
			strSql.Append(" where Lesson_id=@Lesson_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Lesson_subject_id", SqlDbType.Int,4),
					new SqlParameter("@Lesson_title", SqlDbType.VarChar,100),
					new SqlParameter("@Lesson_info", SqlDbType.Text),
					new SqlParameter("@Lesson_id", SqlDbType.Int,4)};
			parameters[0].Value = model.Lesson_subject_id;
			parameters[1].Value = model.Lesson_title;
			parameters[2].Value = model.Lesson_info;
			parameters[3].Value = model.Lesson_id;

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
		public bool Delete(int Lesson_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from lesson ");
			strSql.Append(" where Lesson_id=@Lesson_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Lesson_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Lesson_id;

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
		public bool DeleteList(string Lesson_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from lesson ");
			strSql.Append(" where Lesson_id in ("+Lesson_idlist + ")  ");
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
		public Lythen.Model.lesson GetModel(int Lesson_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Lesson_id,Lesson_subject_id,Lesson_title,Lesson_info from lesson ");
			strSql.Append(" where Lesson_id=@Lesson_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Lesson_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Lesson_id;

			Lythen.Model.lesson model=new Lythen.Model.lesson();
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
		public Lythen.Model.lesson DataRowToModel(DataRow row)
		{
			Lythen.Model.lesson model=new Lythen.Model.lesson();
			if (row != null)
			{
				if(row["Lesson_id"]!=null && row["Lesson_id"].ToString()!="")
				{
					model.Lesson_id=int.Parse(row["Lesson_id"].ToString());
				}
				if(row["Lesson_subject_id"]!=null && row["Lesson_subject_id"].ToString()!="")
				{
					model.Lesson_subject_id=int.Parse(row["Lesson_subject_id"].ToString());
				}
				if(row["Lesson_title"]!=null)
				{
					model.Lesson_title=row["Lesson_title"].ToString();
				}
				if(row["Lesson_info"]!=null)
				{
					model.Lesson_info=row["Lesson_info"].ToString();
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
			strSql.Append("select Lesson_id,Lesson_subject_id,Lesson_title,Lesson_info ");
			strSql.Append(" FROM lesson ");
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
			strSql.Append(" Lesson_id,Lesson_subject_id,Lesson_title,Lesson_info ");
			strSql.Append(" FROM lesson ");
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
			strSql.Append("select count(1) FROM lesson ");
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
				strSql.Append("order by T.Lesson_id desc");
			}
			strSql.Append(")AS Row, T.*  from lesson T ");
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
			parameters[0].Value = "lesson";
			parameters[1].Value = "Lesson_id";
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

