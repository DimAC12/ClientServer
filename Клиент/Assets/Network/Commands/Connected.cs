using Assets.Network.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Network.Commands
{
    public class Connected : ICommand
    {
        int id;

        public string Name => "Connected";

        public void ActionCommand()
        {
            NetworkManager.instance.myID = id;
            NetworkManager.instance.SpawnControlePlayer();
        }

        public void setData(string data = "")
        {
            string[] stringIdMaxPlayers = data.Split('|');
            BasePlayers.InitBasePlayers(int.Parse(stringIdMaxPlayers[1]));

            id = int.Parse(stringIdMaxPlayers[0]);
        }
    }
}
