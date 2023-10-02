using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TheTask : MonoBehaviour
{
    public int ID = 0;
    public TMP_Text idNumber;
    private void Start()
    {
        idNumber.GetComponent<TextMeshPro>().text = ID.ToString();
    }
}
