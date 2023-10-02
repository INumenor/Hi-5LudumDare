using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] public Slider slider;

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
            slider.gameObject.active = true;
            if (Slot1.transform.childCount > 0 && Slot2.transform.childCount > 0)
            {
                if (Slot1.transform.GetChild(0).GetComponent<ItemScript>().ID == 4 &&
                    Slot2.transform.GetChild(0).GetComponent<ItemScript>().ID == 14 ||
                    Slot2.transform.GetChild(0).GetComponent<ItemScript>().ID == 4 &&
                    Slot1.transform.GetChild(0).GetComponent<ItemScript>().ID == 14)
                {
                    _merging += 1* Time.deltaTime;
                    result = Spear;
                    slider.value = _merging;
                }
                else if (Slot1.transform.GetChild(0).GetComponent<ItemScript>().ID == 8 &&
                         Slot2.transform.GetChild(0).GetComponent<ItemScript>().ID == 7 ||
                         Slot2.transform.GetChild(0).GetComponent<ItemScript>().ID == 8 &&
                         Slot1.transform.GetChild(0).GetComponent<ItemScript>().ID == 7)
                {
                    _merging += 1* Time.deltaTime;
                    result = PoisonedSpear;
                    slider.value = _merging;
                }
                else if (Slot1.transform.GetChild(0).GetComponent<ItemScript>().ID == 6 &&
                         Slot2.transform.GetChild(0).GetComponent<ItemScript>().ID == 8 ||
                         Slot2.transform.GetChild(0).GetComponent<ItemScript>().ID == 6 &&
                         Slot1.transform.GetChild(0).GetComponent<ItemScript>().ID == 8)
                {
                    _merging += 1* Time.deltaTime;
                    result = ElectricedSpear;
                    slider.value = _merging;
                }
                else if (Slot1.transform.GetChild(0).GetComponent<ItemScript>().ID == 7 &&
                         Slot2.transform.GetChild(0).GetComponent<ItemScript>().ID == 14 ||
                         Slot2.transform.GetChild(0).GetComponent<ItemScript>().ID == 7 &&
                         Slot1.transform.GetChild(0).GetComponent<ItemScript>().ID == 14)
                {
                    _merging += 1* Time.deltaTime;
                    result = PoisonedKnife;
                    slider.value = _merging;
                }
                else if (Slot1.transform.GetChild(0).GetComponent<ItemScript>().ID == 6 &&
                         Slot2.transform.GetChild(0).GetComponent<ItemScript>().ID == 14 ||
                         Slot2.transform.GetChild(0).GetComponent<ItemScript>().ID == 6 &&
                         Slot1.transform.GetChild(0).GetComponent<ItemScript>().ID == 14)
                {
                    _merging += 1* Time.deltaTime;
                    result = ElectricedKnife;
                    slider.value = _merging;
                }
            }
                
        }
        else
        {
            slider.gameObject.active = false;
        }
        if (slider.value == slider.maxValue)
        {
            slider.value = slider.minValue;
        }
    }
}
