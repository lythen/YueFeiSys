using System;
namespace Lythen.Model
{
	/// <summary>
	/// Sys_job:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Sys_job
	{
		public Sys_job()
		{}
		#region Model
		private int _job_id;
		private string _job_title;
		/// <summary>
		/// 
		/// </summary>
		public int Job_id
		{
			set{ _job_id=value;}
			get{return _job_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Job_title
		{
			set{ _job_title=value;}
			get{return _job_title;}
		}
		#endregion Model

	}
}

