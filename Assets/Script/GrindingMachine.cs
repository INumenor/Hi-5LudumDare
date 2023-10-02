using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DentedPixel;
using Unity.VisualScripting;
using UnityEditor;

public class GrindingMachine : MonoBehaviour
{
    public bool isGrind = false;
    public GameObject itemtarget;
    [SerializeField]private Slider slider;
    public void Start()
    {
        
    }


    public void FixedUpdate()
    {
        if (isGrind != false)
        {
            slider.gameObject.active = true;
            if (itemtarget == null && transform.childCount > 0)
            {
                itemtarget = transform.GetChild(0).gameObject;
            }
            else if(!itemtarget.IsDestroyed())
            {
                if (itemtarget.GetComponent<ItemScript>().isGrindable)
                {
                    itemtarget.GetComponent<ItemScript>()._grindValue += 1* Time.deltaTime;
                    slider.value = itemtarget.GetComponent<ItemScript>()._grindValue;
                }

            }
        }
        else
        {
            itemtarget = null;
            slider.gameObject.active = false;
        }
        if(slider.value == slider.maxValue)
        {
            slider.value = slider.minValue;
            
        }
    }
}
