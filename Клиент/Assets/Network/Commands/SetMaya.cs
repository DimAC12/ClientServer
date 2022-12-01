using Assets.Network.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Network.Commands
{
    public class SetMaya : ICommand
    {
        int id;

        public string Name => "SetMaya";

        public void ActionCommand()
        {
            Debug.Log("ЫЫЫЫЫЫЫ id: " + id + " мой айди: " + NetworkManager.instance.myID);



            if (id != NetworkManager.instance.myID)
            {
                for (int i = 0; i < BasePlayers.GetMaxPlayers(); i++)
                {
                    if (BasePlayers.GetObjectPlayer(i) != null)
                    {
                        BasePlayers.GetObjectPlayer(i).GetComponent<Maya>().NotMaya();
                    }
                }
                NetworkManager.instance.GetMayObj().GetComponent<Car>().NotMaya();
                BasePlayers.GetObjectPlayer(id).GetComponent<Maya>().SetMaya();
            }

            else
            {
                for (int i = 0; i < BasePlayers.GetMaxPlayers(); i++)
                {
                    if (BasePlayers.GetObjectPlayer(i) != null)
                    {
                        BasePlayers.GetObjectPlayer(i).GetComponent<Maya>().NotMaya();
                    }
                }
                NetworkManager.instance.GetMayObj().GetComponent<Car>().SetMaya();
            }
        }

        public void setData(string data = "")
        {
            
            id = int.Parse(data);
        }
    }
}
