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
		public bool Exists(string stu_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from student");
			strSql.Append(" where stu_id=@stu_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@stu_id", SqlDbType.VarChar,20)			};
			parameters[0].Value = stu_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Lythen.Model.student model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into student(");
			strSql.Append("stu_id,stu_name,stu_birthday,stu_grade,stu_school_id,stu_pic_path,stu_Status,stu_sex,stu_age,parent_name,parent_mobile,parent_dep,parent_email,address)");
			strSql.Append(" values (");
			strSql.Append("@stu_id,@stu_name,@stu_birthday,@stu_grade,@stu_school_id,@stu_pic_path,@stu_Status,@stu_sex,@stu_age,@parent_name,@parent_mobile,@parent_dep,@parent_email,@address)");
			SqlParameter[] parameters = {
					new SqlParameter("@stu_id", SqlDbType.VarChar,20),
					new SqlParameter("@stu_name", SqlDbType.VarChar,30),
					new SqlParameter("@stu_birthday", SqlDbType.DateTime),
					new SqlParameter("@stu_grade", SqlDbType.Int,4),
					new SqlParameter("@stu_school_id", SqlDbType.Int,4),
					new SqlParameter("@stu_pic_path", SqlDbType.VarChar,50),
					new SqlParameter("@stu_Status", SqlDbType.Bit,1),
					new SqlParameter("@stu_sex", SqlDbType.VarChar,2),
					new SqlParameter("@stu_age", SqlDbType.Int,4),
					new SqlParameter("@parent_name", SqlDbType.VarChar,30),
					new SqlParameter("@parent_mobile", SqlDbType.VarChar,12),
					new SqlParameter("@parent_dep", SqlDbType.VarChar,150),
					new SqlParameter("@parent_email", SqlDbType.VarChar,250),
					new SqlParameter("@address", SqlDbType.VarChar,250)};
			parameters[0].Value = model.stu_id;
			parameters[1].Value = model.stu_name;
			parameters[2].Value = model.stu_birthday;
			parameters[3].Value = model.stu_grade;
			parameters[4].Value = model.stu_school_id;
			parameters[5].Value = model.stu_pic_path;
			parameters[6].Value = model.stu_Status;
			parameters[7].Value = model.stu_sex;
			parameters[8].Value = model.stu_age;
			parameters[9].Value = model.parent_name;
			parameters[10].Value = model.parent_mobile;
			parameters[11].Value = model.parent_dep;
			parameters[12].Value = model.parent_email;
			parameters[13].Value = model.address;

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
			strSql.Append("stu_name=@stu_name,");
			strSql.Append("stu_birthday=@stu_birthday,");
			strSql.Append("stu_grade=@stu_grade,");
			strSql.Append("stu_school_id=@stu_school_id,");
			strSql.Append("stu_pic_path=@stu_pic_path,");
			strSql.Append("stu_Status=@stu_Status,");
			strSql.Append("stu_sex=@stu_sex,");
			strSql.Append("stu_age=@stu_age,");
			strSql.Append("parent_name=@parent_name,");
			strSql.Append("parent_mobile=@parent_mobile,");
			strSql.Append("parent_dep=@parent_dep,");
			strSql.Append("parent_email=@parent_email,");
			strSql.Append("address=@address");
			strSql.Append(" where stu_id=@stu_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@stu_name", SqlDbType.VarChar,30),
					new SqlParameter("@stu_birthday", SqlDbType.DateTime),
					new SqlParameter("@stu_grade", SqlDbType.Int,4),
					new SqlParameter("@stu_school_id", SqlDbType.Int,4),
					new SqlParameter("@stu_pic_path", SqlDbType.VarChar,50),
					new SqlParameter("@stu_Status", SqlDbType.Bit,1),
					new SqlParameter("@stu_sex", SqlDbType.VarChar,2),
					new SqlParameter("@stu_age", SqlDbType.Int,4),
					new SqlParameter("@parent_name", SqlDbType.VarChar,30),
					new SqlParameter("@parent_mobile", SqlDbType.VarChar,12),
					new SqlParameter("@parent_dep", SqlDbType.VarChar,150),
					new SqlParameter("@parent_email", SqlDbType.VarChar,250),
					new SqlParameter("@address", SqlDbType.VarChar,250),
					new SqlParameter("@stu_id", SqlDbType.VarChar,20)};
			parameters[0].Value = model.stu_name;
			parameters[1].Value = model.stu_birthday;
			parameters[2].Value = model.stu_grade;
			parameters[3].Value = model.stu_school_id;
			parameters[4].Value = model.stu_pic_path;
			parameters[5].Value = model.stu_Status;
			parameters[6].Value = model.stu_sex;
			parameters[7].Value = model.stu_age;
			parameters[8].Value = model.parent_name;
			parameters[9].Value = model.parent_mobile;
			parameters[10].Value = model.parent_dep;
			parameters[11].Value = model.parent_email;
			parameters[12].Value = model.address;
			parameters[13].Value = model.stu_id;

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
		public bool Delete(string stu_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from student ");
			strSql.Append(" where stu_id=@stu_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@stu_id", SqlDbType.VarChar,20)			};
			parameters[0].Value = stu_id;

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
		public bool DeleteList(string stu_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from student ");
			strSql.Append(" where stu_id in ("+stu_idlist + ")  ");
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
		public Lythen.Model.student GetModel(string stu_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 stu_id,stu_name,stu_birthday,stu_grade,stu_school_id,stu_pic_path,stu_Status,stu_sex,stu_age,parent_name,parent_mobile,parent_dep,parent_email,address from student ");
			strSql.Append(" where stu_id=@stu_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@stu_id", SqlDbType.VarChar,20)			};
			parameters[0].Value = stu_id;

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
				if(row["stu_id"]!=null)
				{
					model.stu_id=row["stu_id"].ToString();
				}
				if(row["stu_name"]!=null)
				{
					model.stu_name=row["stu_name"].ToString();
				}
				if(row["stu_birthday"]!=null && row["stu_birthday"].ToString()!="")
				{
					model.stu_birthday=DateTime.Parse(row["stu_birthday"].ToString());
				}
				if(row["stu_grade"]!=null && row["stu_grade"].ToString()!="")
				{
					model.stu_grade=int.Parse(row["stu_grade"].ToString());
				}
				if(row["stu_school_id"]!=null && row["stu_school_id"].ToString()!="")
				{
					model.stu_school_id=int.Parse(row["stu_school_id"].ToString());
				}
				if(row["stu_pic_path"]!=null)
				{
					model.stu_pic_path=row["stu_pic_path"].ToString();
				}
				if(row["stu_Status"]!=null && row["stu_Status"].ToString()!="")
				{
					if((row["stu_Status"].ToString()=="1")||(row["stu_Status"].ToString().ToLower()=="true"))
					{
						model.stu_Status=true;
					}
					else
					{
						model.stu_Status=false;
					}
				}
				if(row["stu_sex"]!=null)
				{
					model.stu_sex=row["stu_sex"].ToString();
				}
				if(row["stu_age"]!=null && row["stu_age"].ToString()!="")
				{
					model.stu_age=int.Parse(row["stu_age"].ToString());
				}
				if(row["parent_name"]!=null)
				{
					model.parent_name=row["parent_name"].ToString();
				}
				if(row["parent_mobile"]!=null)
				{
					model.parent_mobile=row["parent_mobile"].ToString();
				}
				if(row["parent_dep"]!=null)
				{
					model.parent_dep=row["parent_dep"].ToString();
				}
				if(row["parent_email"]!=null)
				{
					model.parent_email=row["parent_email"].ToString();
				}
				if(row["address"]!=null)
				{
					model.address=row["address"].ToString();
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
			strSql.Append("select stu_id,stu_name,stu_birthday,stu_grade,stu_school_id,stu_pic_path,stu_Status,stu_sex,stu_age,parent_name,parent_mobile,parent_dep,parent_email,address ");
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
			strSql.Append(" stu_id,stu_name,stu_birthday,stu_grade,stu_school_id,stu_pic_path,stu_Status,stu_sex,stu_age,parent_name,parent_mobile,parent_dep,parent_email,address ");
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
				strSql.Append("order by T.stu_id desc");
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
			parameters[1].Value = "stu_id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod
        public DataSet GetStudentList(int PageSize, int PageIndex, int school_id, int grade, string sex, string stu_name, string parent_name)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@pagesize", SqlDbType.Int),
					new SqlParameter("@pageindex", SqlDbType.Int),
					new SqlParameter("@school_id", SqlDbType.Int),
					new SqlParameter("@grade", SqlDbType.Int),
					new SqlParameter("@sex", SqlDbType.VarChar, 255),
					new SqlParameter("@stu_nme", SqlDbType.VarChar, 255),
					new SqlParameter("@parent_name", SqlDbType.VarChar, 255)
					};
            parameters[0].Value = PageSize;
            parameters[1].Value = PageIndex;
            parameters[2].Value = school_id;
            parameters[3].Value = grade;
            parameters[4].Value = sex;
            parameters[5].Value = stu_name;
            parameters[6].Value = parent_name;
            return DbHelperSQL.RunProcedure("proGetStudentList", parameters, "ds");
        }
        public DataSet GetStudent(string stu_id)
        {
            string sql = "select stu_id,stu_name,stu_grade,stu_school_id,stu_sex,stu_age,parent_name,parent_mobile,parent_dep,parent_email,[address] from student where stu_id=@stu_id";

            SqlParameter[] parameters = {
					new SqlParameter("@stu_id", SqlDbType.VarChar, 20)
					};
            parameters[0].Value = stu_id;
            return DbHelperSQL.Query(sql, parameters);
        }
        public bool DeleteStudent(string list)
        {
            string sql = string.Format("delete from student where stu_id in ({0})",list);
            if (DbHelperSQL.ExecuteSql(sql) > 0) return true;
            else return false;
        }
		#endregion  ExtensionMethod
	}
}

