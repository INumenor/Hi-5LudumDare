using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElixirTable : MonoBehaviour
{
    private bool isMergable = true;
    [SerializeField] private GameObject Slot1;
    [SerializeField] private GameObject Slot2;
    [SerializeField] private GameObject BlueBottle;
    [SerializeField] private GameObject GreenBottle;
    [SerializeField] private float maxMerging = 5;
    [SerializeField] private AudioSource _audioSource;
    private float merging;
    private GameObject result = null;
    public Slider slider;
    
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
            slider.gameObject.active = true;
            if (Slot1.transform.GetChild(0).GetComponent<ItemScript>().ID == 2 &&
                Slot2.transform.GetChild(0).GetComponent<ItemScript>().ID == 13 ||
                Slot2.transform.GetChild(0).GetComponent<ItemScript>().ID == 2 &&
                Slot1.transform.GetChild(0).GetComponent<ItemScript>().ID == 13)
            {
                _merging += 1* Time.deltaTime;
                if (!_audioSource.isPlaying)
                {
                    _audioSource.Play();
                }
                result = GreenBottle;
                slider.value = _merging;
            }
            else if (Slot1.transform.GetChild(0).GetComponent<ItemScript>().ID == 3 &&
                     Slot2.transform.GetChild(0).GetComponent<ItemScript>().ID == 13 ||
                     Slot2.transform.GetChild(0).GetComponent<ItemScript>().ID == 3 &&
                     Slot1.transform.GetChild(0).GetComponent<ItemScript>().ID == 13)
            {
                _merging += 1* Time.deltaTime;
                if (!_audioSource.isPlaying)
                {
                    _audioSource.Play();
                }
                result = BlueBottle;
                slider.value = _merging;
            }
        }
        else
        {
            _audioSource.Stop();
            slider.gameObject.active = false;
            merging = 0;
        }
        if (slider.value == slider.maxValue)
        {
            slider.value = slider.minValue;
        }
    }
}
