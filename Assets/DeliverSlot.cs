using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverSlot : MonoBehaviour
{
    [SerializeField] private int ID;
    [SerializeField] private TaskBag taskBag;

    private void Start()
    {
        

        
    }

    public void Update()
    {
        if (transform.childCount > 1)
        {
            //Yok et transform.GetChild(1)
            foreach (var task in taskBag.Dict)
            {
                if (task.Key == ID)
                {
                    
                }
            }
            //Taske işle
        }
    }
}
