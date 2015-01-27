using System;
namespace Lythen.Model
{
	/// <summary>
	/// sys_role:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class sys_role
	{
		public sys_role()
		{}
		#region Model
		private int _role_id;
		private string _role_name;
		/// <summary>
		/// 
		/// </summary>
		public int Role_id
		{
			set{ _role_id=value;}
			get{return _role_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Role_name
		{
			set{ _role_name=value;}
			get{return _role_name;}
		}
		#endregion Model

	}
}

