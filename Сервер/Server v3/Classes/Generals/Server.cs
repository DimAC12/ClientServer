using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Server_v3.Classes.Generals
{
    static public class Server
    {
        static IPEndPoint? server;
        static int maxPlayers;

        static public void StartServer(int port, int maxPlayers)
        {
            server = new IPEndPoint(IPAddress.Any, port);
            Server.maxPlayers = maxPlayers;
            BasePlayers.StartBasePlayers(maxPlayers);
            CommandHandler.StartCommandHandler();
            Transport.CreateSocket(server);

            Console.WriteLine("Сервер запущен");
        }

        static public void StopServer()
        {

        }

        static public int GetMaxPLayers()
        {
            return maxPlayers;
        }
    }
}
