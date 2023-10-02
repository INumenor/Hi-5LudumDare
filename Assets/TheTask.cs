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
    
    private float maxtimevalue = 10f;
    private float timevalue = 5f;
    private bool allSet = false;
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
        
        idtask firstChild_idtask = transform.GetChild(1).GetComponent<idtask>();
        idtask secondChild_idtask = transform.GetChild(2).GetComponent<idtask>();
        idtask thirdchild_idtask = transform.GetChild(3).GetComponent<idtask>();

        maxtimevalue = maxtimevalue + firstChild_idtask.Difficulty + secondChild_idtask.Difficulty + thirdchild_idtask.Difficulty;
        timevalue = maxtimevalue;
        allSet = true;
    }

    private void Update()
    {
        if (allSet)
        {
            timer();
        }
    }
    
    public void timer()
    {
        
        if (timevalue <= 0)
        {
            DeadlineReached();
            timevalue = maxtimevalue;
            
        }
        else
        {
            timevalue -= Time.deltaTime;
        }
    }

    public void DeadlineReached()
    {
        CharacterController Player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        Player._Health -= 1;
        Destroy(gameObject);
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
        
        
        
        if (firstChild_idtask._isActive == true && secondChild_idtask._isActive == true && thirdchild_idtask._isActive == true)
        {
            //Elin alma animasyonu burada devreye girecek.
            
            taskBag.iPop.Add(ID); 
            Debug.Log(ID);
            taskBag.createtask.Remove(this.gameObject);
            taskBag.Dict.Remove(ID);
            Destroy(gameObject); 
        }
    }
}
