using System;
using System.Collections.Generic;
using System.Text;
using Compressor.Model;
using System.Data.SqlClient;
using CompressorCommon;

namespace CompressorDAL
{
    public class CmIDDAL
    {
        /// <summary>
        /// 添加数据
        /// </summary>
        public static void add(CompressorModel.CmID d)
        {
           
            String sql=string.Format("insert into 空压机试验性能数据表(CmID,Type,Time,Image,Operator,Code) value('{0}','{1}','{2}','{3}','{4}','{5}')", d.Cmid, d.Time, d.Image,d.Type, d.Operation, d.Code);
            DbHelperSQL.txs(sql);
        }
     
    }
}
