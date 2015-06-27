using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DanmakuClass
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FontDialog myDialog = new FontDialog();
            myDialog.ShowDialog();
            ((Server)this.Owner).danmaku.SetFont(myDialog.Font);
        }
    }
}
