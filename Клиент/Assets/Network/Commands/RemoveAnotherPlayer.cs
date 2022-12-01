using Assets.Network.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Network.Commands
{
    public class RemoveAnotherPlayer : ICommand
    {
        int idPlayer;

        public string Name => "RemoveAnotherPlayer";

        public void ActionCommand()
        {
            NetworkManager.instance.DestroyPlayer(idPlayer);
        }

        public void setData(string data = "")
        {
            idPlayer = int.Parse(data);
        }
    }
}
