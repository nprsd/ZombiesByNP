using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class TimeCounter : MonoBehaviour
 {

    public Text timerText;
    public Text timeS;
    private static float secondsCount;
    private static int minuteCount;
    private static int hourCount;

    void Update()
    {
        StartCoroutine(UpdateTimerUI());
    }
    
    IEnumerator UpdateTimerUI()
    {
        
        secondsCount += Time.deltaTime;
        
        if (secondsCount >= 60)
        {
            minuteCount++;
            secondsCount = 0;
        }
        else if (minuteCount >= 60)
        {
            hourCount++;
            minuteCount = 0;
        }

        yield return new WaitForSeconds(0.01f);
    }
}

