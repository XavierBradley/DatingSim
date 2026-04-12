using NUnit.Framework.Interfaces;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    public InventoryUI inventoryUI;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public List<Items> items = new List<Items>();

    public void AddItem(Items item)
    {
        items.Add(item);
        Debug.Log("Picked up: " + item.itemName);
        inventoryUI.UpdateUI(items);
    }
    //in case we end up having items be consumed
    public void RemoveItem(Items item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            inventoryUI.UpdateUI(items);
        }
    }

    public bool HasItem(Items item)
    {
        return items.Contains(item);
    }
}