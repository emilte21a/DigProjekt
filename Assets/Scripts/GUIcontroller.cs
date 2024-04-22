using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GUIcontroller : MonoBehaviour
{
    [Header("Instances")]
    public LightingManager lightingManager;

    public MovementController movementController;
    public OxygenController oxygenController;

    [Header("Stamina Display")]
    public Image staminaDisplay;

    [Header("Oxygen Display")]
    public Image oxygenDisplay;
    public TMP_Text oxygenText;


    int hours;
    int minutes;
    [Header("Time Display")]
    public TMP_Text timeDisplayer;

    void Update()
    {
        UpdateTimeDisplay();
        UpdateStaminaHPBar();
        UpdateOxygenBar();
    }

    private void UpdateTimeDisplay()
    {
        hours = Mathf.FloorToInt(lightingManager.TimeOfDay);
        minutes = Mathf.FloorToInt((lightingManager.TimeOfDay - hours) * 60f);
        timeDisplayer.text = $"Day:{lightingManager.day} :" + string.Format("{00:00}:{1:00}", hours, minutes);
    }

    private void UpdateStaminaHPBar()
    {
        float staminaHeight = movementController.stamina * 20;

        staminaDisplay.rectTransform.sizeDelta = new Vector2(43.5f, staminaHeight);


    }
    private void UpdateOxygenBar()
    {
        float oxygenHeight = oxygenController.oxygenLevel * 2;

        oxygenDisplay.rectTransform.sizeDelta = new Vector2(oxygenDisplay.rectTransform.sizeDelta.x, oxygenHeight);
        oxygenText.text = oxygenController.oxygenLevel + "%";

        if (oxygenController.oxygenLevel <= 20)
        {
            
        }
    }

}
