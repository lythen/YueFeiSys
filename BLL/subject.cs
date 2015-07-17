using System;
using System.Data;
using System.Collections.Generic;
using Lythen.Common;
using Lythen.Model;
using System.Web;
using System.IO;
using System.Text;
namespace Lythen.BLL
{
    /// <summary>
    /// subject
    /// </summary>
    public partial class subject
    {
        private readonly Lythen.DAL.subject dal = new Lythen.DAL.subject();
        private string CachePath = HttpContext.Current.Server.MapPath("~/DataCache/");
        public subject()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Subject_id)
        {
            return dal.Exists(Subject_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Lythen.Model.subject model)
        {
            return dal.Add(model);
        }
        public string Add(int parent_id, string subject_title)
        {
            if (dal.Exists(parent_id, subject_title)) return "exists";
            else
            {
                Model.subject model = new Model.subject();
                model.Subject_parent = parent_id;
                model.Subject_title = subject_title;
                model.Subject_info = "";
                if (Add(model) > 0) return "success";
                else return "error";
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Lythen.Model.subject model)
        {
            return dal.Update(model);
        }
        public string Update(int Subject_id, int Parent_id, string Subject_title)
        {
            if (dal.Exists(Parent_id, Subject_title)) return "该父科目下已存在所修改子科目名称。";
            Model.subject model = GetModelByCache(Subject_id);
            if (model == null) return "所选科目不存在或已删除。";
            model.Subject_parent = Parent_id;
            model.Subject_title = Subject_title;
            if (Update(model)) return "success";
            else return "error";

        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Subject_id)
        {

            return dal.Delete(Subject_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int DeleteList(string Subject_idlist)
        {
            return dal.DeleteList(Lythen.Common.PageValidate.SafeLongFilter(Subject_idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Lythen.Model.subject GetModel(int Subject_id)
        {

            return dal.GetModel(Subject_id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Lythen.Model.subject GetModelByCache(int Subject_id)
        {

            string CacheKey = "subjectModel-" + Subject_id;
            object objModel = Lythen.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(Subject_id);
                    if (objModel != null)
                    {
                        int ModelCache = Lythen.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Lythen.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Lythen.Model.subject)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Lythen.Model.subject> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Lythen.Model.subject> DataTableToList(DataTable dt)
        {
            List<Lythen.Model.subject> modelList = new List<Lythen.Model.subject>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Lythen.Model.subject model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 获取全部列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetListForTable()
        {
            return dal.GetListForTable();
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 获取轻量级数据
        /// </summary>
        /// <returns></returns>
        public DataSet GetLiteList()
        {
            return dal.GetLiteList();
        }
        /// <summary>
        /// 从缓存中取科目
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableByCache()
        {
            string cache_file = CachePath + "cache_subject.xml";
            DataTable dt;
            if (!File.Exists(cache_file)) goto next;
            else
            {
                dt = new DataTable();
                dt.ReadXml(cache_file);
                if (dt.Rows.Count == 0) goto next;
                else return dt;
            }
        next:
            dt = GetLiteList().Tables[0];
            dt.WriteXml(cache_file, XmlWriteMode.WriteSchema);
            return dt;

        }
        /// <summary>
        /// 根据文本查找科目ID
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public int GetIdByText(string text)
        {
            DataTable dtSub = GetDataTableByCache();
            foreach (DataRow dr in dtSub.Rows)
            {
                if (dr["Subject_title"].ToString() == text)
                    return (int)dr["Subject_id"];
            }
            return 0;
        }
        /// <summary>
        /// 返回下拉列表所需要的JSON
        /// </summary>
        /// <param name="IdIsTxt">ID的参数是否为科目的title，即ID，与txt一样，都是名称</param>
        /// <returns></returns>
        public string GetListJson()
        {
            if (!Directory.Exists(CachePath)) Directory.CreateDirectory(CachePath);
            string  file_path = CachePath + "subject.txt";
            StringBuilder sb = new StringBuilder();
            if (!File.Exists(file_path))
            {
                sb.Append("[{\"id\":0,\"text\":\"请选择科目\",\"children\":[");
                DataTable dtSub = new Lythen.BLL.subject().GetList("").Tables[0];
                if (dtSub.Rows.Count == 0)
                {
                    sb.Append("	]}]");
                    return sb.ToString();
                }
                else
                {
                    DataRow[] drs = dtSub.Select("Subject_parent=0");
                    int len = drs.Length;
                    foreach (DataRow dr in drs)
                    {
                        len--;
                        WriteNode(dr, dtSub, sb, len);
                    }
                }
                sb.Append("]}]");
                StreamWriter sw = new StreamWriter(file_path);
                sw.Write(sb.ToString());
                sw.Flush();
                sw.Close();
                return sb.ToString();
            }
            else
            {

                StreamReader sr = new StreamReader(file_path);
                string str = sr.ReadToEnd();
                sr.Close();
                return str;
            }
        }
        void WriteNode(DataRow dr, DataTable dtsub, StringBuilder sb, int len)
        {
            sb.Append("{\"id\":").Append(dr["Subject_id"]).Append(",\"text\":\"").Append(dr["Subject_title"]).Append("\"");

            DataRow[] drs = dtsub.Select("Subject_parent=" + dr["Subject_id"].ToString());
            if (drs.Length == 0)
            {
                sb.Append("}");
                if (len > 0) sb.Append(",");
                return;
            }
            sb.Append(",\"children\":[");
            int lenc = drs.Length;
            foreach (DataRow drc in drs)
            {
                lenc--;
                WriteNode(drc, dtsub, sb, lenc);
            }
            sb.Append("]}");
            if (len > 0) sb.Append(",");
        }
        #endregion  ExtensionMethod
    }
}

