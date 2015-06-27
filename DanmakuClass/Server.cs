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
   
    public partial class Server : Form
    {
        public DanmakuForm danmaku;
        public DebugForm debug;
        public SettingsForm settings;
        public Server()
        {
            InitializeComponent();
            danmaku = new DanmakuForm();
            debug = new DebugForm();
            settings = new SettingsForm();
            this.AddOwnedForm(settings);
            this.AddOwnedForm(debug);
            this.AddOwnedForm(danmaku);
        }

        private void Server_Load(object sender, EventArgs e)
        {
            danmaku.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.debug.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.settings.Show();
        }
    }
}
