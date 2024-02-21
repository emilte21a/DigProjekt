using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemInstance> items = new List<ItemInstance>();

    [SerializeField] int itemCapacity = 20;
    void AddItem(ItemInstance item)
    {
        items.Add(item);
    }

    private void Update()
    {
        if (items.Count <= itemCapacity)
            return;

        else
            print("Inventory is full");
    }
}

public class ItemInstance
{
    public ItemData itemType;

    public ItemInstance(ItemData itemData)
    {
        itemType = itemData;
    }
}
