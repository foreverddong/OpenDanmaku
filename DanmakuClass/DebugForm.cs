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
    }
}
