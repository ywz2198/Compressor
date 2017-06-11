using System;
using System.Collections.Generic;
using System.Text;

namespace Compressor.Model
{
	/// <summary>
	/// CardInfo 实体类
	/// BY：狂人代码生成器 V1.0
	/// 作者：金属狂人
	/// 日期：2017年05月11日 02:23:48
	/// </summary>
	public class CardInfo
	{
		private string  _CardID;
		/// <summary>
		/// 获取或设置 CardID 的值
		/// </summary>
		public string  CardID
		{
			get { return _CardID; }
			set { _CardID = value; }
		}

		private string _Name;
		/// <summary>
		/// 获取或设置 Name 的值
		/// </summary>
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		private string _Job;
		/// <summary>
		/// 获取或设置 Job 的值
		/// </summary>
		public string Job
		{
			get { return _Job; }
			set { _Job = value; }
		}
        /// <summary>
        /// 获取或设置Age的值
        /// </summary>
        public string _Age;
        public string Age
        {
            get { return _Age; }
            set { _Age = value; }
        }




    }
}
