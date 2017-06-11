using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compressor
{
    class sp
    {
        Random m = new Random();
        public int[] a = new int[100];
        string b = null;
        /// <summary>
        /// 串口数据
        /// </summary>
        public string spd()
        {
            for (int j = 0; j < 100; j++)
            {
                a[j] = m.Next(20, 100);
                b += a[j].ToString() + " ";
            }
            return b;

        }
    }
}
