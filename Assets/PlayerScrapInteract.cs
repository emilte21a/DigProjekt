using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScrapInteract : MonoBehaviour
{
    [SerializeField] private float pickupRange;

    [SerializeField] LayerMask layerMask;

    [SerializeField] private Inventory inventory;

    [SerializeField] TMP_Text text;

    private Camera cam;

    public int scrapCount = 0;

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
            text.text = "Press F to leave scrap";
            if (Input.GetKeyDown(KeyCode.F) && inventory.inventoryInstance.items.Count > 0)
            {
                scrapCount += inventory.inventoryInstance.items.Count;
                inventory.inventoryInstance.items.Clear();
            }
        }
        else
            text.text = "";

    }
}
