using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using com.google.zxing;
namespace Compressor
{
    public partial class ICON : Form
    {

        public ICON()
        {
            InitializeComponent();
        }
        private string  GetSeriesNumber(string serial)
        {
            DateTime current = new DateTime();
            current = DateTime.Now;
            string date = current.ToString("yyyyMMdd");
            return date+serial;
        }
     
        data d = new data();
        private void ICON_Load(object sender, EventArgs e)
        {
           
           
            
          
            

        }
       /// <summary>
       /// 生成二维码
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
          
            try
            {
              
                
                    
                    string file = System.DateTime.Now.ToString("yyymmddhhmmss");

                    string adress = System.AppDomain.CurrentDomain.BaseDirectory+"\\"+"二维码"+"\\"+file+".png";
                   
                    string content =d.insert1().ToString();
                label3.Text = content;
                    com.google.zxing.common.ByteMatrix mode = new MultiFormatWriter().encode(content, BarcodeFormat.QR_CODE, 350, 350);
                    picture(mode, adress);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
      /// <summary>
      /// 显示二维码
      /// </summary>
      /// <param name="mode"></param>
      /// <param name="format"></param>
      /// <param name="file"></param>
        public void picture(com.google.zxing.common.ByteMatrix mode, string file)
        {
            Bitmap bmap = tobitmap(mode);
            bmap.Save(file);
            pictureBox1.Image = bmap;
        }

        /// <summary>
        /// 对二维码图片进行设计
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public  Bitmap tobitmap(com.google.zxing.common.ByteMatrix mode)
        {
            int width = mode.Width;
            int heigt = mode.Height;
            Bitmap bmap = new Bitmap(width, heigt, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < heigt; j++)
                {
                    bmap.SetPixel(i, j, mode.get_Renamed(i, j) != -1 ? Color.Black : Color.White);
                }
            }
            return bmap;
        }
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button2_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 读取二维码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
           
            
           
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
        }
    }
}
