using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tasks 
{
    int SlotNumber;
    Image[] SlotImage;
    string SlotItemName;
    bool IsTaskItemDone;
    int TaskNumber;
    Time TaskTime;
    public Tasks(int SlotNumber,string SlotItemName,bool IsTaskItemDone,int TaskNumber,Time TaskTime)
    {
        this.SlotNumber = SlotNumber;
        this.SlotItemName = SlotItemName;
        this.IsTaskItemDone = IsTaskItemDone;
        this.TaskNumber = TaskNumber;
       
    }

}
