using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idtask : MonoBehaviour
{
    public int ID = -1;

    private bool isActive = false;

    public bool _isActive
    {
        get
        {
            return isActive;
        }
        set
        {
            isActive = value;
            transform.parent.GetComponent<TheTask>().CheckForCompletion();
        }
    }
}
