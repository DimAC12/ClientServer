using Assets.Network.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Network.Commands
{
    public class CheckConnected : ICommand
    {
        public string Name => "CheckConnected";

        public void ActionCommand()
        {
            Transport.SendData("Check");
        }

        public void setData(string data = "")
        {
            
        }
    }
}
