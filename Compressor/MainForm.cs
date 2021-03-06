﻿using System;
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
using Compressor.DAL;
namespace Compressor
{
    public partial class MainForm : Form
    {
        Series series3 = new Series("series3");
        string[] Stage = new string[12];
        StringBuilder baudrate = new StringBuilder(255);//基本数据初始化
        StringBuilder portname = new StringBuilder(255);
        public static double[] x = new double[100] ;
       // string user, work;
        string liuliang;
        public static SerialPort sp = new SerialPort();
       // bool Pause = false;
        string filename = AppDomain.CurrentDomain.BaseDirectory + "control.ini";
        public int[] a = new int[100];//实验二数据
        data d = new data();
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
           /// <summary>
           /// 启动预备
           /// </summary>
           /// <param name="sender"></param>
           /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {

            Random x = new Random();
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
     /// <summary>
     /// 打印预览
     /// </summary>
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
        /// <summary>
        /// 打印设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// 定时事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="chart1"></param>
        public void  ExportChart(string fileName, Chart chart1)
        {
            string fullFileName =System.AppDomain.CurrentDomain.BaseDirectory+"\\"+"报表" + "\\" + fileName + ".bmp";
            chart1.SaveImage(fullFileName, ChartImageFormat.Bmp);
           // Bitmap bit = new Bitmap(fullFileName);
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
      

        private void getinfo_Click(object sender, EventArgs e)
        {

        }

        private void teststop_Click(object sender, EventArgs e)
        {

        }

        private void testend_Click(object sender, EventArgs e)
        {

        }

        private void savedata_Click(object sender, EventArgs e)
        {
           
        }

        private void getinfo_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            ExportChart("c1", chart1);
            ExportChart("c2", chart2);
            view();
        }
        /// <summary>
        /// 测试数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void teststart_Click(object sender, EventArgs e)
        {
            /* sp.Open();
             if (Pause != false)
                 test1start();  */


            sp da = new sp();
            liuliang = da.spd();
            settable();
            fillstable(liuliang);
            line();
            suofang();
            d.add(liuliang, 3, 4, d.create());
        }
        private void test1start()
        {
            string sendtext = "AA 55 01";
        
            string[] temp = sendtext.Split(' ');
            byte[] b = new byte[temp.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i].Length > 0)
                    b[i] = Convert.ToByte(temp[i], 16);
            }


        }

        private string Noor(string st)
        {
            string[] HexStr = st.Trim().Split(' ');
            byte[] Hexbyte = new byte[HexStr.Length];
            byte check = 0;
            check = (byte)(Convert.ToByte(HexStr[0], 16) ^ Convert.ToByte(HexStr[1], 16));
            for (int i = 2; i < HexStr.Length; i++)
            {
                check = (byte)(check ^ Convert.ToByte(HexStr[i], 16));
            }
            string CheckSumHex = Convert.ToString(check, 16);
            if (CheckSumHex.Length == 1)
            {
                CheckSumHex = "0" + CheckSumHex;
            }

            return st.Trim() + " " + CheckSumHex.ToUpper();
        }

        /// <summary>
        /// 建立数据表
        /// </summary>
        public void settable()
        {
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "时间";
            dataGridView1.Columns[1].Name = "流量";
            dataGridView1.Columns[2].Name = "功率";
            dataGridView1.Columns[3].Name = "气压";
            dataGridView1.RowHeadersWidth = 55;
        }
       /// <summary>
        /// 填充数据表
        /// </summary>
       public void fillstable(string c)
        {

            string[] strContent = c.Split(null);
            int k = -1;
            foreach (string i in strContent)
            {
                if (i != "")
                {
                    k = k + 1;
                    int j = int.Parse(i);
                    a[k] = j;
                }
            }
            for (int i = 0; i < 100; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].HeaderCell.Value = (i+1).ToString();
                dataGridView1[0, i].Value = 100 - i;
                dataGridView1[1, i].Value = a[i].ToString();             
            }
        }
        /// <summary>
        /// 数据入库
        /// </summary>
        public void database()
        {

        }

        private void getinfo_Click_2(object sender, EventArgs e)
        {

        }

        private void teststop_Click_1(object sender, EventArgs e)
        {

        }

        private void testend_Click_1(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 数据回读
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button7_Click(object sender, EventArgs e)
        {
            settable();

            fillstable(d.insert(Int64.Parse(textBox20.Text)));
            line();
                
            
                
        }

        /// <summary>
        /// 曲线图
        /// </summary>
        public void line()
        {
            series3.ChartType = SeriesChartType.Spline;
            chart3.Series.Add(series3);
            for(int i=0;i<100;i++)
            {
                series3.Points.AddXY(i, dataGridView1[1, i].Value);
            }
        }
        /// <summary>
        /// 数据的缩放
        /// </summary>
        public void suofang()
        {
            chart3.ChartAreas[0].AxisX.ScaleView.Zoom(2, 3);
            // Enable range selection and zooming end user interface
            chart3.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart3.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart3.ChartAreas[0].AxisX.ScaleView.Zoomable = true;

            //将滚动内嵌到坐标轴中
            chart3.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;

            // 设置滚动条的大小
            chart3.ChartAreas[0].AxisX.ScrollBar.Size = 10;

            // 设置滚动条的按钮的风格，下面代码是将所有滚动条上的按钮都显示出来
            chart3.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;

            // 设置自动放大与缩小的最小量
            chart3.ChartAreas[0].AxisX.ScaleView.SmallScrollSize = double.NaN;
            chart3.ChartAreas[0].AxisX.ScaleView.SmallScrollMinSize = 2;


        }
      
    }
}

