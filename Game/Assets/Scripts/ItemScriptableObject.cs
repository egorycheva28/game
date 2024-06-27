using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType { Default, Food, Weapon, Instrument }
public class ItemScriptableObject : ScriptableObject
{

    public string itemName;
    public int maximumAmount;
    public GameObject itemPrefab;
    public Sprite icon;
    public ItemType itemType;
    public string itemDescription;
}
