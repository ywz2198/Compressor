using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Compressor.BLL;
using CompressorBLL;
using CompressorModel;
using Compressor.Model;
namespace Compressor
{
    public partial class 操作员身份注册 : Form
    {
        public 操作员身份注册()
        {
            InitializeComponent();
        }
     
        private void button1_Click(object sender, EventArgs e)
        {
            CardInfo card = new CardInfo();
            card.Age = age.Text;
            card.CardID = id.Text;
            card.Job = job.Text;
            card.Name = name.Text;
           CardBLL.AddCard(card);
           
        }
    }
}
