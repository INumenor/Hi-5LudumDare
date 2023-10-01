using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;
using Unity.VisualScripting;
using UnityEditor;

public class GrindingMachine : MonoBehaviour
{
    public bool isGrind = false;
    private GameObject itemtarget;
    public void Start()
    {
        
    }


    public void FixedUpdate()
    {
        if (isGrind != false)
        {
            if (itemtarget == null && transform.childCount > 0)
            {
                itemtarget = transform.GetChild(0).gameObject;
            }
            else if(!itemtarget.IsDestroyed())
            {
                if (itemtarget.GetComponent<ItemScript>().isGrindable)
                {
                    itemtarget.GetComponent<ItemScript>()._grindValue += 1* Time.deltaTime;
                }
            }
           
        }
    }
}
