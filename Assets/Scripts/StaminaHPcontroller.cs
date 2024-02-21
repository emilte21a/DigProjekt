using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaHPcontroller : MonoBehaviour
{
    public MovementController movementController;

    public Image staminaDisplay;
    

    // Update is called once per frame
    void Update()
    {
        float staminaHeight = movementController.stamina*20;

        staminaDisplay.rectTransform.sizeDelta = new Vector2(43.5f, staminaHeight);
    }
}
