using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Windows.Forms.DataVisualization.Charting;
using System.Runtime.InteropServices;
using System.Collections.Specialized;
using Compressor.BLL;
using Compressor.Model;
namespace Compressor
{
    public partial class MainForm : Form
    {
        string[] Stage = new string[12];
        StringBuilder baudrate = new StringBuilder(255);//基本数据初始化
        StringBuilder portname = new StringBuilder(255);
        public static double[] x = new double[100] ;
        string user, work;
        public static SerialPort sp = new SerialPort();
        bool Pause = false;
        string filename = AppDomain.CurrentDomain.BaseDirectory + "control.ini";
        #region dll
        [DllImport("kernel32")]
        private static extern bool WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        #endregion
        #region 启动代码
        public MainForm()
        {
            InitializeComponent();
        }
        private void Initializesp()
        {
            GetPrivateProfileString("Port", "Baud", "9600", baudrate, 255, filename);
            sp.BaudRate = int.Parse(baudrate.ToString());
            GetPrivateProfileString("Port", "Name", "COM3", portname, 255, filename);
            sp.PortName = portname.ToString();
            sp.RtsEnable = true;
            sp.Open();
            
        }
           
        private void MainForm_Load(object sender, EventArgs e)//启动预备
        {
           
            Initializesp();
            Random x = new Random();
            chart1.Series[0].Points.AddXY(0.1,400);
            chart1.Series[0].Points.AddXY(0.4,350);
            chart1.Series[0].Points.AddXY(0.6, 330);
            chart1.Series[0].Points.AddXY(0.8, 310);
            chart1.Series[1].Points.AddXY(0.1, 2.2);
            chart1.Series[1].Points.AddXY(0.4, 2.6);
            chart1.Series[1].Points.AddXY(0.6, 2.9);
            chart1.Series[1].Points.AddXY(0.8, 3.0);
            chart1.Series[2].Points.AddXY(2.2, 400);
            chart1.Series[2].Points.AddXY(2.6, 350);
            chart1.Series[2].Points.AddXY(2.9, 330);
            chart1.Series[2].Points.AddXY(3.0, 310);

            for(int i = 1; i < 67; i++)
            {
                chart2.Series[0].Points.AddXY(i, (double)i / 50+x.NextDouble()/30);
            }
            for (int i = 66; i < 101; i++)
                chart2.Series[0].Points.AddXY(i, 1.32 - (double)(i-66) / 26 + x.NextDouble() / 30);
            
        }
        #endregion
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
     
        private void view()
        {
            printPreviewDialog1.Document = printDocument1;
            try
            {
                printPreviewDialog1.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;//居中打印
            StringFormat sf2 = new StringFormat();
            sf2.Alignment = StringAlignment.Far;//居右打印   
            Rectangle destRect = new Rectangle(0, 0, 1049, 670);
            int top_num = 0;
            e.Graphics.DrawString("车用空压机试验报告", new Font("黑体", 24), Brushes.Black, new Point(250, top_num += 15));//打印店铺地址
            e.Graphics.DrawString("公司名：" + "123456", new Font("宋体", 14), Brushes.Black, new Point(250, top_num += 45));//打印店铺地址
            e.Graphics.DrawString("试验员：" + "XXXXX", new Font("宋体", 14), Brushes.Black, new Point(250, top_num += 35));//打印店铺地址
            e.Graphics.DrawString("日期：" + "XXXXX", new Font("宋体", 14), Brushes.Black, new Point(500, top_num += 0));
            e.Graphics.DrawImage(new Bitmap(@"D:\\c1.bmp"), new Point(0, top_num += 25));
            e.Graphics.DrawString("试验数据", new Font("宋体", 24), Brushes.Black, new Point(500, top_num += 30));
            e.Graphics.DrawString("气压(Mpa)\n0.1\n0.4\n0.6\n0.8", new Font("宋体", 18), Brushes.Black, new Point(400, top_num += 60));
            e.Graphics.DrawString("流量(L/min)\n400\n350\n330\n310", new Font("宋体", 18), Brushes.Black, new Point(550, top_num += 0));
            e.Graphics.DrawString("功率(KW)\n2.2\n2.6\n2.9\n3.0", new Font("宋体", 18), Brushes.Black, new Point(700, top_num += 0));
            e.Graphics.DrawImage(new Bitmap(@"D:\\c2.bmp"), new Point(30, top_num += 500));
            e.Graphics.DrawString("装配员1：" + "XXXXX", new Font("宋体", 14), Brushes.Black, new Point(10, top_num += 330));
            e.Graphics.DrawString("装配员2：" + "XXXXX", new Font("宋体", 14), Brushes.Black, new Point(210, top_num += 0));
            e.Graphics.DrawString("装配员3：" + "XXXXX", new Font("宋体", 14), Brushes.Black, new Point(410, top_num += 0));
            e.Graphics.DrawString("装配员4：" + "XXXXX", new Font("宋体", 14), Brushes.Black, new Point(610, top_num += 0));
            e.Graphics.DrawString("试验结果：合格", new Font("宋体", 24), Brushes.Black, new Point(200, top_num += 40));
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void 硬件设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Config cn = new Config();
            cn.ShowDialog();
        }//打开设置

        private void button5_Click(object sender, EventArgs e)
        {
            Initializesp();
            if (sp.IsOpen == false)
            {
                testcon.Text = "关闭连接";
                sp.Open();
            }
            else
            {
                sp.Close();
                testcon.Text = "测试连接";
            }
        }//连接开关

        
        public void  ExportChart(string fileName, Chart chart1)//保存图片
        {
            string GR_Path = @"D:";
            string fullFileName = GR_Path + "\\" + fileName + ".bmp";
            chart1.SaveImage(fullFileName, ChartImageFormat.Bmp);
            Bitmap bit = new Bitmap(fullFileName);
        }



        private void 注意事项ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void 机器打标ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICON ic = new ICON();
            ic.ShowDialog();
        }

        #region 获取工位信息
        private void getwork(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            byte[] bt =new byte[2];
            bt[0] = 0x8E;
            sp.Write(bt,0,bt.Length );
            sp.DataReceived += new SerialDataReceivedEventHandler(WorkStageData);
            sp.ReceivedBytesThreshold = 1;
            stagebtn.Enabled = false;
            Closegetwork.Enabled = true;
        }
        private void WorkStageData(object sender, SerialDataReceivedEventArgs e)
        {
            StringBuilder builder = new StringBuilder(255);
            int n = MainForm.sp.BytesToRead;
            byte[] buf = new byte[n];
            MainForm.sp.Read(buf, 0, n);
            MainForm.sp.DiscardInBuffer();
            builder.Append(Encoding.ASCII.GetString(buf));
            if (builder.ToString().Length > 8) { 
            string id = builder.ToString().Substring(1, 8);
            string nama = Int32.Parse(id, System.Globalization.NumberStyles.HexNumber).ToString();//转为十进制
            string nami = CardBLL.GetCardInfoById(nama).Name;//获取名字
            switch (buf[0])
            {
                case 1: label21.Text = nami; break;
                case 2: label20.Text = nami; break;
                case 3: label19.Text = nami; break;
                case 4: label18.Text = nami; break;
                case 5: label17.Text = nami; break;
                case 6: label16.Text = nami; break;
            }
        }
        }


        private void Closegetwork_Click(object sender, EventArgs e)
        {
            sp.DataReceived -= new SerialDataReceivedEventHandler(WorkStageData);
            stagebtn.Enabled = true;
            Closegetwork.Enabled = false;
        }

        #endregion

        private void savedata_Click(object sender, EventArgs e)
        {
           
        }

        private void teststart_Click(object sender, EventArgs e)
        {
            ExportChart("c1", chart1);
            ExportChart("c2", chart2);
            view();
        }
        
    }
}

