using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GUIcontroller : MonoBehaviour
{
    public LightingManager lightingManager;

    int hours;
    int minutes;

    public TMP_Text timeDisplayer;

    private TextMeshPro textValue;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        hours = Mathf.FloorToInt(lightingManager.TimeOfDay);
        minutes = Mathf.FloorToInt((lightingManager.TimeOfDay - hours) * 60f);
        timeDisplayer.text = $"Day:{lightingManager.day} :" + string.Format("{00:00}:{1:00}", hours, minutes);
    }

}
