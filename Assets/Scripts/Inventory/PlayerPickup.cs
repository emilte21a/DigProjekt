using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    [SerializeField] private float pickupRange;

    [SerializeField] LayerMask layerMask;

    [SerializeField] private Inventory inventory;

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            if (Physics.Raycast(ray, out hit, pickupRange, layerMask))
            {
                Item item = hit.transform.GetComponent<ItemObject>().item;
                inventory.Add(item);
                Destroy(hit.transform.gameObject);
            }
        }
    }
}
