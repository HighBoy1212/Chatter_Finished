using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Net.Sockets;
using System.Net;

namespace Chatter {
    public partial class MainForm : Form {
        // Fields for own screen name and other party's screen name.
        private string strMyName = "";
        private string strOtherName = "";
        // Field to keep track of whether this instance is a client or not
        // (only relevant during initial connection).
        private bool bIsClient = false;
        // Field for the socket used to exchange messages.
        private Socket socExchange = null;
        private bool bLoop = true;
        public MainForm(bool bIC) {
            InitializeComponent();
            // Startup code determines whether this instance is a client, passes
            // in result.
            bIsClient = bIC;
        }

        private void MainForm_Load(object sender, EventArgs e) {
            // Get this user's screen name.
            GetName frmGetName = new GetName();
            if (frmGetName.ShowDialog() == DialogResult.OK) {
                // Store own screen name.
                strMyName = frmGetName.ScreenName;
                this.Text = "Messenger - " + strMyName;
            }
            else {
                // No name given, quit.
                this.Close();
            }

            // Start up, getting us ready to exchange messages.
            vStartup();
        }

        // Startup: Start client if this is the server, then have client and server
        // connect to one another, exchange names.
        private void vStartup() {
            if (bIsClient) {
                // ** Client-instance code. **
                // Wait half a second, to ensure server is ready to accept connection
                // requests.
                Thread.Sleep(500);
                // Client connect to server.
                vClientConnect();
            } else {
                // ** Server-instance code. **
                // Start client instance.
                Process procClient = new Process();
                procClient.StartInfo.FileName = "Chatter.exe";
                procClient.StartInfo.Arguments = "client";
                procClient.Start();
                // Server accept connection from client.
                vServerConnect();
            }
            // ** Generic code. **
            // Start thread that receives and processes messages.
            vStartRcvThread();
            // Exchange names.
            vExchangeNames();
        }

        // Client connect to server.
        private void vClientConnect() {
            // ****** TODO: Add code for client to connect to server, using the socket
            // ****** that is a field on this form.
            IPAddress ipaServer = IPAddress.Parse("127.0.0.1");
            socExchange = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socExchange.Connect(ipaServer, 33221);

        }

        // Server accept connection from client.
        private void vServerConnect() {
            // ****** TODO: Add code for server to wait for connections, then accept
            // ****** connection request from client. Connection to client uses the
            // ****** socket that is a field on this form.
            Socket socListen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipaServer = IPAddress.Parse("127.0.0.1");
            IPEndPoint ipeServer = new IPEndPoint(ipaServer, 33221);
            socListen.Bind(ipeServer);
            socListen.Listen(5);

            // Accept Connection request
            while (bLoop)
            {
                try
                {
                    // When a new connection request is accepted, it returns a new socket
                    // to use for exchanging data
                    socExchange = socListen.Accept();
                    return;
                }
                catch
                {
                    // The only reason to get an exception is that the listening socket has been closed
                    // We can return to stop executing this function
                    return;
                }
            }
        }

        // Start thread that receives and processes messages.
        private void vStartRcvThread() {
            // ****** TODO: Add code to start the thread that receives and processes
            // ****** messages from the other instance.
            Task.Run(vReceiveMessages);
        }

        private void vReceiveMessages()
        {
            string strMessage = null;
            while (true)
            {
                strMessage = null;
                try
                {
                    if (socExchange != null)
                    {
                        strMessage = strReceiveMsg();
                        vProcessMessage(strMessage);
                    }
                }
                catch
                {
                    return;
                }
            }
        }

        public void vProcessMessage(string strMessage)
        {
            string[] strarrMessage = strMessage.Split(':');
            string strCommand = strarrMessage[0].ToLower();
            string strArgument = strarrMessage[1];
            if (strarrMessage.Length > 2)
            {
                for(int i = 2; i < strarrMessage.Length; i++)
                {
                    strArgument += ":" + strarrMessage[i];
                }
            }
            if(strCommand == "name") 
            {
                strOtherName = strArgument;
            }
            else if(strCommand == "quit")
            {
                bLoop = false;
                socExchange.Close();
                socExchange.Dispose();
                socExchange = null;
            }
            else if(strCommand == "text")
            {
                this.Invoke(new Action<string>(rtbConversation.AppendText), strOtherName + ": " + strArgument);
            }
        }

        // Send our name to the other instance.
        private void vExchangeNames() {
            // ****** TODO: Add code to send our name to the other instance.
            vSendMsg("name:" + strMyName);
        }

        // Send a message over the network.
        private void vSendMsg(string strMessage) {
            // Convert the message to an array of bytes.
            byte[] byMessage = Encoding.UTF8.GetBytes(strMessage);
            // Get its length and send the length.
            short sMsgLen = (short)byMessage.Length;
            byte[] byMsgLen = BitConverter.GetBytes(sMsgLen);
            socExchange.Send(byMsgLen, byMsgLen.Length, SocketFlags.None);
            // Send the message itself.
            socExchange.Send(byMessage, byMessage.Length, SocketFlags.None);
        }

        // Receive a message over the network.
        private string strReceiveMsg() {
            // Get the length of the message body.
            byte[] byLenBuf = new byte[2];
            socExchange.Receive(byLenBuf);
            int iMsgLen = BitConverter.ToInt16(byLenBuf, 0);
            // Retrieve the message body.
            byte[] byMsgBuf = new byte[iMsgLen];
            int iBytesRead = socExchange.Receive(byMsgBuf);
            // Convert to a string using the UTF-8 encoding and return.
            return Encoding.UTF8.GetString(byMsgBuf, 0, iBytesRead);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            rtbConversation.AppendText(strMyName + ": " + txtMessage.Text + "\r\n");
            vSendMsg("text:" + txtMessage.Text + "\r\n");
            txtMessage.Focus();
            txtMessage.SelectAll();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(socExchange != null)
                vSendMsg("quit:");
        }
    }
}
