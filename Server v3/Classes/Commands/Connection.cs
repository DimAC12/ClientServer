using Server_v3.Classes.Generals;
using Server_v3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_v3.Classes.Commands
{
    public class Connection : ICommandAction
    {
        string ip;
        int port;

        public string Name => "Connection";

        public void Action()
        {
            int idSender = BasePlayers.AddPlayer(ip, port);
            Transport.SendData(ip + ':' + port.ToString(), $"Connected#{idSender}|{Server.GetMaxPLayers()}");

            for (int i = 0; i < Server.GetMaxPLayers(); i++)
            {
                if (i == idSender || BasePlayers.GetPlayer(i) == null) continue;
                Transport.SendData(BasePlayers.GetPlayer(i).GetIp() + ':' + BasePlayers.GetPlayer(i).GetPort().ToString(), $"SpawnPlayer#{idSender}|{BasePlayers.GetPlayer(idSender).GetTransform()}");
                Transport.SendData(BasePlayers.GetPlayer(idSender).GetIp() + ':' + BasePlayers.GetPlayer(idSender).GetPort().ToString(), $"SpawnPlayer#{i}|{BasePlayers.GetPlayer(i).GetTransform()}");
                //Transport.SendData(BasePlayers.GetPlayer(i).GetIp() + ':' + BasePlayers.GetPlayer(i).GetPort().ToString(), $"SetMaya#{idSender}");
            }

            //Transport.SendData(ip + ':' + port.ToString(), $"SetMaya#{idSender}");
        }

        public void SetData(string data)
        {
            
        }

        public void SetClient(string ip, int port)
        {
            this.ip = ip;
            this.port = port;
        }
    }
}
