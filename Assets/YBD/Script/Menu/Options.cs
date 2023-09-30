using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    public Canvas MenuCanvas;
    public Canvas OptionsCanvas;
    public void OptionCanvas()
    {
        OptionsCanvas.enabled = true;
        MenuCanvas.enabled= false;
        
    }
}
