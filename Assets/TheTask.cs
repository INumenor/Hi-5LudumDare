using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TheTask : MonoBehaviour
{
    public int ID = 0;
    private void Start()
    {
        Text idNumber = transform.GetChild(0).GetComponent<Text>();
        idNumber.text = ID.ToString();
    }

    public void CheckForCompletion() //her bir id tamamlandığında çalışır
    {
        idtask firstChild = transform.GetChild(1).GetComponent<idtask>();
        idtask secondChild = transform.GetChild(2).GetComponent<idtask>();
        idtask thirdchild = transform.GetChild(3).GetComponent<idtask>();

        if (firstChild._isActive == true && secondChild._isActive == true && thirdchild._isActive == true)
        {
            //Elin alma animasyonu burada devreye girecek, görev silinecek, görev_id pooluna bu görevin idsi geri eklenecek.
        }
    }
}
