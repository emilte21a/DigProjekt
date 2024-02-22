using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManagerUI : MonoBehaviour
{
    [SerializeField] Inventory inventory;

    [SerializeField] Image[] icons = new Image[4];

    private void Update()
    {

        for (int i = 0; i < icons.Length; i++)
        {
            if (i < inventory.items.Count && inventory.items[i] != null)
            {
                icons[i].enabled = true;
                icons[i].sprite = inventory.items[i].icon;
                if (inventory.items[i].stack > 1)
                {
                    
                }
            }
            else
            {
                icons[i].enabled = false;
            }
        }
    }
}
