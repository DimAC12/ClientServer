using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_v3.Classes.Generals
{
    public class Player
    {
        string ip;
        int port;
        int id;

        float xPos, yPos, zPos;
        float xRot, yRot, zRot;
        float xScale, yScale, zScale;

        int numberMillisecondsTimer = 10000;
        int numberMillisecondsTimerRemover = 3000;

        TimerCallback timerCallbackSendCheck;
        TimerCallback timerCallbackRemover;
        Timer timerChecker;
        Timer timerRemover;

        bool isMaya;

        public void SetMaya(bool maya)
        {
            isMaya = maya;
        }

        public bool GetMaya()
        {
            return isMaya;
        }

        public Player(string ip, int port, int id)
        {
            this.ip = ip;
            this.port = port;
            this.id = id;
            StartTimerCheck();
        }

        public string GetIp()
        {
            return ip;
        }

        public int GetPort()
        {
            return port;
        }

        public int GetId()
        {
            return id;
        }

        public void SetTransform(float xPos, float yPos, float zPos, float xRot, float yRot, float zRot, float xScale, float yScale, float zScale)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.zPos = zPos;
            this.xRot = xRot;
            this.yRot = yRot;
            this.zRot = zRot;
            this.xScale = xScale;
            this.yScale = yScale;
            this.zScale = zScale;
        }

        public string GetTransform()
        {
            string transform = $"{xPos}|{yPos}|{zPos}|{xRot}|{yRot}|{zRot}|{xScale}|{yScale}|{zScale}";
            return transform;
        }

        public void SendCheck(object obj)
        {
            Transport.SendData($"{ip}:{port}","CheckConnected#");
            timerRemover.Change(numberMillisecondsTimerRemover, Timeout.Infinite);
        }

        public void StartTimerCheck()
        {
            timerCallbackSendCheck = new TimerCallback(SendCheck);
            timerCallbackRemover = new TimerCallback(RemovePlayer);
            timerChecker = new Timer(timerCallbackSendCheck, null, numberMillisecondsTimer, Timeout.Infinite);
            timerRemover = new Timer(timerCallbackRemover);
        }

        public void RestartTimerCheck()
        {
            timerChecker.Change(numberMillisecondsTimer, Timeout.Infinite);
            timerRemover.Change(Timeout.Infinite, Timeout.Infinite);
        }

        public void RemovePlayer(object obj)
        {
            BasePlayers.RemovePlayer(id);

            for (int i = 0; i<Server.GetMaxPLayers(); i++)
            {
                if (i != id && BasePlayers.GetPlayer(i) != null)
                    Transport.SendData(BasePlayers.GetPlayer(i).GetIp() + ":" + BasePlayers.GetPlayer(i).GetPort().ToString(), "RemoveAnotherPlayer#" + id);
            }
        }
    }
}
