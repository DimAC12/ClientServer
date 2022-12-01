using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Server_v3.Classes.Generals
{
    static public class Transport
    {
        static string? ip;
        static int port;
        static Thread receiveDataThread = new Thread(ReceiveData);
        static Socket socket;

        static public void StartReceiveData()
        {
            receiveDataThread.Start();
        }

        static public void CreateSocket(IPEndPoint server)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.Bind(server);
            StartReceiveData();
        }

        static public void DestroySocket()
        {
            socket.Close();
        }

        static public void ReceiveData()
        {
            EndPoint client = new IPEndPoint(IPAddress.Any, 0);

            while (true)
            {
                try
                {
                    byte[] byteData = new byte[1024];
                    string strSecondData;

                    socket.ReceiveFrom(byteData, ref client);
                    strSecondData = Encoding.UTF8.GetString(byteData);

                    Task.Factory.StartNew(() =>
                    {
                        CommandHandler.PutCommands(client.ToString(), strSecondData);
                    });

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Пофиг   " + client + '\n' + ex);
                }

            }
        }

        static public void SendData(string ipPort, string strData)
        {
            if (strData != null)
            {
                try
                {
                    string[] strIpPort = ipPort.Split(':');
                    byte[] data = Encoding.UTF8.GetBytes(strData + ";");

                    EndPoint client = new IPEndPoint(IPAddress.Parse(strIpPort[0]), Int32.Parse(strIpPort[1]));
                    socket.SendTo(data, client);

                    //if (strData[1] != "CheckConnected#" && strIpPort[1] == "22334")
                    //Console.WriteLine($"Клиенту: {ipPort} Отправил: {strData}");

                }
                catch (SocketException e)
                {
                    Console.WriteLine("Не понял!   " + e);
                }

            }
        }
    }
}
