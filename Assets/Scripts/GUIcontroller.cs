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
    public PlayerScrapInteract playerScrapInteract;
    public HPController hPController;

    [Header("Stamina Display")]
    public Image staminaDisplay;

    [Header("HP Display")]
    public Image HPDisplay;

    [Header("Oxygen Display")]
    public Image oxygenDisplay;
    public TMP_Text oxygenText;

    [Header("Computer Display")]
    [SerializeField] TMP_Text computerScreenText;
    [SerializeField] Image computerDisplay;




    int hours;
    int minutes;
    [Header("Time Display")]
    public TMP_Text timeDisplayer;

    void Update()
    {
        UpdateTimeDisplay();
        UpdateStaminaHPBar();
        UpdateOxygenBar();
        UpdateComputerScreen();
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

        float hpHeight = hPController.HP;

        HPDisplay.rectTransform.sizeDelta = new Vector2(43.5f, hpHeight);

    }

    private void UpdateOxygenBar()
    {
        float oxygenHeight = oxygenController.oxygenLevel * 2;

        oxygenDisplay.rectTransform.sizeDelta = new Vector2(oxygenDisplay.rectTransform.sizeDelta.x, oxygenHeight);
        oxygenText.text = oxygenController.oxygenLevel + "%";

        if (oxygenController.oxygenLevel <= 20)
        {
            oxygenDisplay.color = Color.red;
        }
        else
            oxygenDisplay.color = Color.cyan;
    }

    private void UpdateComputerScreen()
    {
        float scrapCountWidth = -180 + playerScrapInteract.scrapCount * 5;

        computerScreenText.text = $"{playerScrapInteract.scrapCount}/36";
        computerDisplay.rectTransform.offsetMax = new Vector2(oxygenDisplay.rectTransform.offsetMax.x, scrapCountWidth);
    }

}
