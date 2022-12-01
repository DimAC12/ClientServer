using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    private List<Item> items;
    private List<GameObject> itemObjects;

    public int countItems;
    public GameObject inventory;
    public GameObject inventoryItem;
    public GameObject actionMenu;
    public GameObject pointSpawnItems;
    private GameObject clickObject;

    private void Start()
    {
        items = new List<Item>();
        itemObjects = new List<GameObject>();
    }

    public void ClickObject(GameObject clickObject) 
    {  
        this.clickObject = clickObject;
    }

    public int AddItem(Item item, GameObject objectItem)
    {
        if (items.Count < countItems)
        {
            GameObject newItem = Instantiate(inventoryItem, inventory.transform);
            newItem.transform.GetChild(0).GetComponent<Image>().sprite = item.image;
            newItem.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = item.name;
            newItem.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = item.count.ToString();

            newItem.GetComponent<DifferentClicks>().SetInventory(this);
            newItem.GetComponent<DifferentClicks>().addListener = ViewMenu;

            itemObjects.Add(objectItem);

            return 0;
        }

        else
        {
            return 1;
        }
    }

    public void ViewMenu()
    {
        actionMenu.SetActive(true);
        actionMenu.transform.position = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
        Debug.Log(clickObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text);
    }

    public void CloseActionMenu()
    {
        actionMenu.SetActive(false);
    }

    public void DeleteItem()
    {
        string nameObject = clickObject.transform.GetChild (1).GetComponent<TextMeshProUGUI>().text;

        foreach(GameObject obj in itemObjects)
        {
            if (obj.GetComponent<Item>().name == nameObject)
            {
                obj.transform.position = pointSpawnItems.transform.position;
                obj.SetActive(true);
                itemObjects.Remove(obj);
                Destroy(clickObject);
                CloseActionMenu();
                return;
            }
        }
    }
}
