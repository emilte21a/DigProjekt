using System.Collections;
using System.Collections.Generic;
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
            if (Input.GetKeyDown(KeyCode.F))
            {
                Item item = hit.transform.GetComponent<ItemObject>().item;
                
                inventory.Add(item);
                Destroy(hit.transform.gameObject);
            }
        }
        else
            text.text = "";

    }
}
