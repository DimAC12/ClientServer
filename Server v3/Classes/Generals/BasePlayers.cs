using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_v3.Classes.Generals
{
    static public class BasePlayers
    {
        static Player[] players;

        static public void StartBasePlayers(int maxPlayers)
        {
            players = new Player[maxPlayers];
        }

        static public int AddPlayer(string ip, int port)
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i] == null)
                {
                    players[i] = new Player(ip, port, i);
                    WriteConsolePlayers();
                    return i;
                }
            }
            WriteConsolePlayers();
            return -1;
        }

        static public Player GetPlayer(int id)
        {
            if (players[id] != null)
                return players[id];
            else
                return null;
        }

        static public Player GetPlayer(string ip, int port)
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i] != null && players[i].GetIp() == ip && players[i].GetPort() == port)
                {
                    return players[i];
                }
            }
            return null;
        }

        static public void RemovePlayer(int id)
        {
            players[id] = null;
            WriteConsolePlayers();
        }

        static public void RemovePlayer(string ip, int port)
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].GetIp() == "ip" && players[i].GetPort() == port)
                {
                    players[i] = null;
                    break;
                }
            }
            WriteConsolePlayers();
        }

        static public void WriteConsolePlayers()
        {
            Console.WriteLine("\n");
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i] == null)
                    Console.WriteLine($"({i}) --------Пустой слот--------");
                else
                    Console.WriteLine($"({i}) {players[i].GetIp()}:{players[i].GetPort()}");
            }
        }
    }
}
