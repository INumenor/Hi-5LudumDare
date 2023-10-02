using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TaskItems : ScriptableObject
{
    public Sprite TaskSprite;
    public string Taskname;
    public int mindropChance;
    public int ID;
    public float Difficulty;
    public int maxdropChance;
    public TaskItems(string Taskname,int mindropChance,int maxdropChance)
    {
        this.Taskname = Taskname;
        this.mindropChance = mindropChance;
        this.maxdropChance = maxdropChance;
    }
}
