using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManagerUI : MonoBehaviour
{
    [SerializeField] Inventory inventory;

    [SerializeField] Image[] icons = new Image[4];
    [SerializeField] TMP_Text[] stackShower = new TMP_Text[4];

    private void Update()
    {

        for (int i = 0; i < icons.Length; i++)
        {
            if (i < inventory.inventoryInstance.items.Count && inventory.inventoryInstance.items[i] != null)
            {

                icons[i].enabled = true;
                icons[i].sprite = inventory.inventoryInstance.items[i].icon;

                //stackShower[i].text = $"{inventory.items[i].stack}";
            }
            else
            {
                icons[i].enabled = false;
            }
        }
    }
}
