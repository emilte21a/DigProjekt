using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;

public class OxygenController : MonoBehaviour
{
    [SerializeField] private float pickupRange = 5;

    [SerializeField] LayerMask isOxygenStation;

    [SerializeField, Range(0, 100)] public float oxygenLevel = 100;
    private Camera cam;
    [SerializeField] float timer = 1;
    [SerializeField] float timeOffset = 1;

    [SerializeField] TMP_Text text;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        if (Physics.Raycast(ray, out hit, pickupRange, isOxygenStation))
        {
            if (oxygenLevel != 100)
            {
                text.text = "Press F to refill oxygen";
                if (Input.GetKeyDown(KeyCode.F))
                {
                    oxygenLevel = 100;
                }
            }
            else
                text.text = "You have enough oxygen";
        }
        else
            text.text = "";

        if (timer <= 0)
        {
            timer = 1;
            oxygenLevel -= 1;
        }
        timer -= Time.deltaTime / timeOffset;
    }
}
