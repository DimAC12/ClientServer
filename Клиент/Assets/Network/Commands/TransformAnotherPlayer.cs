using Assets.Network.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace Assets.Network.Commands
{
    public class TransformAnotherPlayer : ICommand
    {
        int idPlayer;
        float px, py, pz;
        float rx, ry, rz;
        float sx, sy, sz;

        public string Name => "TransformPlayer";

        public void ActionCommand()
        {
            BasePlayers.SetCoords(idPlayer, px, py, pz, rx, ry, rz, sx, sy, sz);
        }

        public void setData(string data = "")
        {
            string[] idAndCoords = data.Split('|');
            idPlayer = int.Parse(idAndCoords[0]);
            px = float.Parse(idAndCoords[1]);
            py = float.Parse(idAndCoords[2]);
            pz = float.Parse(idAndCoords[3]);
            rx = float.Parse(idAndCoords[4]);
            ry = float.Parse(idAndCoords[5]);
            rz = float.Parse(idAndCoords[6]);
            sx = float.Parse(idAndCoords[7]);
            sy = float.Parse(idAndCoords[8]);
            sz = float.Parse(idAndCoords[9]);
        }
    }
}
