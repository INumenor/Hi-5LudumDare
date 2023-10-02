using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class DeliverSlot : MonoBehaviour
{
    [SerializeField] public int ID;
    [SerializeField] public TaskBag taskBag;

    public void Update()
    {
        if (transform.childCount > 1)
        {
            //Yok et transform.GetChild(1)
            foreach (var task in taskBag.Dict)
            {
                if (task.Key == ID)
                {
                    Debug.Log(task.Value);
                    GameObject parentTransform = task.Value;
                    GameObject firstChild = parentTransform.transform.GetChild(1).gameObject;
                    GameObject secondChild = parentTransform.transform.GetChild(2).gameObject;
                    GameObject thirdchild = parentTransform.transform.GetChild(3).gameObject;

                    if (!secondChild.active)
                    {
                        secondChild.name = "Correct";
                    }
                    if (!thirdchild.active)
                    {
                        thirdchild.name = "Correct";
                    }

                    if (firstChild.active && firstChild.GetComponent<Image>().sprite.name == transform.GetChild(1).name
                        && firstChild.GetComponent<Image>().color != Color.black)
                    {
                        firstChild.GetComponent<Image>().color = Color.black;
                        firstChild.name = "Correct";
                        Destroy(transform.GetChild(1).gameObject);
                        transform.GetComponent<TileSlot>()._isFull = false;
                    }
                    else if (secondChild.active && secondChild.GetComponent<Image>().sprite.name == transform.GetChild(1).name
                        && secondChild.GetComponent<Image>().color != Color.black)
                    {
                        secondChild.GetComponent<Image>().color = Color.black;
                        secondChild.name = "Correct";
                        Destroy(transform.GetChild(1).gameObject);
                        transform.GetComponent<TileSlot>()._isFull = false;
                    }
                    else if (thirdchild.active && thirdchild.GetComponent<Image>().sprite.name == transform.GetChild(1).name
                        && thirdchild.GetComponent<Image>().color != Color.black)
                    {
                        thirdchild.GetComponent<Image>().color = Color.black;
                        thirdchild.name = "Correct";
                        Destroy(transform.GetChild(1).gameObject);
                        transform.GetComponent<TileSlot>()._isFull = false;
                    }
                    if(thirdchild.name == "Correct" && secondChild.name == "Correct" && firstChild.name == "Correct")
                    {
                        Debug.Log(task.Key);
                        Debug.Log(taskBag.createtask.Count);
                        taskBag.TaskInfo(task.Key-1);
                        taskBag.IPopAdd(task.Key);
                    }
                    //Debug.Log(transform.GetChild(1).name);
                    //Debug.Log(firstChild.GetComponent<Image>().sprite.name);
                }
            }
        //    //Taske işle
        }
    }
}
