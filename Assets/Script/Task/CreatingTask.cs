using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DentedPixel;

public class CreatingTask : MonoBehaviour
{
    public GameObject bar;
    public RawImage obj1;
    public RawImage obj2;
    public RawImage obj3;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        AnimateBar();
    }

    public void AnimateBar()
    {
        LeanTween.scaleX(bar, 1, time);
    }
}
