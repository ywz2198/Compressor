using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace CompressorCommon
{
    /// <summary>
    /// 数据库的操作方法
    /// </summary>
    public static class DbHelperSQL
    {
       public static string connstring = "Data Source=DESKTOP-CI02KFD;Initial Catalog=空压机试验数据;User ID=sa;Password=ftq62017";
       public static SqlConnection conn = new SqlConnection(connstring);
        /// <summary>
        /// 执行查询(Scalar)
        /// </summary>
           public static object chaxun(string sql)
           {
               using (SqlConnection conn = new SqlConnection(connstring))
               {
                   using (SqlCommand cmd = new SqlCommand(sql, conn))
                   {
                       try
                       {
                           conn.Open();
                           object id = cmd.ExecuteScalar();
                           return id;

                       }
                       catch(System.Data.SqlClient.SqlException e)
                       {
                           conn.Close();
                           throw e;
                       }

                   }

          
    }
            
        }
        /// <summary>
        /// 执行查询（Reader）
        /// </summary>
       /* public  static object read()
        {
            return
        }
        */
        /// <summary>
        /// 执行查询（NonQuery）
        /// </summary>
        public static void txs(string sql)
        {
          
            SqlCommand cmm = new SqlCommand(sql, conn);

            
           
                conn.Open();
       
            
                conn.Close();  

            
           
                    
      }
   }
}
    
