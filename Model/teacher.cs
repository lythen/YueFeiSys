﻿using System;
namespace Lythen.Model
{
	/// <summary>
	/// teacher:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class teacher
	{
		public teacher()
		{}
		#region Model
		private int _teacher_id;
		private string _teacher_name;
		private string _teacher_mobile;
		private string _teacher_pic_path;
		private string _teacher_info;
		private int? _teacher_role;
		private int? _teacher_job;
		/// <summary>
		/// 
		/// </summary>
		public int Teacher_id
		{
			set{ _teacher_id=value;}
			get{return _teacher_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Teacher_name
		{
			set{ _teacher_name=value;}
			get{return _teacher_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Teacher_mobile
		{
			set{ _teacher_mobile=value;}
			get{return _teacher_mobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Teacher_pic_path
		{
			set{ _teacher_pic_path=value;}
			get{return _teacher_pic_path;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Teacher_info
		{
			set{ _teacher_info=value;}
			get{return _teacher_info;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Teacher_role
		{
			set{ _teacher_role=value;}
			get{return _teacher_role;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Teacher_job
		{
			set{ _teacher_job=value;}
			get{return _teacher_job;}
		}
		#endregion Model

	}
}

