using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SleepSystem : MonoBehaviour
{
    [SerializeField] LightingManager lightingManager;

    [SerializeField] bool sleepNeeded = false;


    [SerializeField] private float interactionRange;

    [SerializeField] LayerMask layerMask;

    [SerializeField] TMP_Text text;

    [SerializeField] Camera cam;

    private void Update()
    {
        if (lightingManager.TimeOfDay >= 21)
        {
            sleepNeeded = true;
        }
        else
            sleepNeeded = false;


        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        if (Physics.Raycast(ray, out hit, interactionRange, layerMask))
        {
            if (lightingManager.TimeOfDay >= 21)
            {
                text.text = "Press F to sleep";
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Sleep();
                    cam.GetComponent<Animator>().Play(2);
                }
            }
            else
                text.text = "You don't need sleep";

        }
        else
            text.text = "";
    }

    public void Sleep()
    {
        lightingManager.TimeOfDay = 6;
        lightingManager.day += 1;
        sleepNeeded = false;
    }

}
