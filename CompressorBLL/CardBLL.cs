using System;
using System.Collections.Generic;
using System.Text;
using Compressor.Model;
using  Compressor.DAL;

namespace Compressor.BLL
{
	/// <summary>
	/// CardBLL类
	/// BY：狂人代码生成器 V1.0
	/// 作者：金属狂人
	/// 日期：2017年05月11日 02:23:48
	/// </summary>
	public class CardBLL
	{


		/// <summary>
		/// 获取所有信息集合
		/// </summary>
		/// <returns>List集合</returns>
		public static List<CardInfo> GetCardInfoList(string where)
		{
			try
			{
				return CardDAL.GetCardInfoList(where);
			}
			catch
			{
				throw;
			}
		}

		/// <summary>
		/// 根据 主键 获取一个实体对象
		/// <param name="CardID">主键</param>
		/// </summary>
		public static CardInfo GetCardInfoById(string CardID)
		{
			try
			{
				return CardDAL.GetCardInfoById(CardID);
			}
			catch
			{
				throw;
			}
		}

		/// 添加数据
		/// </summary>
		/// <param name="info">数据表实体对象</param>
		public static bool AddCard(CardInfo info)
		{
			try
			{
				return CardDAL.AddCard(info);
			}
			catch
			{
				throw;
			}
		}

		/// <summary>
		/// 根据主键删除一个对象
		/// </summary>
		/// <param name="_CardID">主键</param>
		/// <returns></returns>
		public static bool DeleteCardInfo(CardInfo info)
		{
			try
			{
				return CardDAL.DeleteCardInfo(info);
			}
			catch
			{
				throw;
			}
		}

		/// 更新数据
		/// </summary>
		/// <param name="info">数据表实体</param>
		public static bool UpdateCardInfo(CardInfo info)
		{
			try
			{
				return CardDAL.UpdateCardInfo(info);
			}
			catch
			{
				throw;
			}
		}
	}
}
