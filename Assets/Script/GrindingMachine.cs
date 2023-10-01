using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;
using Unity.VisualScripting;

public class GrindingMachine : MonoBehaviour
{
    public bool isGrind = false;
    private float maxgrind = 100f;
    private float grind = 0f;
    public void Grind()
    {
        
    }


    public void FixedUpdate()
    {
        if (isGrind != false)
        {
           
            grind += 1* Time.deltaTime;
            Debug.Log(grind);
           
        }
    }
}
