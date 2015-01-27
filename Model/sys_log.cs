using System;
namespace Lythen.Model
{
	/// <summary>
	/// sys_log:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class sys_log
	{
		public sys_log()
		{}
		#region Model
		private int _log_id;
		private string _log_user;
		private string _log_event;
		private DateTime? _log_date;
		/// <summary>
		/// 
		/// </summary>
		public int Log_id
		{
			set{ _log_id=value;}
			get{return _log_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Log_user
		{
			set{ _log_user=value;}
			get{return _log_user;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Log_event
		{
			set{ _log_event=value;}
			get{return _log_event;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Log_date
		{
			set{ _log_date=value;}
			get{return _log_date;}
		}
		#endregion Model

	}
}

