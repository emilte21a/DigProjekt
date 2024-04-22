using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class OxygenController : MonoBehaviour
{
    [SerializeField, Range(0, 100)] public float oxygenLevel = 100;
    [SerializeField] float timer = 1;
    [SerializeField] float timeOffset = 1;

    private void Update()
    {

        if (timer <= 0)
        {
            timer = 1;
            oxygenLevel -= 1;
        }
        timer -= Time.deltaTime / timeOffset;
    }
}
