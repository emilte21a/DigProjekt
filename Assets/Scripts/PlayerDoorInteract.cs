using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDoorInteract : MonoBehaviour
{
    [SerializeField] private float pickupRange;

    [SerializeField] LayerMask layerMask;

    [SerializeField] TMP_Text text;

    private Camera cam;

    [SerializeField] CurrentPlace currentPlace;

    [SerializeField] Transform bunkerStartPos;
    [SerializeField] Transform overworldStartPos;

    private void Start()
    {
        cam = Camera.main;
        currentPlace = CurrentPlace.overworld;
    }
    void Update()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        if (Physics.Raycast(ray, out hit, pickupRange, layerMask))
        {
            text.text = "Press F to open door";
            if (Input.GetKeyDown(KeyCode.F) && currentPlace == CurrentPlace.overworld)
            {
                currentPlace = CurrentPlace.bunker;
                transform.position = bunkerStartPos.position;
            }
            else if (Input.GetKeyDown(KeyCode.F) && currentPlace == CurrentPlace.bunker)
            {
                currentPlace = CurrentPlace.overworld;
                transform.position = overworldStartPos.position;
            }
        }
        else
            text.text = "";

    }
}

public enum CurrentPlace
{
    bunker,
    overworld
}
