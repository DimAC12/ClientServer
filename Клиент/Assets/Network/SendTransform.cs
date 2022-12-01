using Assets.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class SendTransform : MonoBehaviour
{
    Vector3 lastPosition;
    Vector3 lastRotation;
    Vector3 lastScale;

    void Start()
    {
        lastPosition = transform.position;
        lastRotation = transform.rotation.eulerAngles;
        lastScale = transform.localScale;
    }

    void Update()
    {
        if (transform.position != lastPosition || transform.rotation.eulerAngles != lastRotation || transform.localScale != lastScale)
        {
            string position = $"{string.Format("{0:N5}",transform.position.x)}|{string.Format("{0:N5}", transform.position.y)}|{string.Format("{0:N5}", transform.position.z)}|";
            string rotation = $"{string.Format("{0:N5}",transform.rotation.eulerAngles.x)}|{string.Format("{0:N5}",transform.rotation.eulerAngles.y)}|{string.Format("{0:N5}",transform.rotation.eulerAngles.z)}|";
            string scale = $"{transform.localScale.x}|{transform.localScale.y}|{transform.localScale.z}";
            string data = "TransformPlayer#" + position + rotation + scale + '|' + DateTime.Now + ':' + DateTime.Now.Millisecond;

            //Debug.Log("Вот какую дейту сделал: " + data);

            Transport.SendData(data);

            lastPosition = transform.position;
            lastRotation = transform.rotation.eulerAngles;
            lastScale = transform.localScale;
        }
    }
}
