using System;
using System.Collections.Generic;
using System.Text;

namespace Compressor.Model
{
	/// <summary>
	/// CardInfo ʵ����
	/// BY�����˴��������� V1.0
	/// ���ߣ���������
	/// ���ڣ�2017��05��11�� 02:23:48
	/// </summary>
	public class CardInfo
	{
		private string  _CardID;
		/// <summary>
		/// ��ȡ������ CardID ��ֵ
		/// </summary>
		public string  CardID
		{
			get { return _CardID; }
			set { _CardID = value; }
		}

		private string _Name;
		/// <summary>
		/// ��ȡ������ Name ��ֵ
		/// </summary>
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		private string _Job;
		/// <summary>
		/// ��ȡ������ Job ��ֵ
		/// </summary>
		public string Job
		{
			get { return _Job; }
			set { _Job = value; }
		}
        /// <summary>
        /// ��ȡ������Age��ֵ
        /// </summary>
        public string _Age;
        public string Age
        {
            get { return _Age; }
            set { _Age = value; }
        }




    }
}
