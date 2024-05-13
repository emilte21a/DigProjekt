using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPickup : MonoBehaviour
{
    [SerializeField] private float pickupRange;

    [SerializeField] LayerMask scrapLayerMask;
    [SerializeField] LayerMask leverLayerMask;

    [SerializeField] PlayerScrapInteract playerScrapInteract;

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
        if (Physics.Raycast(ray, out hit, pickupRange, scrapLayerMask))
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
            if (inventory.inventoryInstance.items.Count >= 4)
                text.text = "Inventory is full";

        }

        else if (Physics.Raycast(ray, out hit, pickupRange, leverLayerMask))
        {
            print("HIT!");
            if (playerScrapInteract.scrapCount == 36)
            {
                text.text = "Press F to leave the planet";
                if (Input.GetKeyDown(KeyCode.F))
                {
                    SceneManager.LoadScene("WinGame");
                }
            }
            else
                text.text = $"You can't leave yet: {playerScrapInteract.scrapCount}/36";
        }
        else
            text.text = "";
    }
}
