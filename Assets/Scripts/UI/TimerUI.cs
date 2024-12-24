using UnityEngine;
using TMPro;
using System;

public class TimerUI : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    
    float sec = 0;
    int min = 0;


    private void Update()
    {
        sec += Time.deltaTime;
        if (sec > 60f) { min += 1; sec = 0; }

        timeText.text = string.Format("{0:D2} : {1:D2}", min, (int)sec);
        
    }
}
