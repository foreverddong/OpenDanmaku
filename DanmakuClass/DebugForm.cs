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
    public partial class DebugForm : Form
    {
        private Server myOwner;
        public DebugForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Danmaku newDanmaku = new Danmaku();
            newDanmaku.DanmakuString = textBox1.Text;
            myOwner.danmaku.AddDanmaku(newDanmaku);
            
        }

        private void DebugForm_Load(object sender, EventArgs e)
        {
            myOwner = (Server)this.Owner;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            myOwner.danmaku.TopMost = this.checkBox1.Checked;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            myOwner.danmaku.danmakuSpeed = trackBar1.Value;
        }
    }
}
