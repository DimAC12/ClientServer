using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using UnityEngine;

namespace Assets.Network
{
    static public class Transport
    {
        static UdpClient client;
        static IPEndPoint server;

        static Thread threadReceiving;

        static public void StartReceive(string ipServer, int portServer, int myPort = 0)
        {
            if ( myPort != 0)
            {
                client = new UdpClient(myPort);
            }

            else
            {
                client = new UdpClient();
            }
            
            server = new IPEndPoint(IPAddress.Parse(ipServer), portServer);
            client.Connect(server);

            threadReceiving = new Thread(ReceiveData);
            threadReceiving.Start();

            SendData("Connection");
        }

        static public void ReceiveData()
        {
            while (true)
            {
                byte[] buffer = new byte[1024];

                buffer = client.Receive(ref server);

                string strData = Encoding.UTF8.GetString(buffer);
                //Debug.Log("Команда: " + strData);
                CommandHandler.instance.PutCommand(strData);
            }
        }

        static public void StopReceive()
        {
            client.Close();
            threadReceiving.Abort();
        }

        static public void SendData(string data)
        {
            //Debug.Log("Отправил на сервер: " + data);
            byte[] byteData = Encoding.UTF8.GetBytes(data + ';');
            client.Send(byteData, byteData.Length);
        }
    }
}
