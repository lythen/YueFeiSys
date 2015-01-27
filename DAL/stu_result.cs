using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Lythen.DBUtility;//Please add references
namespace Lythen.DAL
{
	/// <summary>
	/// 数据访问类:stu_result
	/// </summary>
	public partial class stu_result
	{
		public stu_result()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Stu_id", "stu_result"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Stu_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from stu_result");
			strSql.Append(" where Stu_id=@Stu_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Stu_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Stu_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lythen.Model.stu_result model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into stu_result(");
			strSql.Append("Stu_lesson_id,Stu_ item _id,Stu_mark)");
			strSql.Append(" values (");
			strSql.Append("@Stu_lesson_id,@Stu_ item _id,@Stu_mark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Stu_lesson_id", SqlDbType.Int,4),
					new SqlParameter("@Stu_ item _id", SqlDbType.Int,4),
					new SqlParameter("@Stu_mark", SqlDbType.Float,8)};
			parameters[0].Value = model.Stu_lesson_id;
			parameters[1].Value = model.Stu_item_id;
			parameters[2].Value = model.Stu_mark;

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
		public bool Update(Lythen.Model.stu_result model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update stu_result set ");
			strSql.Append("Stu_lesson_id=@Stu_lesson_id,");
			strSql.Append("Stu_ item _id=@Stu_ item _id,");
			strSql.Append("Stu_mark=@Stu_mark");
			strSql.Append(" where Stu_id=@Stu_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Stu_lesson_id", SqlDbType.Int,4),
					new SqlParameter("@Stu_ item _id", SqlDbType.Int,4),
					new SqlParameter("@Stu_mark", SqlDbType.Float,8),
					new SqlParameter("@Stu_id", SqlDbType.Int,4)};
			parameters[0].Value = model.Stu_lesson_id;
			parameters[1].Value = model.Stu_item_id;
			parameters[2].Value = model.Stu_mark;
			parameters[3].Value = model.Stu_id;

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
		public bool Delete(int Stu_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from stu_result ");
			strSql.Append(" where Stu_id=@Stu_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Stu_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Stu_id;

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
		public bool DeleteList(string Stu_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from stu_result ");
			strSql.Append(" where Stu_id in ("+Stu_idlist + ")  ");
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
		public Lythen.Model.stu_result GetModel(int Stu_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Stu_id,Stu_lesson_id,Stu_ item _id,Stu_mark from stu_result ");
			strSql.Append(" where Stu_id=@Stu_id");
			SqlParameter[] parameters = {
					new SqlParameter("@Stu_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Stu_id;

			Lythen.Model.stu_result model=new Lythen.Model.stu_result();
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
		public Lythen.Model.stu_result DataRowToModel(DataRow row)
		{
			Lythen.Model.stu_result model=new Lythen.Model.stu_result();
			if (row != null)
			{
				if(row["Stu_id"]!=null && row["Stu_id"].ToString()!="")
				{
					model.Stu_id=int.Parse(row["Stu_id"].ToString());
				}
				if(row["Stu_lesson_id"]!=null && row["Stu_lesson_id"].ToString()!="")
				{
					model.Stu_lesson_id=int.Parse(row["Stu_lesson_id"].ToString());
				}
				if(row["Stu_ item _id"]!=null && row["Stu_ item _id"].ToString()!="")
				{
					model.Stu_item_id=int.Parse(row["Stu_ item _id"].ToString());
				}
				if(row["Stu_mark"]!=null && row["Stu_mark"].ToString()!="")
				{
					model.Stu_mark=decimal.Parse(row["Stu_mark"].ToString());
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
			strSql.Append("select Stu_id,Stu_lesson_id,Stu_ item _id,Stu_mark ");
			strSql.Append(" FROM stu_result ");
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
			strSql.Append(" Stu_id,Stu_lesson_id,Stu_ item _id,Stu_mark ");
			strSql.Append(" FROM stu_result ");
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
			strSql.Append("select count(1) FROM stu_result ");
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
				strSql.Append("order by T.Stu_id desc");
			}
			strSql.Append(")AS Row, T.*  from stu_result T ");
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
			parameters[0].Value = "stu_result";
			parameters[1].Value = "Stu_id";
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

