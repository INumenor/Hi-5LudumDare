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

                    int itemID = transform.GetChild(1).GetComponent<ItemScript>().ID;
                    // İçerideki erişilen id güncellenecek
                    if (firstChild.GetComponent<idtask>().ID == itemID && firstChild.GetComponent<idtask>()._isActive == false && transform.childCount > 1)
                    {
                        firstChild.GetComponent<idtask>()._isActive = true;
                        transform.GetComponent<TileSlot>()._isFull = false;
                        Destroy(transform.GetChild(1).gameObject);
                    }else if(secondChild.GetComponent<idtask>().ID == itemID && secondChild.GetComponent<idtask>()._isActive == false && transform.childCount > 1)
                    {
                        secondChild.GetComponent<idtask>()._isActive = true;
                        transform.GetComponent<TileSlot>()._isFull = false;
                        Destroy(transform.GetChild(1).gameObject);
                    }else if(thirdchild.GetComponent<idtask>().ID == itemID && thirdchild.GetComponent<idtask>()._isActive == false && transform.childCount > 1)
                    {
                        thirdchild.GetComponent<idtask>()._isActive = true;
                        transform.GetComponent<TileSlot>()._isFull = false;
                        Destroy(transform.GetChild(1).gameObject);
                    }

                    //içimdeki itemin idsi ile ___ taskteki herhangi bir itemin idsi uyuşuyorsa içimdeki itemi yok et ve taskteki itemi tamamlanmış hale getir. 

                    
                    
                    
                    
                    
                    
                    
                    
                    
                    

                    
                }
            }
        //    //Taske işle
        }
    }
}
