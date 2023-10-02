using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TheTask : MonoBehaviour
{
    public int ID = 0;
    private void Start()
    {
        Text idNumber = transform.GetChild(0).GetComponent<Text>();
        idNumber.text = ID.ToString();
    }
}
