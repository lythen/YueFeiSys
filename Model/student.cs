﻿using System;
namespace Lythen.Model
{
	/// <summary>
	/// student:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class student
	{
		public student()
		{}
		#region Model
		private string _stu_id;
		private string _stu_name;
		private DateTime? _stu_birthday;
		private int? _stu_grade;
		private int? _stu_school_id;
		private string _stu_pic_path;
		private bool _stu_status;
		private string _parent_name;
		private string _parent_mobile;
		private string _parent_dep;
		/// <summary>
		/// 
		/// </summary>
		public string Stu_id
		{
			set{ _stu_id=value;}
			get{return _stu_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Stu_name
		{
			set{ _stu_name=value;}
			get{return _stu_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Stu_birthday
		{
			set{ _stu_birthday=value;}
			get{return _stu_birthday;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Stu_grade
		{
			set{ _stu_grade=value;}
			get{return _stu_grade;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Stu_school_id
		{
			set{ _stu_school_id=value;}
			get{return _stu_school_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Stu_pic_path
		{
			set{ _stu_pic_path=value;}
			get{return _stu_pic_path;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool Stu_Status
		{
			set{ _stu_status=value;}
			get{return _stu_status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Parent_name
		{
			set{ _parent_name=value;}
			get{return _parent_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Parent_mobile
		{
			set{ _parent_mobile=value;}
			get{return _parent_mobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Parent_dep
		{
			set{ _parent_dep=value;}
			get{return _parent_dep;}
		}
		#endregion Model

	}
}

