using System;
namespace Lythen.Model
{
	/// <summary>
	/// course:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class course
	{
		public course()
		{}
		#region Model
		private int _course_id;
		private string _course_title;
		private int? _course_sub_id;
		private int? _course_teacher_id;
		private string _course_date;
		private DateTime? _course_time;
		private string _course_info;
		private int? _course_choool_id;
		private decimal? _course_cost;
		private bool _course_status;
		/// <summary>
		/// 
		/// </summary>
		public int Course_id
		{
			set{ _course_id=value;}
			get{return _course_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Course_title
		{
			set{ _course_title=value;}
			get{return _course_title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Course_sub_id
		{
			set{ _course_sub_id=value;}
			get{return _course_sub_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Course_teacher_id
		{
			set{ _course_teacher_id=value;}
			get{return _course_teacher_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Course_date
		{
			set{ _course_date=value;}
			get{return _course_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Course_time
		{
			set{ _course_time=value;}
			get{return _course_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Course_info
		{
			set{ _course_info=value;}
			get{return _course_info;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Course_choool_id
		{
			set{ _course_choool_id=value;}
			get{return _course_choool_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Course_cost
		{
			set{ _course_cost=value;}
			get{return _course_cost;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool Course_status
		{
			set{ _course_status=value;}
			get{return _course_status;}
		}
		#endregion Model

	}
}

