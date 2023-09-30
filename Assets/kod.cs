using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class NewBehaviourScript : MonoBehaviour
{
    [Header("Timer")]
    [SerializeField] private float indicatorTimer = 1.0f;
    [SerializeField] private float maxIndicatorTimer = 1.0f;

    [Header("UI indicator")]
    [SerializeField] private Image radialIndicatorUI = null;

    [Header("Key Codes")]
    [SerializeField] private KeyCode selectKey = KeyCode.Mouse0;

    [Header("Unity Event")]
    [SerializeField] private UnityEvent myEvent = null;

    private bool update = false;
    
    private void Update()
    {
        if (Input.GetKey(selectKey))
        {
            indicatorTimer -= Time.deltaTime;
            radialIndicatorUI.enabled = true;
            radialIndicatorUI.fillAmount = indicatorTimer;

            if(indicatorTimer <= 0)
            {
                indicatorTimer = maxIndicatorTimer;
                radialIndicatorUI.fillAmount = maxIndicatorTimer;
                radialIndicatorUI.enabled = false;
                myEvent.Invoke();
            }
        }
        else
        {
            if (update)
            {
                indicatorTimer += Time.deltaTime;
                radialIndicatorUI.fillAmount = indicatorTimer;

                if (indicatorTimer >= maxIndicatorTimer)
                {
                    indicatorTimer = maxIndicatorTimer;
                    radialIndicatorUI.fillAmount = maxIndicatorTimer;
                    radialIndicatorUI.enabled = false;
                    update = false;
                }
            }
            
        }

        if (Input.GetKeyUp(selectKey))
        {
            update = true;
        }
    }
}
