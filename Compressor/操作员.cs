using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compressor
{
    public partial class 操作员 : Form
    {
        public 操作员()
        {
            InitializeComponent();
        }

        private void 操作员_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            操作员身份注册 操作员 = new Compressor.操作员身份注册();
            操作员.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            操作员信息更新 操作员 = new 操作员信息更新();
            操作员.ShowDialog();
        }
    }
}
