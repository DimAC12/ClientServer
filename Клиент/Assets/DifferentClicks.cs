using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DifferentClicks : MonoBehaviour, IPointerClickHandler
{
    public bool Left;
    public bool Right;
    public bool Middle;

    InventorySystem inventorySystem;

    public delegate void AddListener();
    public AddListener addListener;

    public void SetInventory(InventorySystem inventorySystem)
    {
        this.inventorySystem = inventorySystem;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left && Left)
        {
            Debug.Log("Left");
            inventorySystem.ClickObject(gameObject);
            addListener();
        }

        else if (eventData.button == PointerEventData.InputButton.Right && Right)
        {
            Debug.Log("Right");
            inventorySystem.ClickObject(gameObject);
            addListener();
        }

        else if (eventData.button == PointerEventData.InputButton.Middle && Middle)
        {
            Debug.Log("Middle");
            inventorySystem.ClickObject(gameObject);
            addListener();
        }
    }
}
