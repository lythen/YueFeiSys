using System;
namespace Lythen.Model
{
	/// <summary>
	/// role_vs_subject:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class role_vs_subject
	{
		public role_vs_subject()
		{}
		#region Model
		private int _role_id;
		private string _sub_list;
		/// <summary>
		/// 
		/// </summary>
		public int role_id
		{
			set{ _role_id=value;}
			get{return _role_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sub_list
		{
			set{ _sub_list=value;}
			get{return _sub_list;}
		}
		#endregion Model

	}
}

