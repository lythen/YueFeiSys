using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Lythen.DBUtility;//Please add references
namespace Lythen.DAL
{
    /// <summary>
    /// 数据访问类:course
    /// </summary>
    public partial class course
    {
        public course()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Course_id", "course");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Course_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from course");
            strSql.Append(" where Course_id=@Course_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Course_id", SqlDbType.Int,4)
			};
            parameters[0].Value = Course_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Course_sub_id, string Course_title)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from course");
            strSql.Append(" where Course_sub_id=@Course_sub_id");
            strSql.Append(" and Course_title=@Course_title");
            SqlParameter[] parameters = {
					new SqlParameter("@Course_sub_id", SqlDbType.Int,4),
					new SqlParameter("@Course_title", SqlDbType.VarChar,50)
			};
            parameters[0].Value = Course_sub_id;
            parameters[1].Value = Course_title;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Lythen.Model.course model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into course(");
            strSql.Append("Course_title,Course_sub_id,Course_teacher_id,Course_date,Course_time,Course_info,Course_choool_id,Course_cost,Course_status)");
            strSql.Append(" values (");
            strSql.Append("@Course_title,@Course_sub_id,@Course_teacher_id,@Course_date,@Course_time,@Course_info,@Course_choool_id,@Course_cost,@Course_status)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Course_title", SqlDbType.VarChar,50),
					new SqlParameter("@Course_sub_id", SqlDbType.Int,4),
					new SqlParameter("@Course_teacher_id", SqlDbType.Int,4),
					new SqlParameter("@Course_date", SqlDbType.VarChar,1000),
					new SqlParameter("@Course_time", SqlDbType.Time,5),
					new SqlParameter("@Course_info", SqlDbType.VarChar,5000),
					new SqlParameter("@Course_choool_id", SqlDbType.Int,4),
					new SqlParameter("@Course_cost", SqlDbType.Money,8),
					new SqlParameter("@Course_status", SqlDbType.Char,1)};
            parameters[0].Value = model.Course_title;
            parameters[1].Value = model.Course_sub_id;
            parameters[2].Value = model.Course_teacher_id;
            parameters[3].Value = model.Course_date;
            parameters[4].Value = model.Course_time;
            parameters[5].Value = model.Course_info;
            parameters[6].Value = model.Course_choool_id;
            parameters[7].Value = model.Course_cost;
            parameters[8].Value = model.Course_status;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(Lythen.Model.course model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update course set ");
            strSql.Append("Course_title=@Course_title,");
            strSql.Append("Course_sub_id=@Course_sub_id,");
            strSql.Append("Course_teacher_id=@Course_teacher_id,");
            strSql.Append("Course_date=@Course_date,");
            strSql.Append("Course_time=@Course_time,");
            strSql.Append("Course_info=@Course_info,");
            strSql.Append("Course_choool_id=@Course_choool_id,");
            strSql.Append("Course_cost=@Course_cost,");
            strSql.Append("Course_status=@Course_status");
            strSql.Append(" where Course_id=@Course_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Course_title", SqlDbType.VarChar,50),
					new SqlParameter("@Course_sub_id", SqlDbType.Int,4),
					new SqlParameter("@Course_teacher_id", SqlDbType.Int,4),
					new SqlParameter("@Course_date", SqlDbType.VarChar,1000),
					new SqlParameter("@Course_time", SqlDbType.Time,5),
					new SqlParameter("@Course_info", SqlDbType.VarChar,5000),
					new SqlParameter("@Course_choool_id", SqlDbType.Int,4),
					new SqlParameter("@Course_cost", SqlDbType.Money,8),
					new SqlParameter("@Course_status", SqlDbType.Char,1),
					new SqlParameter("@Course_id", SqlDbType.Int,4)};
            parameters[0].Value = model.Course_title;
            parameters[1].Value = model.Course_sub_id;
            parameters[2].Value = model.Course_teacher_id;
            parameters[3].Value = model.Course_date;
            parameters[4].Value = model.Course_time;
            parameters[5].Value = model.Course_info;
            parameters[6].Value = model.Course_choool_id;
            parameters[7].Value = model.Course_cost;
            parameters[8].Value = model.Course_status;
            parameters[9].Value = model.Course_id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(int Course_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from course ");
            strSql.Append(" where Course_id=@Course_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Course_id", SqlDbType.Int,4)
			};
            parameters[0].Value = Course_id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string Course_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from course ");
            strSql.Append(" where Course_id in (" + Course_idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public Lythen.Model.course GetModel(int Course_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Course_id,Course_title,Course_sub_id,Course_teacher_id,Course_date,Course_time,Course_info,Course_choool_id,Course_cost,Course_status from course ");
            strSql.Append(" where Course_id=@Course_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Course_id", SqlDbType.Int,4)
			};
            parameters[0].Value = Course_id;

            Lythen.Model.course model = new Lythen.Model.course();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public Lythen.Model.course DataRowToModel(DataRow row)
        {
            Lythen.Model.course model = new Lythen.Model.course();
            if (row != null)
            {
                if (row["Course_id"] != null && row["Course_id"].ToString() != "")
                {
                    model.Course_id = int.Parse(row["Course_id"].ToString());
                }
                if (row["Course_title"] != null)
                {
                    model.Course_title = row["Course_title"].ToString();
                }
                if (row["Course_sub_id"] != null && row["Course_sub_id"].ToString() != "")
                {
                    model.Course_sub_id = int.Parse(row["Course_sub_id"].ToString());
                }
                if (row["Course_teacher_id"] != null && row["Course_teacher_id"].ToString() != "")
                {
                    model.Course_teacher_id = int.Parse(row["Course_teacher_id"].ToString());
                }
                if (row["Course_date"] != null)
                {
                    model.Course_date = row["Course_date"].ToString();
                }
                if (row["Course_time"] != null && row["Course_time"].ToString() != "")
                {
                    model.Course_time = DateTime.Parse(row["Course_time"].ToString());
                }
                if (row["Course_info"] != null)
                {
                    model.Course_info = row["Course_info"].ToString();
                }
                if (row["Course_choool_id"] != null && row["Course_choool_id"].ToString() != "")
                {
                    model.Course_choool_id = int.Parse(row["Course_choool_id"].ToString());
                }
                if (row["Course_cost"] != null && row["Course_cost"].ToString() != "")
                {
                    model.Course_cost = decimal.Parse(row["Course_cost"].ToString());
                }
                if (row["Course_status"] != null)
                {
                    model.Course_status = row["Course_status"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Course_id,Course_title,Course_sub_id,Course_teacher_id,Course_date,Course_time,Course_info,Course_choool_id,Course_cost,Course_status ");
            strSql.Append(" FROM course ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" Course_id,Course_title,Course_sub_id,Course_teacher_id,Course_date,Course_time,Course_info,Course_choool_id,Course_cost,Course_status ");
            strSql.Append(" FROM course ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM course ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.Course_id desc");
            }
            strSql.Append(")AS Row, T.*  from course T ");
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
            parameters[0].Value = "course";
            parameters[1].Value = "Course_id";
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
        /// 获取课程列表
        /// </summary>
        /// <param name="subject_id"></param>
        /// <param name="teacher_id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public DataSet GetListForTable(int subject_id, int teacher_id, string status,string stu_id)
        {
            string sql = @"select Course_id,Course_title,Subject_title,Teacher_realname,Course_sub_id,Course_teacher_id,Course_info,
Course_cost,Course_status,Course_date,Sc_stu_id 
from course 
left join [subject] on Subject_id=Course_sub_id 
left join teacher on Teacher_id=Course_teacher_id 
left join stu_vs_course on Sc_course_id=Course_id and Sc_stu_id=@Sc_stu_id 
where Course_sub_id=(case when @subject_id=0 then  Course_sub_id else @subject_id end) 
and Course_teacher_id=(case when @teacher_id=0 then  Course_teacher_id else @teacher_id end) 
and Course_status=(case when @status='0' then  Course_status else @status end) order by Sc_stu_id desc";
            SqlParameter[] parameters = {
					new SqlParameter("@subject_id", SqlDbType.Int,4),
					new SqlParameter("@teacher_id", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.Char,1),
					new SqlParameter("@Sc_stu_id", SqlDbType.VarChar,20)};
            parameters[0].Value = subject_id;
            parameters[1].Value = teacher_id;
            parameters[2].Value = status;
            parameters[3].Value = stu_id;
            return DbHelperSQL.Query(sql, parameters);
        }
        /// <summary>
        /// 选择课程的总价格
        /// </summary>
        /// <param name="list_id"></param>
        /// <returns>表1：总价，表2：各课程价格</returns>
        public DataSet getSUMCost(string list_id)
        {
            string sql = string.Format("select SUM(Course_cost) from course where Course_id in({0});select Course_id,Course_cost from course where Course_id in({0})", list_id);
            return DbHelperSQL.Query(sql);
        }
        /// <summary>
        /// 获取课程列表，传入0表示获取全部课程
        /// </summary>
        /// <param name="sub_id"></param>
        /// <returns></returns>
        public DataSet GetLiteList(int subject_id)
        {
            string sql = "select Course_id,Course_title from course where Course_sub_id=(case when @subject_id=0 then Course_sub_id else @subject_id end)";
            SqlParameter[] parameters = {
					new SqlParameter("@subject_id", SqlDbType.Int,4)};
            parameters[0].Value = subject_id;
            return DbHelperSQL.Query(sql, parameters);
        }
        #endregion  ExtensionMethod
    }
}

