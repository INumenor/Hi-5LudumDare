using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timertext;
    [SerializeField] float remaningtime;
    void Update()
    {
        remaningtime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(remaningtime / 60);
        int seconds = Mathf.FloorToInt(remaningtime % 60);
        timertext.text = string.Format("{0:00}:{1:00}",minutes,seconds);

        if (remaningtime <= 0)
        {
            Debug.Log("Kazandık");
        }
    }
}
