using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class DeliverSlot : MonoBehaviour
{
    public int ID;
    [SerializeField] private TaskBag taskBag;

    private void Start()
    {
        

        
    }

    public void Update()
    {
        if (transform.childCount > 0)
        {
            foreach (var task in taskBag.Dict)
            {
                if (taskBag.Dict.Count > 0)
                {
                    if (task.Value.GetComponent<TheTask>().ID == ID)
                    {
                        //Debug.Log(task.Value);
                        GameObject parentTransform = task.Value;
                        GameObject firstChild = parentTransform.transform.GetChild(1).gameObject;
                        GameObject secondChild = parentTransform.transform.GetChild(2).gameObject;
                        GameObject thirdchild = parentTransform.transform.GetChild(3).gameObject;

                        int itemID = transform.GetChild(0).GetComponent<ItemScript>().ID;
                        
                        // İçerideki erişilen id güncellenecek
                        if (firstChild.GetComponent<idtask>().ID == itemID && firstChild.GetComponent<idtask>()._isActive == false && transform.childCount > 0)
                        {
                            firstChild.GetComponent<idtask>()._isActive = true;
                            transform.GetComponent<TileSlot>()._isFull = false;
                            Destroy(transform.GetChild(0).gameObject);
                        }else if(secondChild.GetComponent<idtask>().ID == itemID && secondChild.GetComponent<idtask>()._isActive == false && transform.childCount > 0)
                        {
                            secondChild.GetComponent<idtask>()._isActive = true;
                            transform.GetComponent<TileSlot>()._isFull = false;
                            Destroy(transform.GetChild(0).gameObject);
                        }else if(thirdchild.GetComponent<idtask>().ID == itemID && thirdchild.GetComponent<idtask>()._isActive == false && transform.childCount > 0)
                        {
                            thirdchild.GetComponent<idtask>()._isActive = true;
                            transform.GetComponent<TileSlot>()._isFull = false;
                            Destroy(transform.GetChild(0).gameObject);
                        }

                        //içimdeki itemin idsi ile ___ taskteki herhangi bir itemin idsi uyuşuyorsa içimdeki itemi yok et ve taskteki itemi tamamlanmış hale getir. 


                        
                    
                    }
                }
            }

            taskBag.Dict[ID].GetComponent<TheTask>().CheckForCompletion();
        }
    }
}
