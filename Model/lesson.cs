using System;
namespace Lythen.Model
{
	/// <summary>
	/// lesson:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class lesson
	{
		public lesson()
		{}
		#region Model
		private int _lesson_id;
		private int? _lesson_subject_id;
		private string _lesson_title;
		private string _lesson_info;
		/// <summary>
		/// 
		/// </summary>
		public int Lesson_id
		{
			set{ _lesson_id=value;}
			get{return _lesson_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Lesson_subject_id
		{
			set{ _lesson_subject_id=value;}
			get{return _lesson_subject_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Lesson_title
		{
			set{ _lesson_title=value;}
			get{return _lesson_title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Lesson_info
		{
			set{ _lesson_info=value;}
			get{return _lesson_info;}
		}
		#endregion Model

	}
}

