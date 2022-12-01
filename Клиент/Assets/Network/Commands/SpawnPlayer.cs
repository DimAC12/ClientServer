using Assets.Network.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Network.Commands
{
    public class SpawnPlayer : ICommand
    {
        int idPlayer;
        float xPos, yPos, zPos;

        public string Name => "SpawnPlayer";

        public void ActionCommand()
        {
            NetworkManager.instance.SpawnAnotherPlayer(idPlayer, xPos,yPos,zPos);
        }

        public void setData(string data = "")
        {
            string[] idAndPosition = data.Split('|');
            idPlayer = int.Parse(idAndPosition[0]);
            xPos = float.Parse(idAndPosition[1]);
            yPos = float.Parse(idAndPosition[2]);
            zPos = float.Parse(idAndPosition[3]);
        }
    }
}
