using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    public Canvas MenuCanvas;
    public Canvas OptionsCanvas;
    public void ButtonBack()
    {
        MenuCanvas.enabled = true;
        OptionsCanvas.enabled = false;
        

    }
}
