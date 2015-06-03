using System;
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
		private string _teacher_realname;
		private string _teacher_password;
		private string _teacher_mobile;
		private string _teacher_pic_path;
		private string _teacher_info;
		private int? _teacher_role;
		private int? _teacher_job;
		private string _teacher_sex;
		private string _teacher_email;
		private int? _teacher_age;
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
		public string Teacher_realname
		{
			set{ _teacher_realname=value;}
			get{return _teacher_realname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Teacher_password
		{
			set{ _teacher_password=value;}
			get{return _teacher_password;}
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
		/// <summary>
		/// 
		/// </summary>
		public string Teacher_sex
		{
			set{ _teacher_sex=value;}
			get{return _teacher_sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Teacher_email
		{
			set{ _teacher_email=value;}
			get{return _teacher_email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Teacher_age
		{
			set{ _teacher_age=value;}
			get{return _teacher_age;}
		}
		#endregion Model

	}
}

