using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace DanmakuClass
{
   
    public partial class Server : Form
    {
        public DanmakuForm danmaku;
        public DebugForm debug;
        public SettingsForm settings;
        private TcpListener tcpServer;
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
        public void ServerLog(String logString)
        {
            this.listBox1.Items.Add(logString);
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

        private void button1_Click(object sender, EventArgs e)
        {
            IPAddress address = IPAddress.Loopback;
            IPEndPoint endpoint = new IPEndPoint(address, 3664);
            tcpServer = new TcpListener(endpoint);
            tcpServer.Start();
            ServerLog("Server Started,listening on port 3664");
        }
        private void ServerProcessData()
        {
            while (true)
            {
                int bufferSize = 1024;
                TcpClient myClient = tcpServer.AcceptTcpClient();
                NetworkStream clientStream = myClient.GetStream();
                byte[] buffer = new byte[bufferSize];
                int readBytes = 0;
                readBytes = clientStream.Read(buffer, 0, bufferSize);
                String resultString = Encoding.UTF8.GetString(buffer);
                clientStream.Close();
            }
        
        }
        private void ProcessMessage(string message)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(danmakuMessage));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(message));
            danmakuMessage currentMessage = (danmakuMessage)serializer.ReadObject(stream);
        }
    }
}
