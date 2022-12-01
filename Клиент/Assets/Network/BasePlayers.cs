using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Network
{
    static public class BasePlayers
    {
        static GameObject[] playersObject;
        static InfoPlayer[] playersInfo;
        static int maxPlayers;

        static public void InitBasePlayers(int maxPlayers)
        {
            playersObject = new GameObject[maxPlayers];
            playersInfo = new InfoPlayer[maxPlayers];
            BasePlayers.maxPlayers = maxPlayers;
        }

        static public int GetMaxPlayers()
        {
            return maxPlayers;
        }

        static public void AddPlayer(int id, GameObject obj)
        {
            playersObject[id] = obj;
            playersInfo[id] = new InfoPlayer();
            BasePlayers.WritePlayersConsole();
        }

        static public void SetCoords(int id, float xPos, float yPos, float zPos, float xRot, float yRot, float zRot, float xScale, float yScale, float zScale)
        {
            if(playersObject != null && playersObject[id] != null)
                playersInfo[id].SetCoords(xPos, yPos, zPos, xRot, yRot, zRot, xScale, yScale, zScale);
        }

        static public string GetCoords(int id)
        {
            return playersInfo[id].GetCoords();
        }

        static public GameObject GetObjectPlayer(int id)
        {
            return playersObject[id];
        }

        static public void RemovePlayer(int id)
        {
            playersObject[id] = null;
            playersInfo[id] = null;
        }

        static public void WritePlayersConsole()
        {
            for (int i = 0; i < playersInfo.Length; i++)
            {
                if (playersInfo[i] != null)
                    Debug.Log(i);
            }
            
        }
    }
}
