using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Lythen.DBUtility;//Please add references
namespace Lythen.DAL
{
    /// <summary>
    /// 数据访问类:teacher
    /// </summary>
    public partial class teacher
    {
        public teacher()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Teacher_id", "teacher");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Teacher_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from teacher");
            strSql.Append(" where Teacher_id=@Teacher_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Teacher_id", SqlDbType.Int,4)
			};
            parameters[0].Value = Teacher_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Lythen.Model.teacher model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into teacher(");
            strSql.Append("Teacher_name,Teacher_realname,Teacher_password,Teacher_mobile,Teacher_pic_path,Teacher_info,Teacher_role,Teacher_job,Teacher_sex,Teacher_email,Teacher_age)");
            strSql.Append(" values (");
            strSql.Append("@Teacher_name,@Teacher_realname,@Teacher_password,@Teacher_mobile,@Teacher_pic_path,@Teacher_info,@Teacher_role,@Teacher_job,@Teacher_sex,@Teacher_email,@Teacher_age)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Teacher_name", SqlDbType.VarChar,30),
					new SqlParameter("@Teacher_realname", SqlDbType.VarChar,50),
					new SqlParameter("@Teacher_password", SqlDbType.VarChar,36),
					new SqlParameter("@Teacher_mobile", SqlDbType.VarChar,12),
					new SqlParameter("@Teacher_pic_path", SqlDbType.VarChar,100),
					new SqlParameter("@Teacher_info", SqlDbType.Text),
					new SqlParameter("@Teacher_role", SqlDbType.Int,4),
					new SqlParameter("@Teacher_job", SqlDbType.Int,4),
					new SqlParameter("@Teacher_sex", SqlDbType.VarChar,2),
					new SqlParameter("@Teacher_email", SqlDbType.VarChar,200),
					new SqlParameter("@Teacher_age", SqlDbType.Int,4)};
            parameters[0].Value = model.Teacher_name;
            parameters[1].Value = model.Teacher_realname;
            parameters[2].Value = model.Teacher_password;
            parameters[3].Value = model.Teacher_mobile;
            parameters[4].Value = model.Teacher_pic_path;
            parameters[5].Value = model.Teacher_info;
            parameters[6].Value = model.Teacher_role;
            parameters[7].Value = model.Teacher_job;
            parameters[8].Value = model.Teacher_sex;
            parameters[9].Value = model.Teacher_email;
            parameters[10].Value = model.Teacher_age;

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
        public bool Update(Lythen.Model.teacher model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update teacher set ");
            strSql.Append("Teacher_name=@Teacher_name,");
            strSql.Append("Teacher_realname=@Teacher_realname,");
            strSql.Append("Teacher_password=@Teacher_password,");
            strSql.Append("Teacher_mobile=@Teacher_mobile,");
            strSql.Append("Teacher_pic_path=@Teacher_pic_path,");
            strSql.Append("Teacher_info=@Teacher_info,");
            strSql.Append("Teacher_role=@Teacher_role,");
            strSql.Append("Teacher_job=@Teacher_job,");
            strSql.Append("Teacher_sex=@Teacher_sex,");
            strSql.Append("Teacher_email=@Teacher_email,");
            strSql.Append("Teacher_age=@Teacher_age");
            strSql.Append(" where Teacher_id=@Teacher_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Teacher_name", SqlDbType.VarChar,30),
					new SqlParameter("@Teacher_realname", SqlDbType.VarChar,50),
					new SqlParameter("@Teacher_password", SqlDbType.VarChar,36),
					new SqlParameter("@Teacher_mobile", SqlDbType.VarChar,12),
					new SqlParameter("@Teacher_pic_path", SqlDbType.VarChar,100),
					new SqlParameter("@Teacher_info", SqlDbType.Text),
					new SqlParameter("@Teacher_role", SqlDbType.Int,4),
					new SqlParameter("@Teacher_job", SqlDbType.Int,4),
					new SqlParameter("@Teacher_sex", SqlDbType.VarChar,2),
					new SqlParameter("@Teacher_email", SqlDbType.VarChar,200),
					new SqlParameter("@Teacher_age", SqlDbType.Int,4),
					new SqlParameter("@Teacher_id", SqlDbType.Int,4)};
            parameters[0].Value = model.Teacher_name;
            parameters[1].Value = model.Teacher_realname;
            parameters[2].Value = model.Teacher_password;
            parameters[3].Value = model.Teacher_mobile;
            parameters[4].Value = model.Teacher_pic_path;
            parameters[5].Value = model.Teacher_info;
            parameters[6].Value = model.Teacher_role;
            parameters[7].Value = model.Teacher_job;
            parameters[8].Value = model.Teacher_sex;
            parameters[9].Value = model.Teacher_email;
            parameters[10].Value = model.Teacher_age;
            parameters[11].Value = model.Teacher_id;

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
        public bool Delete(int Teacher_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from teacher ");
            strSql.Append(" where Teacher_id=@Teacher_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Teacher_id", SqlDbType.Int,4)
			};
            parameters[0].Value = Teacher_id;

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
        public bool DeleteList(string Teacher_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from teacher ");
            strSql.Append(" where Teacher_id in (" + Teacher_idlist + ")  ");
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
        public Lythen.Model.teacher GetModel(int Teacher_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Teacher_id,Teacher_name,Teacher_realname,Teacher_password,Teacher_mobile,Teacher_pic_path,Teacher_info,Teacher_role,Teacher_job,Teacher_sex,Teacher_email,Teacher_age from teacher ");
            strSql.Append(" where Teacher_id=@Teacher_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Teacher_id", SqlDbType.Int,4)
			};
            parameters[0].Value = Teacher_id;

            Lythen.Model.teacher model = new Lythen.Model.teacher();
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
        public Lythen.Model.teacher DataRowToModel(DataRow row)
        {
            Lythen.Model.teacher model = new Lythen.Model.teacher();
            if (row != null)
            {
                if (row["Teacher_id"] != null && row["Teacher_id"].ToString() != "")
                {
                    model.Teacher_id = int.Parse(row["Teacher_id"].ToString());
                }
                if (row["Teacher_name"] != null)
                {
                    model.Teacher_name = row["Teacher_name"].ToString();
                }
                if (row["Teacher_realname"] != null)
                {
                    model.Teacher_realname = row["Teacher_realname"].ToString();
                }
                if (row["Teacher_password"] != null)
                {
                    model.Teacher_password = row["Teacher_password"].ToString();
                }
                if (row["Teacher_mobile"] != null)
                {
                    model.Teacher_mobile = row["Teacher_mobile"].ToString();
                }
                if (row["Teacher_pic_path"] != null)
                {
                    model.Teacher_pic_path = row["Teacher_pic_path"].ToString();
                }
                if (row["Teacher_info"] != null)
                {
                    model.Teacher_info = row["Teacher_info"].ToString();
                }
                if (row["Teacher_role"] != null && row["Teacher_role"].ToString() != "")
                {
                    model.Teacher_role = int.Parse(row["Teacher_role"].ToString());
                }
                if (row["Teacher_job"] != null && row["Teacher_job"].ToString() != "")
                {
                    model.Teacher_job = int.Parse(row["Teacher_job"].ToString());
                }
                if (row["Teacher_sex"] != null)
                {
                    model.Teacher_sex = row["Teacher_sex"].ToString();
                }
                if (row["Teacher_email"] != null)
                {
                    model.Teacher_email = row["Teacher_email"].ToString();
                }
                if (row["Teacher_age"] != null && row["Teacher_age"].ToString() != "")
                {
                    model.Teacher_age = int.Parse(row["Teacher_age"].ToString());
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
            strSql.Append("select Teacher_id,Teacher_name,Teacher_realname,Teacher_password,Teacher_mobile,Teacher_pic_path,Teacher_info,Teacher_role,Teacher_job,Teacher_sex,Teacher_email,Teacher_age ");
            strSql.Append(" FROM teacher ");
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
            strSql.Append(" Teacher_id,Teacher_name,Teacher_realname,Teacher_password,Teacher_mobile,Teacher_pic_path,Teacher_info,Teacher_role,Teacher_job,Teacher_sex,Teacher_email,Teacher_age ");
            strSql.Append(" FROM teacher ");
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
            strSql.Append("select count(1) FROM teacher ");
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
                strSql.Append("order by T.Teacher_id desc");
            }
            strSql.Append(")AS Row, T.*  from teacher T ");
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
            parameters[0].Value = "teacher";
            parameters[1].Value = "Teacher_id";
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
        /// 登陆
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Login(string username, string password)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from teacher");
            strSql.Append(" where Teacher_name=@Teacher_name and Teacher_password=@Teacher_password");
            SqlParameter[] parameters = {
					new SqlParameter("@Teacher_name", SqlDbType.VarChar,30),
					new SqlParameter("@Teacher_password", SqlDbType.VarChar,36)
			};
            parameters[0].Value = username;
            parameters[1].Value = password;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 获取教师角色和个人信息
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public DataSet GetTeacherRole(string username)
        {
            string sql = "select Teacher_id,Teacher_name,Teacher_realname,Teacher_role,Role_name from teacher inner join sys_role on Role_id=Teacher_role where Teacher_name=@Teacher_name";
            SqlParameter[] parameters = {
					new SqlParameter("@Teacher_name", SqlDbType.VarChar,30)
			};
            parameters[0].Value = username;
            return DbHelperSQL.Query(sql, parameters);
        }
        /// <summary>
        /// 获取教师列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetTeacherList()
        {
            string sql = "select Teacher_id,Teacher_sex,Teacher_name,Teacher_realname,Teacher_job,Teacher_role,Role_name from teacher left join sys_role on Role_id=Teacher_role";
            return DbHelperSQL.Query(sql);
        }
        /// <summary>
        /// 获取教师详细信息
        /// </summary>
        /// <param name="Teacher_id"></param>
        /// <returns></returns>
        public DataSet GetDetail(int Teacher_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Teacher_id,Teacher_name,Teacher_realname,Teacher_mobile,Teacher_pic_path,Teacher_info,Teacher_role,Teacher_job,Teacher_sex,Teacher_email,Teacher_age from teacher ");
            strSql.Append(" where Teacher_id=@Teacher_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Teacher_id", SqlDbType.Int,4)
			};
            parameters[0].Value = Teacher_id;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        #endregion  ExtensionMethod
    }
}

