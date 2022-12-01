using Server_v3.Classes.Generals;
using Server_v3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_v3.Classes.Commands
{
    public class CheckConnection : ICommandAction
    {
        string ip;
        int port;

        public string Name => "Check";

        public void Action()
        {
            BasePlayers.GetPlayer(ip, port).RestartTimerCheck();
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
