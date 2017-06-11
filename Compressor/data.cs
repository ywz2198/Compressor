using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Drawing.Imaging;
namespace Compressor
{
    class data
    {
        public static string connString = "Data Source=DESKTOP-CI02KFD;Initial Catalog=空压机试验数据;User ID=sa;Password=ftq62017";
        public SqlConnection connection = new SqlConnection(connString);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="l"></param>
        public int add(string l,float g, float q,Int64 p)
        {
            string sql = string.Format("insert into 实验数据(流量,功率,气压,批次号)values('{0}','{1}','{2}','{3}')", l, g, q ,p);
            SqlCommand comm = new SqlCommand(sql, connection);         
             connection.Open();
            if (comm.ExecuteNonQuery()>0)
            {
                connection.Close();
                return 1;
            }
            else
            {
                connection.Close();
                return 0;
            }

        }
        /// <summary>
        /// 回读数据
        /// </summary>
        public string insert(Int64 i)
        {
            string sql = string.Format("select 功率,气压,流量 FROM 实验数据 where 批次号='{0}'", i);
            SqlCommand comm = new SqlCommand(sql, connection);
           
                string liuliang;
                connection.Open();
                SqlDataReader shuju = comm.ExecuteReader();
                if (shuju.Read())
                {
                    liuliang= (string)shuju ["流量"];
                    
                    shuju.Close();
                return liuliang;
                }
                
                connection.Close();
            return "读取出错";

        }
        /// <summary>
        /// 读取生产批号
        /// </summary>
        /// <param name="i"></param>
        public Int64 insert1()
        {

            string sql = string.Format("select max(批次号) as 'number' from 实验数据");
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            Int64 id1 = Int64.Parse(command.ExecuteScalar().ToString());
            connection.Close();
            return id1;
        }
        /// <summary>
        /// 删除
        /// </summary>
        public void delete(Int64 i)
        {
            string sql = string.Format("delete from 实验数据 where 批次号='{0}'", i);
            SqlCommand comm = new SqlCommand(sql, connection);
            try
            {
                connection.Open();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
        /// <summary>
        /// 生成批次号
        /// </summary>
        /// <returns></returns>
        public Int64 create()
        {
            string sql = string.Format("select max(批次号) as 'number' from 实验数据");
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            Int64 id1 = Int64.Parse(command.ExecuteScalar().ToString());
            connection.Close();
            Int64 number = Int64.Parse(System.DateTime.Now.ToString("yyyyMMdd"));
            if (number * 10000 > id1)
            {
                id1 = number * 10000;
            }
            id1++;
            return id1;
        }
        /// <summary>
        /// 图片保存
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public void addphoto()
        {

        }
           
        

    }
}
