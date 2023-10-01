using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElixirTable : MonoBehaviour
{
    private bool isMergable = true;
    [SerializeField] private GameObject Slot1;
    [SerializeField] private GameObject Slot2;
    [SerializeField] private GameObject BlueBottle;
    [SerializeField] private GameObject GreenBottle;
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
                //isMergable = false;
                Debug.Log("İşlemi tamamla");
                GameObject shineyObject = Instantiate(result, new Vector2(0, 0), Quaternion.identity);
                shineyObject.transform.parent = Slot1.transform;
                shineyObject.transform.localPosition = Vector2.zero;
                //Destroy(this) ;
                Destroy(Slot1.transform.GetChild(0).gameObject);
                Destroy(Slot2.transform.GetChild(0).gameObject);
                
                merging = 0;
                //Slot1.GetComponent<TileSlot>()._isFull = false;
                Slot2.GetComponent<TileSlot>()._isFull = false;


            }
        }
    }
    public void FixedUpdate()
    {
        if (Slot1.transform.childCount > 0 && Slot2.transform.childCount > 0)
        {
            if (Slot1.transform.GetChild(0).GetComponent<ItemScript>().ID == 2 &&
                Slot2.transform.GetChild(0).GetComponent<ItemScript>().ID == 13 ||
                Slot2.transform.GetChild(0).GetComponent<ItemScript>().ID == 2 &&
                Slot1.transform.GetChild(0).GetComponent<ItemScript>().ID == 13)
            {
                _merging += 1* Time.deltaTime;
                result = GreenBottle;
            }
            else if (Slot1.transform.GetChild(0).GetComponent<ItemScript>().ID == 3 &&
                     Slot2.transform.GetChild(0).GetComponent<ItemScript>().ID == 13 ||
                     Slot2.transform.GetChild(0).GetComponent<ItemScript>().ID == 3 &&
                     Slot1.transform.GetChild(0).GetComponent<ItemScript>().ID == 13)
            {
                _merging += 1* Time.deltaTime;
                result = BlueBottle;
            }
        }
        else
        {
            merging = 0;
        }
    }
}
