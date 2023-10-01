using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MergingTable : MonoBehaviour
{
    public bool isGrind = false;
    [SerializeField] private GameObject Slot1;
    [SerializeField] private GameObject Slot2;
    
    [SerializeField] private GameObject Spear;

    [SerializeField] private float maxMerging = 5;
    private float merging;
    private GameObject result = null;

    public float _merging
    {
        get
        {
            return merging;
        }
        set
        {
            merging = value;
            if (value >= maxMerging)
            {
                Debug.Log("İşlemi tamamla");
                GameObject shineyObject = Instantiate(result, new Vector2(0, 0), Quaternion.identity);
                shineyObject.transform.parent = Slot1.transform;
                shineyObject.transform.localPosition = Vector2.zero;
                //Destroy(this);
                Destroy(Slot1.transform.GetChild(0));
                Destroy(Slot2.transform.GetChild(0));

            }
        }
    }
    public void FixedUpdate()
    {
        if (isGrind)
        {
            if (Slot1.transform.childCount > 1 && Slot2.transform.childCount > 4)
            {
                if (Slot1.transform.GetChild(0).GetComponent<ItemScript>().ID == 0 &&
                    Slot2.transform.GetChild(0).GetComponent<ItemScript>().ID == 0)
                {
                    _merging += 1* Time.deltaTime;
                    result = Spear;
                }
            }
            else
            {
                merging = 0;//WIP
            }
        }
    }
}
