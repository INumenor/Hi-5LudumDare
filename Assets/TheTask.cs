using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TheTask : MonoBehaviour
{
    public int ID = 0;
    private TaskBag taskBag;
    private bool deathSign;

    public bool _deathSign
    {
        get
        {
            return deathSign;
        }
        set
        {
            deathSign = value;
        }
    }
    private void Start()
    {
        Text idNumber = transform.GetChild(0).GetComponent<Text>();
        idNumber.text = ID.ToString();
        taskBag = GameObject.FindGameObjectWithTag("TaskBag").GetComponent<TaskBag>();
    }

    public void CheckForCompletion() //her bir id tamamlandığında çalışır
    {
        GameObject firstChild = transform.GetChild(1).gameObject;
        GameObject secondChild = transform.GetChild(1).gameObject;
        GameObject thirdChild = transform.GetChild(1).gameObject;
        
        idtask firstChild_idtask = transform.GetChild(1).GetComponent<idtask>();
        idtask secondChild_idtask = transform.GetChild(2).GetComponent<idtask>();
        idtask thirdchild_idtask = transform.GetChild(3).GetComponent<idtask>();
        taskBag = GameObject.FindGameObjectWithTag("TaskBag").GetComponent<TaskBag>();
        Debug.Log(taskBag.Dict);
        
        
        if (firstChild_idtask._isActive == true && secondChild_idtask._isActive == true && thirdchild_idtask._isActive == true)
        {
            //Elin alma animasyonu burada devreye girecek, görev silinecek, görev_id pooluna bu görevin idsi geri eklenecek
            taskBag.iPop.Add(ID); 
            Debug.Log(ID);
            taskBag.createtask.Remove(this.gameObject);
            taskBag.Dict.Remove(ID);
            Destroy(gameObject); 
        }
    }
}
