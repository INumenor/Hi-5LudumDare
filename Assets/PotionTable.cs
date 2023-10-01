using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PotionTable : MonoBehaviour
{
    public bool poting = false;
    private GameObject itemtarget;
    public void FixedUpdate()
    {
        if (transform.childCount > 0)
        {
            if (transform.GetChild(0).GetComponent<ItemScript>())
            {
                if (itemtarget == null && transform.childCount > 0)
                {
                    itemtarget = transform.GetChild(0).gameObject;
                }
                else if(!itemtarget.IsDestroyed())
                {
                    if (itemtarget.GetComponent<ItemScript>().isPotionable)
                    {
                        itemtarget.GetComponent<ItemScript>()._potionValue += 1* Time.deltaTime;
                    }
                }
            }
        }
    }
}
