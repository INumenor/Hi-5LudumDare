using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MergingTable : MonoBehaviour
{
    public bool isGrind = false;
    private bool isMergable = true;
    [SerializeField] private GameObject Slot1;
    [SerializeField] private GameObject Slot2;
    
    [SerializeField] private GameObject Spear;
    [SerializeField] private GameObject PoisonedSpear;
    [SerializeField] private GameObject ElectricedSpear;
    [SerializeField] private GameObject PoisonedKnife;
    [SerializeField] private GameObject ElectricedKnife;

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
            Debug.Log("Yapılıyor...");
            if (value >= maxMerging)
            {
                //isMergable = false;
                Debug.Log("İşlemi tamamla");
                GameObject shineyObject = Instantiate(result, new Vector2(0, 0), Quaternion.identity);
                shineyObject.transform.parent = Slot1.transform;
                shineyObject.transform.localPosition = Vector2.zero;
                //Destroy(this) ;
                Destroy(Slot1.transform.GetChild(0).gameObject);
                Destroy(Slot2.transform.GetChild(0).gameObject);
                
                //Slot1.GetComponent<TileSlot>()._isFull = false;
                Slot2.GetComponent<TileSlot>()._isFull = false;
                merging = 0;


            }
        }
    }
    public void FixedUpdate()
    {
        if (isGrind && isMergable)
        {
            if (Slot1.transform.childCount > 0 && Slot2.transform.childCount > 0)
            {
                if (Slot1.transform.GetChild(0).GetComponent<ItemScript>().ID == 4 &&
                    Slot2.transform.GetChild(0).GetComponent<ItemScript>().ID == 14 ||
                    Slot2.transform.GetChild(0).GetComponent<ItemScript>().ID == 4 &&
                    Slot1.transform.GetChild(0).GetComponent<ItemScript>().ID == 14)
                {
                    _merging += 1* Time.deltaTime;
                    result = Spear;
                }
                else if (Slot1.transform.GetChild(0).GetComponent<ItemScript>().ID == 8 &&
                         Slot2.transform.GetChild(0).GetComponent<ItemScript>().ID == 7 ||
                         Slot2.transform.GetChild(0).GetComponent<ItemScript>().ID == 8 &&
                         Slot1.transform.GetChild(0).GetComponent<ItemScript>().ID == 7)
                {
                    _merging += 1* Time.deltaTime;
                    result = PoisonedSpear;
                }
                else if (Slot1.transform.GetChild(0).GetComponent<ItemScript>().ID == 6 &&
                         Slot2.transform.GetChild(0).GetComponent<ItemScript>().ID == 9 ||
                         Slot2.transform.GetChild(0).GetComponent<ItemScript>().ID == 6 &&
                         Slot1.transform.GetChild(0).GetComponent<ItemScript>().ID == 9)
                {
                    _merging += 1* Time.deltaTime;
                    result = ElectricedKnife;
                }
                else if (Slot1.transform.GetChild(0).GetComponent<ItemScript>().ID == 7 &&
                         Slot2.transform.GetChild(0).GetComponent<ItemScript>().ID == 14 ||
                         Slot2.transform.GetChild(0).GetComponent<ItemScript>().ID == 7 &&
                         Slot1.transform.GetChild(0).GetComponent<ItemScript>().ID == 14)
                {
                    _merging += 1* Time.deltaTime;
                    result = PoisonedKnife;
                }
                else if (Slot1.transform.GetChild(0).GetComponent<ItemScript>().ID == 6 &&
                         Slot2.transform.GetChild(0).GetComponent<ItemScript>().ID == 14 ||
                         Slot2.transform.GetChild(0).GetComponent<ItemScript>().ID == 6 &&
                         Slot1.transform.GetChild(0).GetComponent<ItemScript>().ID == 14)
                {
                    _merging += 1* Time.deltaTime;
                    result = ElectricedKnife;
                }
            }
                
        }
    }
}
