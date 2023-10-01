using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSlot : MonoBehaviour
{
    [SerializeField] bool isFull = false;

    public bool _isFull
    {
        get
        {
            return isFull;
        }
        set
        {
            isFull = value;
        }
    }
}
