using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class idtask : MonoBehaviour
{
    public int ID = -1;
    public float Difficulty = 0f;
    private int times = 0;
    [SerializeField] private bool isActive = true;

    public bool _isActive
    {
        get
        {
            return isActive;
        }
        set
        {
            isActive = value;
            
        }
    }

    private void Update()
    {
        if (isActive == true)
        {
            Image image = GetComponent<Image>();
            var tempColor = image.color;
            tempColor.a = 1f;
            image.color = tempColor;
        }
        else
        {
            Image image = GetComponent<Image>();
            var tempColor = image.color;
            tempColor.a = 0.5f;
            image.color = tempColor;
        }
    }
}
