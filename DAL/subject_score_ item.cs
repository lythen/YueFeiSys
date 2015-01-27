using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Lythen.DBUtility;//Please add references
namespace Lythen.DAL
{
	/// <summary>
	/// 数据访问类:subject_score_item
	/// </summary>
	public partial class subject_score_item
	{
		public subject_score_item()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("item_id", "subject_score_item"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int item_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from subject_score_item");
			strSql.Append(" whereitem_id=@item_id");
			SqlParameter[] parameters = {
					new SqlParameter("@item_id", SqlDbType.Int,4)
			};
			parameters[0].Value =item_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lythen.Model.subject_score_item model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into subject_score_item(");
			strSql.Append("item_subject_id,item_title)");
			strSql.Append(" values (");
			strSql.Append("@item_subject_id,@item_title)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@item_subject_id", SqlDbType.Int,4),
					new SqlParameter("@item_title", SqlDbType.VarChar,50)};
			parameters[0].Value = model.item_subject_id;
			parameters[1].Value = model.item_title;

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
		public bool Update(Lythen.Model.subject_score_item model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update subject_score_itemset ");
			strSql.Append("item_subject_id=@item_subject_id,");
			strSql.Append("item_title=@item_title");
			strSql.Append(" whereitem_id=@item_id");
			SqlParameter[] parameters = {
					new SqlParameter("@item_subject_id", SqlDbType.Int,4),
					new SqlParameter("@item_title", SqlDbType.VarChar,50),
					new SqlParameter("@item_id", SqlDbType.Int,4)};
			parameters[0].Value = model.item_subject_id;
			parameters[1].Value = model.item_title;
			parameters[2].Value = model.item_id;

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
		public bool Delete(int item_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from subject_score_item");
			strSql.Append(" whereitem_id=@item_id");
			SqlParameter[] parameters = {
					new SqlParameter("@item_id", SqlDbType.Int,4)
			};
			parameters[0].Value =item_id;

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
		public bool DeleteList(string item_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from subject_score_item");
			strSql.Append(" whereitem_id in ("+item_idlist + ")  ");
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
		public Lythen.Model.subject_score_item GetModel(int item_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1item_id,item_subject_id,item_title from subject_score_item");
			strSql.Append(" whereitem_id=@item_id");
			SqlParameter[] parameters = {
					new SqlParameter("@item_id", SqlDbType.Int,4)
			};
			parameters[0].Value =item_id;

			Lythen.Model.subject_score_item model=new Lythen.Model.subject_score_item();
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
		public Lythen.Model.subject_score_item DataRowToModel(DataRow row)
		{
			Lythen.Model.subject_score_item model=new Lythen.Model.subject_score_item();
			if (row != null)
			{
				if(row["item_id"]!=null && row["item_id"].ToString()!="")
				{
					model.item_id=int.Parse(row["item_id"].ToString());
				}
				if(row["item_subject_id"]!=null && row["item_subject_id"].ToString()!="")
				{
					model.item_subject_id=int.Parse(row["item_subject_id"].ToString());
				}
				if(row["item_title"]!=null)
				{
					model.item_title=row["item_title"].ToString();
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
			strSql.Append("selectitem_id,item_subject_id,item_title ");
			strSql.Append(" FROM subject_score_item");
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
			strSql.Append("item_id,item_subject_id,item_title ");
			strSql.Append(" FROM subject_score_item");
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
			strSql.Append("select count(1) FROM subject_score_item");
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
				strSql.Append("order by T.item_id desc");
			}
			strSql.Append(")AS Row, T.*  from subject_score_itemT ");
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
			parameters[0].Value = "subject_score_item";
			parameters[1].Value = "item_id";
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

