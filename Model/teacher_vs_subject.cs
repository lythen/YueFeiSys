using System;
namespace Lythen.Model
{
	/// <summary>
	/// teacher_vs_subject:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class teacher_vs_subject
	{
		public teacher_vs_subject()
		{}
		#region Model
		private int _teacher_id;
		private int _sub_id;
		/// <summary>
		/// 
		/// </summary>
		public int teacher_id
		{
			set{ _teacher_id=value;}
			get{return _teacher_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int sub_id
		{
			set{ _sub_id=value;}
			get{return _sub_id;}
		}
		#endregion Model

	}
}

