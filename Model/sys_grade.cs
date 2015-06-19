using System;
namespace Lythen.Model
{
	/// <summary>
	/// sys_grade:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class sys_grade
	{
		public sys_grade()
		{}
		#region Model
		private int _g_id;
		private string _g_title;
		/// <summary>
		/// 
		/// </summary>
		public int g_id
		{
			set{ _g_id=value;}
			get{return _g_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string g_title
		{
			set{ _g_title=value;}
			get{return _g_title;}
		}
		#endregion Model

	}
}

