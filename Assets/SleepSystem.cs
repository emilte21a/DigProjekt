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

    [SerializeField] GameObject sleepScreen;

    bool isSleeping = false;

    private void Update()
    {
        if (lightingManager.TimeOfDay >= 21 && lightingManager.TimeOfDay <= 3)
        {
            sleepNeeded = true;
        }
        else
            sleepNeeded = false;

        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        if (Physics.Raycast(ray, out hit, interactionRange, layerMask) && !isSleeping)
        {
            if (lightingManager.TimeOfDay >= 21)
            {
                text.text = "Press F to sleep";
                if (Input.GetKeyDown(KeyCode.F))
                {
                    StartCoroutine(Sleep());
                }
            }
            else
                text.text = "You don't need sleep";

        }
        else if(!isSleeping)
            text.text = "";
    }

    public IEnumerator Sleep()
    {
        isSleeping = true;
        sleepScreen.SetActive(true);
        text.text = "Sleeping";
        yield return new WaitForSeconds(1);
        text.text += ".";
        yield return new WaitForSeconds(1);
        text.text += ".";
        yield return new WaitForSeconds(1);
        text.text += ".";
        yield return new WaitForSeconds(1);
        text.text += ".";
        yield return new WaitForSeconds(1);
        lightingManager.TimeOfDay = 6;
        lightingManager.day += 1;
        sleepNeeded = false;
        text.text = "";
        sleepScreen.SetActive(false);
        isSleeping = false;
    }

}
