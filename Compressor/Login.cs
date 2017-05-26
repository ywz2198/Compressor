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
using System.Data.SqlClient;
using Compressor.BLL;
using Compressor.Model;
using Compressor.DAL;
namespace Compressor
{
    public partial class Login : Form
    {
        #region dll
        [DllImport("kernel32")]
        private static extern bool WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        #endregion 
        SerialPort serialPort1 = new SerialPort();
        StringBuilder baudrate = new StringBuilder(255);
        StringBuilder portname = new StringBuilder(255);
        private StringBuilder builder = new StringBuilder(225);
        SqlConnection con = new SqlConnection(connStr);
        string workman,IDNumber;
        string filename = System.AppDomain.CurrentDomain.BaseDirectory + "control.ini";
        private static string connStr = @"Server=.;uid=lol;pwd=lol;database=Compressor";
        public Login()
        {
            InitializeComponent();
           
        }
        private void InitializeSerialPort1()//初始化串口1
        {
            GetPrivateProfileString("Port", "Baud", "9600", baudrate, 255, filename);
            serialPort1.BaudRate = int.Parse(baudrate.ToString());
            GetPrivateProfileString("Port", "Name", "COM3", portname, 255, filename);
            serialPort1.PortName = portname.ToString();
            serialPort1.RtsEnable = true;
            serialPort1.Open();
            serialPort1.DataReceived += ReceivedID;
        }
        private void ReceivedID(object sender, SerialDataReceivedEventArgs e)//处理串口1刷卡事件
        {
            serialPort1.DataReceived -= ReceivedID;
            int n = serialPort1.BytesToRead;
            byte[] buf = new byte[n];
            serialPort1.Read(buf, 0, n);
            this.Invoke((EventHandler)(delegate
            {
                
                builder.Append(Encoding.ASCII.GetString(buf));

                if (builder.ToString().Length > 7)
                {
                    this.workman = builder.ToString().Substring(builder.ToString().Length - 8);
                    findnumber(Int32.Parse(workman, System.Globalization.NumberStyles.HexNumber).ToString());
                }
                else
                    label1.Text = "卡不正确，重新刷卡";
                    serialPort1.DataReceived += ReceivedID;
               
               

            }));
           
            
        }

        private void Login_Load(object sender, EventArgs e)
        {
            InitializeSerialPort1();
       
        }
        private void findnumber(string theman)
        {

            if (CardDAL.Ifexist(theman))
            {

                CardInfo ci = CardBLL.GetCardInfoById(theman);
                MessageBox.Show(ci.Name + "进入成功","登录");
             //   MainForm main = new MainForm(ci.Name, ci.Job);
                this.Hide();
             //  main.Show();
            }
            else if ((int.Parse(theman)).ToString("x8").Length == 8)
            {
                DialogResult dr;
                dr = MessageBox.Show("是否注册", "注册", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    label2.Show();
                    label3.Show();
                    label4.Show();
                    pswd.Show();
                    names.Show();
                    jobs.Show();
                    button1.Show();
                    button2.Show();
                    IDNumber  = theman;
                }
                else
                {
                    serialPort1.DataReceived += ReceivedID;
                }
            }
            else
                serialPort1.DataReceived += ReceivedID;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pswd.Text == "123") {
                CardInfo inf = new CardInfo
                {
                    CardID = IDNumber,
                    Job = jobs.Text,
                    Name = names.Text

                };
            CardBLL.AddCard(inf);
            }
            serialPort1.DataReceived += ReceivedID;
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Hide ();
            label3.Hide ();
            label4.Hide ();
            pswd.Hide ();
            names.Hide ();
            jobs.Hide ();
            button1.Hide ();
            button2.Hide();
            serialPort1.DataReceived += ReceivedID;
        }
    }
}
