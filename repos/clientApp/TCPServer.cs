using System;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Configuration;

class TCPServer
{
    static TcpListener listener;
    
    public static void Main()
    {
        listener = new TcpListener(8888);
        listener.Start();
        #if LOG
            Console.WriteLine("Server mounted, 
                            listening to port 2055");
        #endif
       
    }
    public static void Service()
    {
        while (true)
        {
            Socket soc = listener.AcceptSocket();
            //soc.SetSocketOption(SocketOptionLevel.Socket,
            //        SocketOptionName.ReceiveTimeout,10000);
#if LOG
                Console.WriteLine("Connected: {0}", 
                                         soc.RemoteEndPoint);
#endif
            try
            {
                Stream s = new NetworkStream(soc);
                StreamReader sr = new StreamReader(s);
                StreamWriter sw = new StreamWriter(s);
                Console.WriteLine(sr.ReadLine());
                s.Close();
            }
            catch (Exception e)
            {
            #if LOG
                     Console.WriteLine(e.Message);
            #endif
            }
            #if LOG
                     Console.WriteLine("Disconnected: {0}", 
                                              soc.RemoteEndPoint);
            #endif
            soc.Close();
        }
    }
}