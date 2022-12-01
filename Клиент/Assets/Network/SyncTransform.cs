using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Network
{
    public class SyncTransform : MonoBehaviour
    {
        int myID;
        Rigidbody rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            myID = int.Parse(gameObject.name);
        }

        private void FixedUpdate()
        {
            string[] coords = BasePlayers.GetCoords(myID).Split('|');
            Vector3 pos = new Vector3(float.Parse(coords[0]), float.Parse(coords[1]), float.Parse(coords[2]));
            Vector3 rot = new Vector3(float.Parse(coords[3]), float.Parse(coords[4]), float.Parse(coords[5]));

            if (transform.position != pos || transform.rotation.eulerAngles != rot)
            {
                //Debug.Log(myID + "  -  " + BasePlayers.GetCoords(myID) + "  -  " + DateTime.Now + ':' + DateTime.Now.Millisecond);

                rb.MovePosition(pos);
                rb.MoveRotation(Quaternion.Euler(rot));

                //transform.position = Quaternion.Euler(float.Parse(coords[0]), float.Parse(coords[1]), float.Parse(coords[2]));
                //transform.rotation = Quaternion.Euler(float.Parse(coords[3]), float.Parse(coords[4]), float.Parse(coords[5]));
                transform.localScale = new Vector3(float.Parse(coords[6]), float.Parse(coords[7]), float.Parse(coords[8]));
            }
        }
    }
}
