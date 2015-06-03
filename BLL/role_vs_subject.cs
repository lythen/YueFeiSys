using System;
using System.Data;
using System.Collections.Generic;
using Lythen.Common;
using Lythen.Model;
using System.Web;
namespace Lythen.BLL
{
	/// <summary>
	/// role_vs_subject
	/// </summary>
	public partial class role_vs_subject
	{
		private readonly Lythen.DAL.role_vs_subject dal=new Lythen.DAL.role_vs_subject();
        private const string CACHE_KEY_DATATABLE = "role_vs_subject";
        private string CachePath = HttpContext.Current.Server.MapPath("~/DataCache/");
		public role_vs_subject()
		{}
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
		public bool Exists(int role_id)
		{
			return dal.Exists(role_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Lythen.Model.role_vs_subject model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Lythen.Model.role_vs_subject model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int role_id)
		{
			
			return dal.Delete(role_id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string role_idlist )
		{
			return dal.DeleteList(Lythen.Common.PageValidate.SafeLongFilter(role_idlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Lythen.Model.role_vs_subject GetModel(int role_id)
		{
			
			return dal.GetModel(role_id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Lythen.Model.role_vs_subject GetModelByCache(int role_id)
		{
			
			string CacheKey = "role_vs_subjectModel-" + role_id;
			object objModel = Lythen.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(role_id);
					if (objModel != null)
					{
						int ModelCache = Lythen.Common.ConfigHelper.GetConfigInt("ModelCache");
						Lythen.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Lythen.Model.role_vs_subject)objModel;
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Lythen.Model.role_vs_subject> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Lythen.Model.role_vs_subject> DataTableToList(DataTable dt)
		{
			List<Lythen.Model.role_vs_subject> modelList = new List<Lythen.Model.role_vs_subject>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Lythen.Model.role_vs_subject model;
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
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}
        DataTable GetManagerSubjectByCache(int role_id){
            string cache_key = CACHE_KEY_DATATABLE + role_id;
            object objDataTable = null; //Lythen.Common.DataCache.GetCache(cache_key);
            if (objDataTable == null)
            {
                try
                {
                    objDataTable = dal.GetManagerSubject(role_id).Tables[0];
                    if (objDataTable != null)
                    {
                        int ModelCache = Lythen.Common.ConfigHelper.GetConfigInt("DataTableCache");
                        Lythen.Common.DataCache.SetCache(cache_key, objDataTable, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch(Exception ex) { }
            }
            return (DataTable)objDataTable;
        }
		#endregion  BasicMethod
		#region  ExtensionMethod
        public String Update(string subList,int myrole_id,int role_id)
        {
            string[] list = subList.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            if (list == null || list.Length == 0)
                return "noselect";
            //查询出当前管理员所管理的科目
            DataTable dtRoleSub = GetManagerSubjectByCache(myrole_id);
            if (dtRoleSub.Rows.Count == 0) return "nopower";

            //查询传入的科目是否有不包含在当前管理员的科目中的
            bool isContain = false;
            foreach (string sub_id in list)
            {
                isContain = false;
                int subject_id = WebUtility.FilterParam(sub_id);
                if (subject_id == 0) return "selecterror";
                foreach (DataRow dr in dtRoleSub.Rows)
                {
                    if ((int)dr["Subject_id"] == subject_id)
                    {
                        isContain = true;
                        break;
                    }
                }
                if (!isContain) return "nopower";
            }
            //判断是否有管理该角色的权限
            DataTable dtRole = new BLL.sys_role().GetDataTableByCache();
            Common.Tree.RoleTree tree = new Common.Tree.RoleTree(dtRole, 0, "Role_parent_id", "Role_id");
            tree.Creat();
            if (!tree.isParent(myrole_id, role_id)) return "nopower";
            Model.role_vs_subject modelrvs = new Model.role_vs_subject();
            modelrvs.role_id = role_id;
            modelrvs.sub_list = subList;
            if (Exists(role_id))
            {
                if (Update(modelrvs))
                    return "success";
                else return "error";
            }
            else
            {
                if(Add(modelrvs))
                    return "success";
                else return "error";
            }
        }
		#endregion  ExtensionMethod
	}
}

