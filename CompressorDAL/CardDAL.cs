using System;
using System.Collections.Generic;
using System.Text;
using Compressor.Model;
using System.Data.SqlClient;

namespace Compressor.DAL
{
	/// <summary>
	/// CardDAL类
	/// BY：狂人代码生成器 V1.0
	/// 作者：金属狂人
	/// 日期：2017年05月11日 02:23:48
	/// </summary>
	public class CardDAL
	{

		/// <summary>
		/// 获取所有信息
		/// </summary>
		/// <param name="where">条件</param>
		/// <returns>结果集</returns>
		public static SqlDataReader GetCardInfo(string where)
		{
			string sqlStr = "SELECT * FROM Card where ";
			if (String.IsNullOrEmpty(where))
			{
				sqlStr += "1=1";
			}
			else
			{
				sqlStr += where;
			}
			SqlDataReader reader = null;
			try
			{
				reader = DBManager.ExecuteQuery(sqlStr);
			}
			catch(Exception ex)
			{
				throw ex;
			}
			return reader;
		}

		/// <summary>
		/// 获取所有信息集合
		/// </summary>
		/// <returns>List集合</returns>
		public static List<CardInfo> GetCardInfoList(string where)
		{
			List<CardInfo> infoList = new List<CardInfo>();

			SqlDataReader reader = null;
			try
			{
				reader = GetCardInfo(where);
			}
			catch (Exception)
			{
				throw;
			}

			while (reader.Read())
			{
				CardInfo info = new CardInfo();
				info.CardID=reader["CardID"].ToString();
				info.Name=reader["Name"].ToString();
				info.Job=reader["Job"].ToString();
				infoList.Add(info);
			}
			reader.Close();
			return infoList;
		}

		/// <summary>
		/// 根据 主键 获取一个实体对象
		/// <param name="CardID">主键</param>
		/// </summary>
		public static CardInfo GetCardInfoById(string CardID)
		{
			string strWhere = "CardID =" + CardID;
			List<CardInfo> list = GetCardInfoList(strWhere);
			if (list.Count > 0)
			return list[0];
			return null;
		}
        public static bool Ifexist(string CardID)
        {
            string str = "select * from Card where CardID = " + CardID;
            SqlDataReader rd= DBManager.ExecuteQuery(str);
            if (rd.HasRows)
                return true;
            else
                return false;
        }
		/// 添加数据
		/// </summary>
		/// <param name="info">数据表实体对象</param>
		public static bool AddCard(CardInfo info)
		{
            string _CardID = info.CardID;
			string _Name = info.Name;
			string _Job = info.Job;

			string sql="INSERT INTO Card VALUES (@_CardID,@_Name,@_Job)";
			int rst = DBManager.ExecuteUpdate(sql, new object[] {new SqlParameter("@_CardID",_CardID ), new SqlParameter("@_Name",_Name),new SqlParameter("@_Job",_Job) });
			if(rst>0)
			{ 
				return true;
			}
			else
			{ 
				return false;
			}
		}
		/// <summary>
		/// 删除一个对象
		/// </summary>
		/// <param name="CardID">主键</param>
		/// <returns></returns>
		public static bool DeleteCardInfo(CardInfo info)
		{
			bool rst = false;
			string sqlStr = "DELETE FROM Card WHERE CardID=" + info.CardID;
			int rows = DBManager.ExecuteUpdate(sqlStr);
			if (rows>0)
			{
				rst = true;
			}
			return rst;
		}

		/// 更新数据
		/// </summary>
		/// <param name="info">数据表实体</param>
		public static bool UpdateCardInfo(CardInfo info)
		{
			string _Name = info.Name;
			string _Job = info.Job;
			string sql="UPDATE Card SET Name=@_Name, Job=@_Job  WHERE CardID="+info.CardID;
			int rst = DBManager.ExecuteUpdate(sql, new object[] { new SqlParameter("@_Name",_Name),new SqlParameter("@_Job",_Job) });
			if(rst>0)
			{ 
				return true;
			}
			else
			{ 
				return false;
			}
		}
	}
}
