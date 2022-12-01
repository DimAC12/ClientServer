using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [SerializeField] TMP_Text nameItem;
    [SerializeField] TMP_Text weightItem;
    [SerializeField] Image imageItem;

    public void SetInfo(string name, int weight, Sprite image)
    {
        nameItem.text = name;
        weightItem.text = weight.ToString();
        imageItem.sprite = image;
    }
}
