using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public InventoryInstance inventoryInstance;

    public void Add(Item item)
    {
        inventoryInstance.items.Add(item);
        print(item.name + " was added to inventory");
    }

    public void AddToStack(ItemObject itemObject)
    {
        itemObject.stack++;
    }

    public void Remove(Item item)
    {
        inventoryInstance.items.Remove(item);
    }
}

