using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
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
                if (task.Value.GetComponent<TheTask>().ID == ID)
                {
                    Debug.Log(task.Value);
                    GameObject parentTransform = task.Value;
                    GameObject firstChild = parentTransform.transform.GetChild(1).gameObject;
                    GameObject secondChild = parentTransform.transform.GetChild(2).gameObject;
                    GameObject thirdchild = parentTransform.transform.GetChild(3).gameObject;
                    
                    //içimdeki itemin idsi ile taskteki herhangi bir itemin idsi uyuşuyorsa içimdeki itemi yok et ve taskteki itemi tamamlanmış hale getir. 

                    
                    
                    
                    
                    
                    
                    
                    
                    
                    

                    
                }
            }
        //    //Taske işle
        }
    }
}
