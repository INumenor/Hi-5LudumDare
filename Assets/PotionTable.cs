using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PotionTable : MonoBehaviour
{
    public bool poting = false;
    private GameObject itemtarget;
    [SerializeField] private Slider slider;
    public void FixedUpdate()
    {
        if (transform.childCount > 0)
        {
            if (transform.GetChild(0).GetComponent<ItemScript>())
            {
                slider.gameObject.active =true;
                if (itemtarget == null && transform.childCount > 0)
                {
                    itemtarget = transform.GetChild(0).gameObject;
                }
                else if(!itemtarget.IsDestroyed())
                {
                    if (itemtarget.GetComponent<ItemScript>().isPotionable)
                    {
                        itemtarget.GetComponent<ItemScript>()._potionValue += 1* Time.deltaTime;
                        slider.value = itemtarget.GetComponent<ItemScript>()._potionValue;
                    }
                }
            }
        }
        else
        {
            itemtarget = null;
            slider.gameObject.active = false;
        }
        if (slider.value == slider.maxValue)
        {
            slider.value = slider.minValue;

        }
    }
}
