using System;
namespace Lythen.Model
{
	/// <summary>
	/// stu_result:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class stu_result
	{
		public stu_result()
		{}
		#region Model
		private int _stu_id;
		private int? _stu_lesson_id;
		private int? _stu_item_id;
		private decimal? _stu_mark;
		/// <summary>
		/// 
		/// </summary>
		public int Stu_id
		{
			set{ _stu_id=value;}
			get{return _stu_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Stu_lesson_id
		{
			set{ _stu_lesson_id=value;}
			get{return _stu_lesson_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Stu_item_id
		{
			set{ _stu_item_id=value;}
			get{return _stu_item_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Stu_mark
		{
			set{ _stu_mark=value;}
			get{return _stu_mark;}
		}
		#endregion Model

	}
}

