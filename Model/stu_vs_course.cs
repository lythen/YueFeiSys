using System;
namespace Lythen.Model
{
	/// <summary>
	/// stu_vs_course:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class stu_vs_course
	{
		public stu_vs_course()
		{}
		#region Model
		private string _sc_stu_id;
		private int _sc_course_id;
		private DateTime? _sc_register_date;
		private string _sc_pay;
		private bool _sc_status;
		/// <summary>
		/// 
		/// </summary>
		public string Sc_stu_id
		{
			set{ _sc_stu_id=value;}
			get{return _sc_stu_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Sc_course_id
		{
			set{ _sc_course_id=value;}
			get{return _sc_course_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Sc_register_date
		{
			set{ _sc_register_date=value;}
			get{return _sc_register_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Sc_pay
		{
			set{ _sc_pay=value;}
			get{return _sc_pay;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool Sc_status
		{
			set{ _sc_status=value;}
			get{return _sc_status;}
		}
		#endregion Model

	}
}

