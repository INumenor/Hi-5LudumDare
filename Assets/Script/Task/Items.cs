using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class Items : ScriptableObject
{
    public string itemname;
    public int minvalue;
    public int maxvalue;
    public Texture Image;
}
