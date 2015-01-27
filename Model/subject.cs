using System;
namespace Lythen.Model
{
	/// <summary>
	/// subject:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class subject
	{
		public subject()
		{}
		#region Model
		private int _subject_id;
		private string _subject_title;
		private string _subject_info;
		private int? _subject_parent;
		/// <summary>
		/// 
		/// </summary>
		public int Subject_id
		{
			set{ _subject_id=value;}
			get{return _subject_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Subject_title
		{
			set{ _subject_title=value;}
			get{return _subject_title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Subject_info
		{
			set{ _subject_info=value;}
			get{return _subject_info;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Subject_parent
		{
			set{ _subject_parent=value;}
			get{return _subject_parent;}
		}
		#endregion Model

	}
}

