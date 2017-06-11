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
    public partial class 操作员信息更新 : Form
    {
        public 操作员信息更新()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CardInfo cmid = new CardInfo();
            cmid.Age = i1.Text;
            cmid.CardID = i2.Text;
            cmid.Job= i3.Text;
            cmid.Name= i4.Text; CmIDBLL.Add(cmid);//CardBLL.AddCard(cmid); 
           /* 
            CmID cmid = new CmID();
            cmid.Cmid = i1.Text;
            cmid.Code = i2.Text;
            cmid.Image = i3.Text;
            cmid.Operation = i4.Text;
            cmid.Time = i5.Text;
            cmid.Type = i6.Text;*/
          
            
        }
    }
}
