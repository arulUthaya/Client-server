using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Net.Sockets;


namespace clientApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TcpClient client;
        NetworkStream nwStream;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Buttonconnect_Click(object sender, RoutedEventArgs e)
        {
            if(txtipaddress.Text == "127.0.0.1" && txtport.Text == "8888")
            {
                this.client = new TcpClient("127.0.0.1", 8888);

            }
            else
            {
                Console.WriteLine("Invalid Inputs!");
            } 
        }

        private void Buttonsend_Click(object sender, RoutedEventArgs e)
        {
            nwStream = this.client.GetStream();
            byte[] bytesToSend_msg = ASCIIEncoding.ASCII.GetBytes(txtmsg.Text);

            //---send the text---
            nwStream.Write(bytesToSend_msg, 0, bytesToSend_msg.Length);
            //this.client.Close();
        }
    }
}
