using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TaskBag : MonoBehaviour
{
    public GameObject droppedTaskPrefab;
    public List<TaskItems> tasklist = new List<TaskItems>();
    [SerializeField] GameObject[] taskýtem;
    public GameObject task;
    public GameObject clone;
    public List<GameObject> createtask = new List<GameObject>();
    public GameObject taskcanvas;
    public Vector3 taskvector;
    int SlotValue;

    
    [SerializeField]
    public int[] Slot1;

    [SerializeField]
    public int[] Slot2;

    [SerializeField]
    public int[] Slot3;
    private void Start()
    {
        clone = task;
        taskvector= new Vector3(-113.57f, -121.580002f-25, 0.471659988f);
    }
    TaskItems getDropItem()
    {
        if(createtask.Count <= 7)
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

        GameObject clonejr = Instantiate(clone, new Vector2(0, 0), Quaternion.identity);
        Transform parentTransform = clonejr.transform;
        GameObject firstChild = parentTransform.GetChild(0).gameObject;
        GameObject secondChild = parentTransform.GetChild(1).gameObject;
        GameObject thirdChild = parentTransform.GetChild(2).gameObject;
        clonejr.transform.parent = taskcanvas.transform;
        clonejr.transform.localPosition = new Vector3(taskvector.x, taskvector.y + 25, taskvector.z);
        clonejr.transform.localRotation = new Quaternion(0, 180, 0, 0);
        clonejr.transform.localScale = new Vector3(22.4111576f, 5.32264996f, 22.4111576f);

        for (int y = 0; y <= possibleItems.Count; y++)
        {

            if (y > 0)
            {
                firstChild.GetComponent<Image>().sprite = possibleItems[0].TaskSprite;
                firstChild.GetComponent<Image>().color = new Color32(84, 84, 84, 160);
                firstChild.active = true;
            }
            if (y > 1)
            {
                secondChild.GetComponent<Image>().sprite = possibleItems[1].TaskSprite;
                secondChild.GetComponent<Image>().color = new Color32(84, 84, 84, 160);
                secondChild.active = true;
            }
            if (y > 2)
            {
                thirdChild.GetComponent<Image>().sprite = possibleItems[2].TaskSprite;
                thirdChild.GetComponent<Image>().color = new Color32(84, 84, 84, 160);
                thirdChild.active = true;
            }

        }
        clonejr.name = (createtask.Count + 1).ToString();
        createtask.Add(clonejr);
        taskvector.y = taskvector.y + 25;
    }
        return null;
    }
    public void Button()
    {
        getDropItem();
    }

}
