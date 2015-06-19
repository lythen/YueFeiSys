using System;
namespace Lythen.Model
{
	/// <summary>
	/// sys_stu_school:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class sys_stu_school
	{
		public sys_stu_school()
		{}
		#region Model
		private int _ss_id;
		private string _ss_title;
		/// <summary>
		/// 
		/// </summary>
		public int ss_id
		{
			set{ _ss_id=value;}
			get{return _ss_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ss_title
		{
			set{ _ss_title=value;}
			get{return _ss_title;}
		}
		#endregion Model

	}
}

