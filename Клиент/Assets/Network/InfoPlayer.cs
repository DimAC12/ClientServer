using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Network
{
    public class InfoPlayer
    {
        float xPos, yPos, zPos;
        float xRot, yRot, zRot;
        float xScale, yScale, zScale;
        bool isMaya = false;

        public void SetCoords(float xPos, float yPos, float zPos, float xRot, float yRot, float zRot, float xScale, float yScale, float zScale)
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

        public bool GetMaya()
        {
            return isMaya;
        }

        public string GetCoords()
        {
            return xPos.ToString() + '|' + yPos.ToString() + '|' + zPos.ToString() + '|' + 
                xRot.ToString() + '|' + yRot.ToString() + '|' + zRot.ToString() + '|' + 
                xScale.ToString() + '|' + yScale.ToString() + '|' + zScale.ToString();
        }
    }
}
