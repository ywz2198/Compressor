using System;
using System.Collections.Generic;
using System.Text;
using CompressorModel;
using CompressorDAL;
using Compressor.Model;

namespace CompressorBLL
{
    /// <summary>
    /// 调用数据
    /// </summary>
    public class CmIDBLL
    {
       /* public static void Addcmid(CmID cmid)
        {
            try
            {
                 CmIDDAL.add(cmid);
            }
            catch
            {
                throw;
            }
        }*/
        public static void Add(CardInfo cmid)
        {
            try
            {
                CmIDDAL.add(cmid);

            }
            catch
            {
                throw;
            }
        }
    }
}
