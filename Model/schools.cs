using System;
namespace Lythen.Model
{
	/// <summary>
	/// schools:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class schools
	{
		public schools()
		{}
		#region Model
		private int _school_id;
		private string _school_name;
		private string _school_address;
		private string _school_contact_man;
		private string _school_contact_phone;
		private string _school_info;
		/// <summary>
		/// 
		/// </summary>
		public int School_id
		{
			set{ _school_id=value;}
			get{return _school_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string School_name
		{
			set{ _school_name=value;}
			get{return _school_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string School_address
		{
			set{ _school_address=value;}
			get{return _school_address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string School_contact_man
		{
			set{ _school_contact_man=value;}
			get{return _school_contact_man;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string School_contact_phone
		{
			set{ _school_contact_phone=value;}
			get{return _school_contact_phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string School_info
		{
			set{ _school_info=value;}
			get{return _school_info;}
		}
		#endregion Model

	}
}

