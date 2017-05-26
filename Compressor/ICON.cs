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
     

        private void ICON_Load(object sender, EventArgs e)
        {
            
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            s.DefaultExt = "*.png|*.png";
            s.AddExtension = true;
            try
            {
                if (s.ShowDialog() == DialogResult.OK)
                {
                    string content =GetSeriesNumber ( textBox1.Text);
                    com.google.zxing.common.ByteMatrix mode = new MultiFormatWriter().encode(content, BarcodeFormat.QR_CODE, 350, 350);
                    picture(mode, System.Drawing.Imaging.ImageFormat.Png, s.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void picture(com.google.zxing.common.ByteMatrix mode, System.Drawing.Imaging.ImageFormat format, string file)
        {
            Bitmap bmap = tobitmap(mode);
            bmap.Save(file, format);
            pictureBox1.Image = bmap;
        }
        public Bitmap tobitmap(com.google.zxing.common.ByteMatrix mode)
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
    }
}
