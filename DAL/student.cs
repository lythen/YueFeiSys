using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Lythen.DBUtility;//Please add references
namespace Lythen.DAL
{
	/// <summary>
	/// 数据访问类:student
	/// </summary>
	public partial class student
	{
		public student()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Stu_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from student");
			strSql.Append(" where Stu_id=@Stu_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Stu_id", SqlDbType.VarChar,20)			};
			parameters[0].Value = Stu_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Lythen.Model.student model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into student(");
			strSql.Append("Stu_id,Stu_name,Stu_birthday,Stu_grade,Stu_school_id,Stu_pic_path,Stu_Status,Parent_name,Parent_mobile,Parent_dep)");
			strSql.Append(" values (");
			strSql.Append("@Stu_id,@Stu_name,@Stu_birthday,@Stu_grade,@Stu_school_id,@Stu_pic_path,@Stu_Status,@Parent_name,@Parent_mobile,@Parent_dep)");
			SqlParameter[] parameters = {
					new SqlParameter("@Stu_id", SqlDbType.VarChar,20),
					new SqlParameter("@Stu_name", SqlDbType.VarChar,30),
					new SqlParameter("@Stu_birthday", SqlDbType.DateTime),
					new SqlParameter("@Stu_grade", SqlDbType.VarChar,10),
					new SqlParameter("@Stu_school_id", SqlDbType.Int,4),
					new SqlParameter("@Stu_pic_path", SqlDbType.VarChar,50),
					new SqlParameter("@Stu_Status", SqlDbType.Bit,1),
					new SqlParameter("@Parent_name", SqlDbType.VarChar,30),
					new SqlParameter("@Parent_mobile", SqlDbType.VarChar,12),
					new SqlParameter("@Parent_dep", SqlDbType.VarChar,150)};
			parameters[0].Value = model.Stu_id;
			parameters[1].Value = model.Stu_name;
			parameters[2].Value = model.Stu_birthday;
			parameters[3].Value = model.Stu_grade;
			parameters[4].Value = model.Stu_school_id;
			parameters[5].Value = model.Stu_pic_path;
			parameters[6].Value = model.Stu_Status;
			parameters[7].Value = model.Parent_name;
			parameters[8].Value = model.Parent_mobile;
			parameters[9].Value = model.Parent_dep;

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
		public bool Update(Lythen.Model.student model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update student set ");
			strSql.Append("Stu_name=@Stu_name,");
			strSql.Append("Stu_birthday=@Stu_birthday,");
			strSql.Append("Stu_grade=@Stu_grade,");
			strSql.Append("Stu_school_id=@Stu_school_id,");
			strSql.Append("Stu_pic_path=@Stu_pic_path,");
			strSql.Append("Stu_Status=@Stu_Status,");
			strSql.Append("Parent_name=@Parent_name,");
			strSql.Append("Parent_mobile=@Parent_mobile,");
			strSql.Append("Parent_dep=@Parent_dep");
			strSql.Append(" where Stu_id=@Stu_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Stu_name", SqlDbType.VarChar,30),
					new SqlParameter("@Stu_birthday", SqlDbType.DateTime),
					new SqlParameter("@Stu_grade", SqlDbType.VarChar,10),
					new SqlParameter("@Stu_school_id", SqlDbType.Int,4),
					new SqlParameter("@Stu_pic_path", SqlDbType.VarChar,50),
					new SqlParameter("@Stu_Status", SqlDbType.Bit,1),
					new SqlParameter("@Parent_name", SqlDbType.VarChar,30),
					new SqlParameter("@Parent_mobile", SqlDbType.VarChar,12),
					new SqlParameter("@Parent_dep", SqlDbType.VarChar,150),
					new SqlParameter("@Stu_id", SqlDbType.VarChar,20)};
			parameters[0].Value = model.Stu_name;
			parameters[1].Value = model.Stu_birthday;
			parameters[2].Value = model.Stu_grade;
			parameters[3].Value = model.Stu_school_id;
			parameters[4].Value = model.Stu_pic_path;
			parameters[5].Value = model.Stu_Status;
			parameters[6].Value = model.Parent_name;
			parameters[7].Value = model.Parent_mobile;
			parameters[8].Value = model.Parent_dep;
			parameters[9].Value = model.Stu_id;

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
		public bool Delete(string Stu_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from student ");
			strSql.Append(" where Stu_id=@Stu_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Stu_id", SqlDbType.VarChar,20)			};
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
			strSql.Append("delete from student ");
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
		public Lythen.Model.student GetModel(string Stu_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Stu_id,Stu_name,Stu_birthday,Stu_grade,Stu_school_id,Stu_pic_path,Stu_Status,Parent_name,Parent_mobile,Parent_dep from student ");
			strSql.Append(" where Stu_id=@Stu_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Stu_id", SqlDbType.VarChar,20)			};
			parameters[0].Value = Stu_id;

			Lythen.Model.student model=new Lythen.Model.student();
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
		public Lythen.Model.student DataRowToModel(DataRow row)
		{
			Lythen.Model.student model=new Lythen.Model.student();
			if (row != null)
			{
				if(row["Stu_id"]!=null)
				{
					model.Stu_id=row["Stu_id"].ToString();
				}
				if(row["Stu_name"]!=null)
				{
					model.Stu_name=row["Stu_name"].ToString();
				}
				if(row["Stu_birthday"]!=null && row["Stu_birthday"].ToString()!="")
				{
					model.Stu_birthday=DateTime.Parse(row["Stu_birthday"].ToString());
				}
				if(row["Stu_grade"]!=null)
				{
					model.Stu_grade=row["Stu_grade"].ToString();
				}
				if(row["Stu_school_id"]!=null && row["Stu_school_id"].ToString()!="")
				{
					model.Stu_school_id=int.Parse(row["Stu_school_id"].ToString());
				}
				if(row["Stu_pic_path"]!=null)
				{
					model.Stu_pic_path=row["Stu_pic_path"].ToString();
				}
				if(row["Stu_Status"]!=null && row["Stu_Status"].ToString()!="")
				{
					if((row["Stu_Status"].ToString()=="1")||(row["Stu_Status"].ToString().ToLower()=="true"))
					{
						model.Stu_Status=true;
					}
					else
					{
						model.Stu_Status=false;
					}
				}
				if(row["Parent_name"]!=null)
				{
					model.Parent_name=row["Parent_name"].ToString();
				}
				if(row["Parent_mobile"]!=null)
				{
					model.Parent_mobile=row["Parent_mobile"].ToString();
				}
				if(row["Parent_dep"]!=null)
				{
					model.Parent_dep=row["Parent_dep"].ToString();
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
			strSql.Append("select Stu_id,Stu_name,Stu_birthday,Stu_grade,Stu_school_id,Stu_pic_path,Stu_Status,Parent_name,Parent_mobile,Parent_dep ");
			strSql.Append(" FROM student ");
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
			strSql.Append(" Stu_id,Stu_name,Stu_birthday,Stu_grade,Stu_school_id,Stu_pic_path,Stu_Status,Parent_name,Parent_mobile,Parent_dep ");
			strSql.Append(" FROM student ");
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
			strSql.Append("select count(1) FROM student ");
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
			strSql.Append(")AS Row, T.*  from student T ");
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
			parameters[0].Value = "student";
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

