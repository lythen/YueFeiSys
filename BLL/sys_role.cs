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
    /// sys_role
    /// </summary>
    public partial class sys_role
    {
        private readonly Lythen.DAL.sys_role dal = new Lythen.DAL.sys_role();
        private const string CACHE_KEY_DATATABLE = "sys_role";
        private string CachePath = HttpContext.Current.Server.MapPath("~/DataCache/");
        public sys_role()
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
        public bool Exists(int Role_id)
        {
            return dal.Exists(Role_id);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string Role_name)
        {
            return dal.Exists(Role_name);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Lythen.Model.sys_role model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Lythen.Model.sys_role model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Role_id)
        {
            return dal.Delete(Role_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string Role_idlist)
        {
            return dal.DeleteList(Lythen.Common.PageValidate.SafeLongFilter(Role_idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Lythen.Model.sys_role GetModel(int Role_id)
        {

            return dal.GetModel(Role_id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Lythen.Model.sys_role GetModelByCache(int Role_id)
        {

            string CacheKey = "sys_roleModel-" + Role_id;
            object objModel = Lythen.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(Role_id);
                    if (objModel != null)
                    {
                        int ModelCache = Lythen.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Lythen.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Lythen.Model.sys_role)objModel;
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
        public List<Lythen.Model.sys_role> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Lythen.Model.sys_role> DataTableToList(DataTable dt)
        {
            List<Lythen.Model.sys_role> modelList = new List<Lythen.Model.sys_role>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Lythen.Model.sys_role model;
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
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        /// <summary>
        /// 得到DataTable，从缓存中
        /// </summary>
        public DataTable GetDataTableByCache()
        {
            object objDataTable = Lythen.Common.DataCache.GetCache(CACHE_KEY_DATATABLE);
            if (objDataTable == null)
            {
                try
                {
                    objDataTable = dal.GetRolesList().Tables[0];
                    if (objDataTable != null)
                    {
                        int ModelCache = Lythen.Common.ConfigHelper.GetConfigInt("DataTableCache");
                        Lythen.Common.DataCache.SetCache(CACHE_KEY_DATATABLE, objDataTable, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (DataTable)objDataTable;
        }

        /// <summary>
        /// 清空DataTableCache缓存
        /// </summary>
        public void ClearDataTableCache(int role_id)
        {
            string cache_key = CACHE_KEY_DATATABLE;
            if (role_id != 0) cache_key = cache_key + role_id;
            Lythen.Common.DataCache.RemoveAllCache();
        }
        /// <summary>
        /// 获取管理下的全部角色
        /// </summary>
        /// <param name="role_id"></param>
        /// <returns></returns>
        private DataTable GetManagerRole(int role_id)
        {
            DataTable dtRole = GetDataTableByCache();
            //管理员返回全部数据
            if (role_id == 1) return dtRole;
            DataTable ReRole = dtRole.Clone();
            //添加当前角色本身
            DataRow[] drmy = dtRole.Select("Role_id=" + role_id);
            if (drmy.Length == 0) return ReRole;
            ReRole.Rows.Add(drmy[0].ItemArray);
            //添加角色所管理的其他角色
            DataRow[] drs = dtRole.Select("Role_parent_id=" + role_id);
            if (drs.Length == 0) return ReRole;
            foreach (DataRow dr in drs)
            {
                ReRole.Rows.Add(dr.ItemArray);
                RecursiveRole(dtRole, ReRole, (int)dr["Role_id"]);
            }
            return ReRole;
        }
        /// <summary>
        /// 管辖内的科目
        /// </summary>
        /// <param name="role_id"></param>
        /// <returns></returns>
        public DataTable GetManagerRoleByCache(int role_id)
        {
            string cache_key = CACHE_KEY_DATATABLE + role_id;
            object objDataTable = Lythen.Common.DataCache.GetCache(cache_key);
            if (objDataTable == null)
            {
                try
                {
                    objDataTable = dal.GetRolesList().Tables[0];
                    if (objDataTable != null)
                    {
                        int ModelCache = Lythen.Common.ConfigHelper.GetConfigInt("DataTableCache");
                        Lythen.Common.DataCache.SetCache(cache_key, objDataTable, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (DataTable)objDataTable;
        }
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="dtRole"></param>
        /// <param name="ReRole"></param>
        /// <param name="role_id"></param>
        private void RecursiveRole(DataTable dtRole, DataTable ReRole, int role_id)
        {
            DataRow[] drs = dtRole.Select("Role_parent_id=" + role_id);
            if (drs.Length == 0) return;
            foreach (DataRow dr in drs)
            {
                ReRole.Rows.Add(dr.ItemArray);
                RecursiveRole(dtRole, ReRole, (int)dr["Role_id"]);
            }
        }
        /// <summary>
        /// 根据文本取ID
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public int GetIDByText(string text)
        {
            DataTable dtRole = GetDataTableByCache();
            foreach (DataRow dr in dtRole.Rows)
            {
                if (dr["Role_name"].ToString() == text)
                    return (int)dr["Role_id"];
            }
            return 0;
        }
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="role_name"></param>
        /// <param name="parent_title"></param>
        /// <returns></returns>
        public string Add(int myrole_id, string role_name, int parent_id)
        {
            if (parent_id == 0)
                return "pdelete";
            //只能把角色添加到自己管辖的科目范围内
            DataTable dtRole = GetManagerRoleByCache(myrole_id);
            DataRow[] drs = dtRole.Select("Role_id=" + parent_id);
            if (drs.Length == 0) return "nopower";

            if (Exists(role_name)) return "exists";
            Model.sys_role model = new Model.sys_role();
            model.Role_name = role_name;
            model.Role_parent_id = parent_id;
            if (Add(model) > 0)
            {
                DeleteCache(parent_id);
                return "success";
            }
            else return "error";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="myrole_id">提交修改的角色ID</param>
        /// <param name="role_id">要修改的角色ID</param>
        /// <param name="role_name">要修改的角色名称</param>
        /// <param name="parent_title">要修改为的角色父角色</param>
        /// <returns></returns>
        public string Edit(int myrole_id, int role_id, string role_name, string parent_title)
        {
            if (dal.Exists(role_id, role_name)) return "exists";
            int parent_id = GetIDByText(parent_title.Trim());
            if (parent_id == 0)//添加时有人删除了父科目
                return "pdelete";
            //只能把角色添加到自己管辖的科目范围内
            DataTable dtRole = GetManagerRoleByCache(myrole_id);
            DataRow[] drs = dtRole.Select("Role_id=" + parent_id);
            if (drs.Length == 0) return "nopower";
            Model.sys_role model = GetModel(role_id);
            if (model == null) return "delete";
            model.Role_name = role_name;
            model.Role_parent_id = parent_id;
            if (Update(model))
            {
                DeleteCache(parent_id);
                return "success";
            }
            else return "error";
        }
        public string Delete(int myRole_id, int deRole_id)
        {
            if (deRole_id == 1) return "cannot";
            if (myRole_id == deRole_id) return "cannot";
            //只能删除自己管理的角色
            DataTable dtRole = GetManagerRoleByCache(myRole_id);
            DataRow[] drs = dtRole.Select("Role_id=" + deRole_id);
            if (drs.Length == 0) return "nopower";
            if (Delete(deRole_id))
            {
                DeleteCache(myRole_id);
                return "success";
            }
            else return "error";
        }
        public string GetJsonList(int role_id, bool istxt)
        {
            string path;
            if (istxt)
                path = string.Format("{0}role_{1}txt.txt", CachePath, role_id);
            else path = string.Format("{0}role_{1}id.txt", CachePath, role_id);
            StringBuilder sb = new StringBuilder();
            if (!File.Exists(path))
            {
                sb.Append("[{\"id\":0,\"text\":\"请选择角色\",\"children\":[");
                DataTable dtRole = GetManagerRoleByCache(role_id);
                if (dtRole.Rows.Count == 0)
                {
                    sb.Append("	]}]");
                    return sb.ToString();
                }
                else
                {
                    DataRow[] drs = dtRole.Select("Role_id=" + role_id);
                    int len = drs.Length;
                    foreach (DataRow dr in drs)
                    {
                        len--;
                        WriteNode(dr, dtRole, sb, len, istxt);
                    }
                }
                sb.Append("]}]");
                StreamWriter sw = new StreamWriter(path);
                sw.Write(sb.ToString());
                sw.Flush();
                sw.Close();
                return sb.ToString();
            }
            else
            {

                StreamReader sr = new StreamReader(path);
                string str = sr.ReadToEnd();
                sr.Close();
                return str;
            }
        }
        void WriteNode(DataRow dr, DataTable dtRole, StringBuilder sb, int len,bool istxt)
        {
            if(istxt)
            sb.Append("{\"id\":\"").Append(dr["Role_name"]).Append("\",\"text\":\"").Append(dr["Role_name"]).Append("\",\"children\":[");
            else sb.Append("{\"id\":\"").Append(dr["Role_id"]).Append("\",\"text\":\"").Append(dr["Role_name"]).Append("\",\"children\":[");
            DataRow[] drs = dtRole.Select("Role_parent_id=" + dr["Role_id"].ToString());
            if (drs.Length == 0)
            {
                sb.Append("]}");
                if (len > 0) sb.Append(",");
                return;
            }
            int lenc = drs.Length;
            foreach (DataRow drc in drs)
            {
                lenc--;
                WriteNode(drc, dtRole, sb, lenc, istxt);
            }
            sb.Append("]}");
            if (len > 0) sb.Append(",");
        }
        void DeleteCache(int role_id)
        {
            ClearDataTableCache(0);
            DataTable dt = GetDataTableByCache();
            foreach (DataRow dr in dt.Rows)
            {
                string path1 = string.Format("{0}role_{1}txt.txt", CachePath, dr["Role_id"].ToString());
                string path2 = string.Format("{0}role_{1}id.txt", CachePath, dr["Role_id"].ToString());
                if (File.Exists(path1))
                {
                    try
                    {
                        File.Delete(path1);
                    }
                    catch (IOException) { }
                }
                if (File.Exists(path2))
                {
                    try
                    {
                        File.Delete(path2);
                    }
                    catch (IOException) { }
                }
            }
        }
        /// <summary>
        /// 根据角色ID取角色详细
        /// </summary>
        /// <param name="role_id"></param>
        /// <returns></returns>
        public DataTable GetList(int Role_id, int set_role_id)
        {
            //0 角色  1 当前角色管理的科目 2要修改的角色管理的科目
            DataSet ds = dal.GetList(Role_id, set_role_id);
            if (ds.Tables[0].Rows.Count == 0) return null;
            int row2Len = ds.Tables[2].Rows.Count;
            Common.Tree.RoleTree tree = new Common.Tree.RoleTree(ds.Tables[1], "Subject_parent", "Subject_id", "Subject_title");
            Common.Tree.Node[] nodes = tree.CreateUnknowRootTree();
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            int len = 0;
            foreach (int index in nodes[0].Child)
            {
                if (len > 0) sb.Append(",");
                sb.Append("{").Append("\"id\":").Append(nodes[index].Weight).Append(",\"text\":\"").Append(nodes[index].Name).Append("\",\"state\":\"open\"");
                if (row2Len > 0)
                {
                    DataRow[] drs = ds.Tables[2].Select("Subject_id=" + nodes[index].Weight);
                    if (drs.Length > 0)
                        sb.Append(",\"checked\":true");
                }
                if (nodes[index].Child.Count > 0)
                {
                    sb.Append(",\"children\":[");
                    RecursiveSetRBJson(sb, nodes, index, ds.Tables[2], row2Len);
                    sb.Append("]");
                }
                sb.Append("}");
                len++;
            }
            sb.Append("]");

            DataTable outtable = new DataTable("table");
            outtable.Columns.Add(new DataColumn("dtrole", typeof(DataTable)));
            outtable.Columns.Add(new DataColumn("subjson", typeof(string)));
            DataRow dr = outtable.NewRow();
            dr[0] = ds.Tables[0].Copy();
            if (sb.Length < 3)
                dr[1] = "nodata";
            else dr[1] = sb.ToString();
            outtable.Rows.Add(dr);
            return outtable;
        }
        private void RecursiveSetRBJson(StringBuilder sb, Common.Tree.Node[] nodes, int parent, DataTable dt2, int row2Len)
        {
            int len = 0;
            foreach (int index in nodes[parent].Child)
            {
                if (len > 0) sb.Append(",");
                sb.Append("{").Append("\"id\":").Append(nodes[index].Weight).Append(",\"text\":\"").Append(nodes[index].Name).Append("\",\"state\":\"open\"");
                if (row2Len > 0)
                {
                    DataRow[] drs = dt2.Select("Subject_id=" + nodes[index].Weight);
                    if (drs.Length > 0)
                        sb.Append(",\"checked\":true");
                }
                if (nodes[index].Child.Count > 0)
                {
                    sb.Append(",\"children\":[");
                    RecursiveSetRBJson(sb, nodes, index, dt2, row2Len);
                    sb.Append("]");
                }
                sb.Append("}");
                len++;
            }
        }
        #endregion  ExtensionMethod
    }
}

