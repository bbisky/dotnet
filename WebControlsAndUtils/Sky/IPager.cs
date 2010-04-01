using System;

namespace Sky.WebControls
{
	/// <summary>
	/// IPager ��ժҪ˵����
	/// </summary>
	public interface IPager
	{
		/// <summary>
		/// 
		/// </summary>
		int PageSize
		{
			set;
			get;
		}
		/// <summary>
		/// 
		/// </summary>
		int ItemCount
		{
			set;
			get;
		}
		/// <summary>
		/// 
		/// </summary>
		int PageIndex
		{
			set;
			get;
		}

	}
}
