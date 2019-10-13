using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        TcpClient clientSocket = new TcpClient();
        NetworkStream stream = default(NetworkStream);
        string message = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSendText_Click(object sender, EventArgs e)
        {
            byte[] buffer = Encoding.Unicode.GetBytes(this.textBox2.Text + "$");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            clientSocket.Connect("localhost", 9999);
            stream = clientSocket.GetStream();

            message = "Connected to Chat Server";
            DisplayText(message);

            byte[] buffer = Encoding.Unicode.GetBytes(this.textBoxNickName.Text + "$");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();

            Thread t_handler = new Thread(GetMessage);
            t_handler.IsBackground = true;
            t_handler.Start();
        }

        private void GetMessage()
        {
            while (true)
            {
                stream = clientSocket.GetStream();
                int BUFFERSIZE = clientSocket.ReceiveBufferSize;
                byte[] buffer = new byte[BUFFERSIZE];
                int bytes = stream.Read(buffer, 0, buffer.Length);

                string message = Encoding.Unicode.GetString(buffer, 0, bytes);
                DisplayText(message);
            }
        }

        private void DisplayText(string text)
        {
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.BeginInvoke(new MethodInvoker(delegate
                {
                    richTextBox1.AppendText(text + Environment.NewLine);
                }));
            }
            else
                richTextBox1.AppendText(text + Environment.NewLine);
        }
    }
}
