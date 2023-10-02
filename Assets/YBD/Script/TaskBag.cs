using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TaskBag : MonoBehaviour
{
    [SerializeField] GameObject[] taskitem;

    
    public List<TaskItems> tasklist = new List<TaskItems>();
    public List<GameObject> createtask = new List<GameObject>();
    public List<Tasks> tasksInfo = new List<Tasks>();
    int number=1;
    public GameObject droppedTaskPrefab;
    public GameObject task;
    public GameObject clone;
    public GameObject taskcanvas;

    public Vector3 taskvector;
    int SlotValue;

    public List<int> iPop = new List<int>{ 1, 2, 3, 4, 5, 6, 7, 8, 9 };

    public Dictionary<int, GameObject> Dict = new Dictionary<int, GameObject>()
    {
    };
    [SerializeField]
    public int[] Slot1;

    [SerializeField]
    public int[] Slot2;

    [SerializeField]
    public int[] Slot3;
    private void Start()
    {
        clone = task;
        taskvector= new Vector3(-40f, 117.099998f, 0.471659988f);
    }
    TaskItems getDropItem()
    {
        if (createtask.Count <= 8)
        {
            int iRandomValue = Random.Range(0, 100);

            if (iRandomValue >= Slot1[0] && iRandomValue <= Slot1[1])
            {
                SlotValue = 1;
            }
            else if (iRandomValue > Slot2[0] && iRandomValue <= Slot2[1])
            {
                SlotValue = 2;
            }
            else if (iRandomValue > Slot3[0] && iRandomValue <= Slot3[1])
            {
                SlotValue = 3;
            }

            List<TaskItems> possibleItems = new List<TaskItems>();
            for (int i = 0; i < SlotValue; i++) {
                int randomNumber = Random.Range(1, 101);
                foreach (TaskItems item in tasklist)
                {
                    if (randomNumber >= item.mindropChance && randomNumber <= item.maxdropChance)
                    {
                        possibleItems.Add(item);
                    }
                }
            }

            GameObject clonejr = Instantiate(clone, new Vector2(0, 0), clone.transform.rotation);
            Transform parentTransform = clonejr.transform;
            GameObject firstChild = parentTransform.GetChild(1).gameObject;
            GameObject secondChild = parentTransform.GetChild(2).gameObject;
            GameObject thirdChild = parentTransform.GetChild(3).gameObject;
            //firstChild.GetComponent<idtask>()._isActive = true;
            //secondChild.GetComponent<idtask>()._isActive = true;
            //thirdChild.GetComponent<idtask>()._isActive = true;

            clonejr.transform.parent = taskcanvas.transform;
            clonejr.name = iPop[0].ToString();
            clonejr.transform.localPosition = new Vector3(taskvector.x, taskvector.y - 25, taskvector.z);
            clonejr.transform.localScale = new Vector3(1f, 1f, 1f);
            clonejr.transform.localRotation = new Quaternion(0, 0, 0, 0);

            for (int y = 0; y <= possibleItems.Count; y++)
            {

                if (y > 0)
                {
                    firstChild.GetComponent<Image>().sprite = possibleItems[0].TaskSprite;
                    firstChild.GetComponent<idtask>().ID = possibleItems[0].ID;
                    firstChild.GetComponent<idtask>()._isActive = false;
                    firstChild.active = true;
                }
                if (y > 1)
                {
                    secondChild.GetComponent<Image>().sprite = possibleItems[1].TaskSprite;
                    secondChild.GetComponent<idtask>().ID = possibleItems[1].ID;
                    secondChild.GetComponent<idtask>()._isActive = false;
                    secondChild.active = true;
                }
                if (y > 2)
                {
                    thirdChild.GetComponent<Image>().sprite = possibleItems[2].TaskSprite;
                    thirdChild.GetComponent<idtask>().ID = possibleItems[2].ID;
                    thirdChild.GetComponent<idtask>()._isActive = false;
                    thirdChild.active = true;
                }

            }
            taskvector.y = taskvector.y - 25;
            createtask.Add(clonejr);
            Dict.Add(iPop[0],clonejr);
            clonejr.GetComponent<TheTask>().ID = iPop[0];
            iPop.RemoveAt(0);
            //number++;
        }
        return null;
    }
    public void TaskInfo(int iSayi)
    {
        Destroy(createtask[iSayi]);
        createtask.RemoveAt(iSayi); 
    }
    public void Button()
    {
        getDropItem();
    }

}
