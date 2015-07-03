using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Lythen.DBUtility;//Please add references
namespace Lythen.DAL
{
	/// <summary>
	/// 数据访问类:stu_vs_course
	/// </summary>
	public partial class stu_vs_course
	{
		public stu_vs_course()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Sc_course_id", "stu_vs_course"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Sc_stu_id,int Sc_course_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from stu_vs_course");
			strSql.Append(" where Sc_stu_id=@Sc_stu_id and Sc_course_id=@Sc_course_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Sc_stu_id", SqlDbType.VarChar,20),
					new SqlParameter("@Sc_course_id", SqlDbType.Int,4)			};
			parameters[0].Value = Sc_stu_id;
			parameters[1].Value = Sc_course_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Lythen.Model.stu_vs_course model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into stu_vs_course(");
			strSql.Append("Sc_stu_id,Sc_course_id,Sc_register_date,Sc_pay,Sc_status)");
			strSql.Append(" values (");
			strSql.Append("@Sc_stu_id,@Sc_course_id,@Sc_register_date,@Sc_pay,@Sc_status)");
			SqlParameter[] parameters = {
					new SqlParameter("@Sc_stu_id", SqlDbType.VarChar,20),
					new SqlParameter("@Sc_course_id", SqlDbType.Int,4),
					new SqlParameter("@Sc_register_date", SqlDbType.DateTime),
					new SqlParameter("@Sc_pay", SqlDbType.VarChar,50),
					new SqlParameter("@Sc_status", SqlDbType.Bit,1)};
			parameters[0].Value = model.Sc_stu_id;
			parameters[1].Value = model.Sc_course_id;
			parameters[2].Value = model.Sc_register_date;
			parameters[3].Value = model.Sc_pay;
			parameters[4].Value = model.Sc_status;

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
		public bool Update(Lythen.Model.stu_vs_course model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update stu_vs_course set ");
			strSql.Append("Sc_register_date=@Sc_register_date,");
			strSql.Append("Sc_pay=@Sc_pay,");
			strSql.Append("Sc_status=@Sc_status");
			strSql.Append(" where Sc_stu_id=@Sc_stu_id and Sc_course_id=@Sc_course_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Sc_register_date", SqlDbType.DateTime),
					new SqlParameter("@Sc_pay", SqlDbType.VarChar,50),
					new SqlParameter("@Sc_status", SqlDbType.Bit,1),
					new SqlParameter("@Sc_stu_id", SqlDbType.VarChar,20),
					new SqlParameter("@Sc_course_id", SqlDbType.Int,4)};
			parameters[0].Value = model.Sc_register_date;
			parameters[1].Value = model.Sc_pay;
			parameters[2].Value = model.Sc_status;
			parameters[3].Value = model.Sc_stu_id;
			parameters[4].Value = model.Sc_course_id;

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
		public bool Delete(string Sc_stu_id,int Sc_course_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from stu_vs_course ");
			strSql.Append(" where Sc_stu_id=@Sc_stu_id and Sc_course_id=@Sc_course_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Sc_stu_id", SqlDbType.VarChar,20),
					new SqlParameter("@Sc_course_id", SqlDbType.Int,4)			};
			parameters[0].Value = Sc_stu_id;
			parameters[1].Value = Sc_course_id;

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
		public Lythen.Model.stu_vs_course GetModel(string Sc_stu_id,int Sc_course_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Sc_stu_id,Sc_course_id,Sc_register_date,Sc_pay,Sc_status from stu_vs_course ");
			strSql.Append(" where Sc_stu_id=@Sc_stu_id and Sc_course_id=@Sc_course_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Sc_stu_id", SqlDbType.VarChar,20),
					new SqlParameter("@Sc_course_id", SqlDbType.Int,4)			};
			parameters[0].Value = Sc_stu_id;
			parameters[1].Value = Sc_course_id;

			Lythen.Model.stu_vs_course model=new Lythen.Model.stu_vs_course();
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
		public Lythen.Model.stu_vs_course DataRowToModel(DataRow row)
		{
			Lythen.Model.stu_vs_course model=new Lythen.Model.stu_vs_course();
			if (row != null)
			{
				if(row["Sc_stu_id"]!=null)
				{
					model.Sc_stu_id=row["Sc_stu_id"].ToString();
				}
				if(row["Sc_course_id"]!=null && row["Sc_course_id"].ToString()!="")
				{
					model.Sc_course_id=int.Parse(row["Sc_course_id"].ToString());
				}
				if(row["Sc_register_date"]!=null && row["Sc_register_date"].ToString()!="")
				{
					model.Sc_register_date=DateTime.Parse(row["Sc_register_date"].ToString());
				}
				if(row["Sc_pay"]!=null)
				{
					model.Sc_pay=row["Sc_pay"].ToString();
				}
				if(row["Sc_status"]!=null && row["Sc_status"].ToString()!="")
				{
					if((row["Sc_status"].ToString()=="1")||(row["Sc_status"].ToString().ToLower()=="true"))
					{
						model.Sc_status=true;
					}
					else
					{
						model.Sc_status=false;
					}
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
			strSql.Append("select Sc_stu_id,Sc_course_id,Sc_register_date,Sc_pay,Sc_status ");
			strSql.Append(" FROM stu_vs_course ");
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
			strSql.Append(" Sc_stu_id,Sc_course_id,Sc_register_date,Sc_pay,Sc_status ");
			strSql.Append(" FROM stu_vs_course ");
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
			strSql.Append("select count(1) FROM stu_vs_course ");
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
				strSql.Append("order by T.Sc_course_id desc");
			}
			strSql.Append(")AS Row, T.*  from stu_vs_course T ");
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
			parameters[0].Value = "stu_vs_course";
			parameters[1].Value = "Sc_course_id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod
        /// <summary>
        /// 报名课程
        /// </summary>
        /// <param name="listCourse"></param>
        /// <param name="cost"></param>
        /// <returns></returns>
        public bool AddStudentCourse(int[] listCourse, decimal[] cost,string stu_id)
        {
            StringBuilder sbsql = new StringBuilder();
            DateTime dt = DateTime.Now;
            int len = listCourse.Length;
            for (int i = 0; i < len; i++)
            {
                sbsql.Append("if not exists(select Sc_stu_id from stu_vs_course where Sc_stu_id='").Append(stu_id).Append("' and Sc_course_id=").Append(listCourse[i]);
                sbsql.Append(") begin insert into stu_vs_course(Sc_stu_id,Sc_course_id,Sc_register_date,Sc_pay,Sc_status) values ('").Append(stu_id).Append("',").Append(listCourse[i]);
                sbsql.Append(",'").Append(dt).Append("','").Append(cost[i]).Append("','1') end else begin update stu_vs_course set Sc_register_date='").Append(dt).Append("',Sc_pay='").Append(cost[i]).Append("',Sc_status='1' where Sc_stu_id='").Append(stu_id).Append("' and Sc_course_id=").Append(listCourse[i]).Append(" end;");
            }
            int row = DbHelperSQL.ExecuteSql(sbsql.ToString());
            if (row == len) return true;
            else return false;
        }
        public DataSet GetStudentCourse(string stu_id)
        {
            string sql = @"select Sc_stu_id,Course_id,Course_title,Sc_pay,Teacher_realname,Course_info,Subject_title
from stu_vs_course
left join course on Sc_course_id=Course_id
left join teacher on Course_teacher_id=Teacher_id
left join [subject] on Course_sub_id=Subject_id
where Sc_stu_id=@Sc_stu_id";
            SqlParameter[] parameters = {
					new SqlParameter("@Sc_stu_id", SqlDbType.VarChar, 20)
					};
            parameters[0].Value = stu_id;
            return DbHelperSQL.Query(sql,parameters);
        }
		#endregion  ExtensionMethod
	}
}

