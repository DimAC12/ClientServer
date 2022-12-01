using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Door : MonoBehaviour, IInteractive
{
    [SerializeField] string discription;

    [SerializeField] GameObject teleportTo;
    GameObject obj;

    public void SetObject(GameObject obj)
    {
        this.obj = obj;
    }

    public void Action()
    {
        obj.GetComponent<CharacterController>().enabled = false;
        obj.transform.localPosition = teleportTo.transform.position;
        obj.GetComponent<CharacterController>().enabled = true;
        RenderSettings.defaultReflectionMode = DefaultReflectionMode.Custom;
        RenderSettings.ambientMode = AmbientMode.Flat;

        Debug.Log("Неплохо");
    }

    public string Discription()
    {
        return discription;
    }
}
