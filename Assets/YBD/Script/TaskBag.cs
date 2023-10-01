using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TaskBag : MonoBehaviour
{
    public GameObject droppedTaskPrefab;
    public List<TaskItems> tasklist = new List<TaskItems>();
    [SerializeField] GameObject[] taskýtem;
    int SlotValue;

    
    [SerializeField]
    public int[] Slot1;

    [SerializeField]
    public int[] Slot2;

    [SerializeField]
    public int[] Slot3;
    TaskItems getDropItem()
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
        
        int randomNumber = Random.Range(1, 101);
        List<TaskItems> possibleItems = new List<TaskItems>();
        for (int i=0;i<SlotValue;i++) {
            foreach (TaskItems item in tasklist)
            {
                if (randomNumber >= item.mindropChance && randomNumber <= item.maxdropChance)
                {
                    possibleItems.Add(item);
                    Debug.Log(item.name);

                }
            }
        }
        
        for (int y = 0; y < possibleItems.Count;y++)
        {
            TaskItems droppedItem = possibleItems[y];
            taskýtem[y].GetComponent<Image>().sprite = droppedItem.TaskSprite;
            
           
        }
        return null;
    }
    public void Button()
    {
        getDropItem();
    }

}
