using System;
namespace Lythen.Model
{
	/// <summary>
	/// subject_score_ item:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class subject_score_item
	{
		public subject_score_item()
		{}
		#region Model
		private int _item_id;
		private int? _item_subject_id;
		private string _item_title;
		/// <summary>
		/// 
		/// </summary>
		public int item_id
		{
			set{ _item_id=value;}
			get{return _item_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? item_subject_id
		{
			set{ _item_subject_id=value;}
			get{return _item_subject_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string item_title
		{
			set{_item_title=value;}
			get{return _item_title;}
		}
		#endregion Model

	}
}

