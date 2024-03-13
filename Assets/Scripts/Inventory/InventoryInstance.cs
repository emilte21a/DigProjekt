using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory", order = 2)]
public class InventoryInstance : ScriptableObject
{
    public List<Item> items;



    private void OnEnable()
    {
        items.Clear();
    }
}
