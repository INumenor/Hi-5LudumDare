using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TaskDisplay : MonoBehaviour
{
    public Texture[] Items;
    public GameObject Task;
    public GameObject Canvas;
    public GameObject[] Tasks;
    public int SlotValue;
    public Sprite game;
    public Items[] items;
    public Items[] taskitems;
    
    [SerializeField]
    public int[] Slot1;

    [SerializeField]
    public int[] Slot2;

    [SerializeField]
    public int[] Slot3;

    void Awake()
    {
        int iRandomValue = Random.Range(0, 100);
        
        if(iRandomValue >= Slot1[0] &&  iRandomValue <= Slot1[1])
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
        taskitems = new Items[SlotValue];
        for (int y = 0; y < SlotValue; y++)
        {
            int iRandomItemValue = Random.Range(0, 100);

            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].minvalue < iRandomItemValue && items[i].maxvalue > iRandomItemValue)
                {
                    taskitems[y] = items[i];
                }
            }
        }
        
        //Task.GetComponent<CreatingTask>().obj2.texture = Items[1];
        //Task.GetComponent<CreatingTask>().obj3.texture = Items[2];
        GameObject CopyTask = Instantiate(Task,new Vector2(0,0),Quaternion.identity);
        CopyTask.transform.parent = Canvas.transform;
        CopyTask.transform.localPosition = new Vector2(-180,100);

        //for(int z = 0; z < SlotValue; z++)
        //{
              Debug.Log(Task.transform.GetChild(1).GetComponent<RawImage>().texture);
              Task.transform.GetChild(2).GetComponent<RawImage>().texture = game.texture;
        //    Task.GetComponent<CreatingTask>().obj1.material.mainTexture = items[0].Image;
        //    if (z >= 1)
        //    {
        //        Task.GetComponent<CreatingTask>().obj2.texture = items[1].Image;
        //        Task.GetComponent<CreatingTask>().objg2.active = true;
        //    }
        //    if (z >= 2)
        //    {
        //        Task.GetComponent<CreatingTask>().obj3.texture = items[2].Image;
        //        Task.GetComponent<CreatingTask>().objg3.active = true;
        //    }
        //}

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
