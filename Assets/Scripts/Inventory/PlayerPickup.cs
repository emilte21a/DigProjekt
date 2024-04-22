using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    [SerializeField] private float pickupRange;

    [SerializeField] LayerMask layerMask;

    [SerializeField] private Inventory inventory;

    [SerializeField] TMP_Text text;

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        if (Physics.Raycast(ray, out hit, pickupRange, layerMask))
        {
            text.text = "Press F to pickup";
            if (Input.GetKeyDown(KeyCode.F))
            {
                Item item = hit.transform.GetComponent<ItemObject>().item;
                if (inventory.inventoryInstance.items.Count <= 4)
                {
                    inventory.Add(item);
                    Destroy(hit.transform.gameObject);
                }
            }
            if (inventory.inventoryInstance.items.Count == 4)
                text.text = "Inventory if full";

        }
        else
            text.text = "";

    }
}
