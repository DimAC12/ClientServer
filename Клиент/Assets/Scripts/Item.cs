using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour, IInteractive
{
    public string name;
    public int count;
    public string type;
    public Sprite image;
    public GameObject itemObjct;

    public void SetObject(GameObject player)
    {
        player.GetComponent<InventorySystem>().AddItem(this, itemObjct);
    }

    public void Action()
    {
        gameObject.SetActive(false);
    }

    public string Discription()
    {
        return name;
    }
}
