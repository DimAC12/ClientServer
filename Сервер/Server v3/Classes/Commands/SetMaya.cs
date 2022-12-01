using Server_v3.Classes.Generals;
using Server_v3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_v3.Classes.Commands
{
    public class SetMaya : ICommandAction
    {
        string ip;
        int port;
        string idMaya;

        public string Name => "SetMaya";

        public void Action()
        {
            for (int i = 0; i < Server.GetMaxPLayers(); i++)
            {
                if (BasePlayers.GetPlayer(i) == null) continue;
                Transport.SendData($"{BasePlayers.GetPlayer(i).GetIp()}:{BasePlayers.GetPlayer(i).GetPort()}", $"SetMaya#{idMaya}");
                Console.WriteLine($"{BasePlayers.GetPlayer(i).GetIp()}:{BasePlayers.GetPlayer(i).GetPort()} SetMaya#{idMaya}");
            }


        }

        public void SetClient(string ip, int port)
        {
            this.ip = ip;
            this.port = port;
        }

        public void SetData(string data)
        {
            this.idMaya = data;
        }
    }
}
