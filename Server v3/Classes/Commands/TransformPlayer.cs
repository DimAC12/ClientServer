using Server_v3.Classes.Generals;
using Server_v3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_v3.Classes.Commands
{
    public class TransformPlayer : ICommandAction
    {
        string ip;
        int port;

        string coords;

        public string Name => "TransformPlayer";

        public void Action()
        {
            int id = BasePlayers.GetPlayer(ip, port).GetId();
            string[] fullCoords = coords.Split('|');

            BasePlayers.GetPlayer(ip, port).SetTransform(float.Parse(fullCoords[0]), float.Parse(fullCoords[1]), float.Parse(fullCoords[2]),
                float.Parse(fullCoords[3]), float.Parse(fullCoords[4]), float.Parse(fullCoords[5]),
                float.Parse(fullCoords[6]), float.Parse(fullCoords[7]), float.Parse(fullCoords[8]));

            for (int i = 0; i < Server.GetMaxPLayers(); i++)
            {
                if (i == id || BasePlayers.GetPlayer(i) == null) continue;
                Transport.SendData(BasePlayers.GetPlayer(i).GetIp() + ':' + BasePlayers.GetPlayer(i).GetPort().ToString(), "TransformPlayer#" + id.ToString() + '|' + BasePlayers.GetPlayer(id).GetTransform());
            }
        }

        public void SetData(string data)
        {
            coords = data;
        }

        public void SetClient(string ip, int port)
        {
            this.ip = ip;
            this.port = port;
        }
    }
}
