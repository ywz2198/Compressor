using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Collections.Specialized;
namespace Compressor
{
    public partial class Config : Form
    {
        StringBuilder baudrate=new StringBuilder (255);
        StringBuilder portname=new StringBuilder (255);
        string filename = System.AppDomain.CurrentDomain.BaseDirectory + "control.ini";
        [DllImport("kernel32")]
        private static extern bool WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        public Config()
        {
            InitializeComponent();
        }

        private void Config_Load(object sender, EventArgs e)
        {
            string[] port = SerialPort.GetPortNames();
            comboBox2.Items.AddRange(port);
            
            GetPrivateProfileString("Port", "Baud", "9600", baudrate, 255, filename);
            comboBox1.SelectedItem = baudrate.ToString ();
            GetPrivateProfileString("Port", "Name", "COM1", portname, 255, filename);
            comboBox2.SelectedItem = portname.ToString();
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WritePrivateProfileString("Port", "Baud", comboBox1.SelectedItem.ToString(), filename);
            WritePrivateProfileString("Port", "Name", comboBox2.SelectedItem.ToString(), filename);
        }
    }
}
