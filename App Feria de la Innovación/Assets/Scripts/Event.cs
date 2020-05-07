using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event : MonoBehaviour
{
    public Text timeLabel;
    public string startTime;
    double Tcounter;
    TimeSpan eventStarTime;
    TimeSpan currentTime;
    TimeSpan remainingTime;
    string TimeFormat;
    bool timerSet;
    bool countIsReady;
    public TimeManager timeManager;
    private void Start()
    {
        eventStarTime = TimeSpan.Parse(startTime);
        StartCoroutine("CheckTime");
        
    }
    public void RemainingDays()
    {
        if (countIsReady)
        {
            if (timeManager.remainingDays == 0)
            {
                startCountdown();
            }
            else
            {
                if (timeManager.remainingDays > 0)
                {
                    timeLabel.text = "La Feria de la Innovacción empieza en:\n" + timeManager.remainingDays + " días";
                }
                else if (timeManager.remainingDays >= -2)
                {
                    timeLabel.text = "La feria esta en curso";
                }
                else
                    timeLabel.text = "La feria terminó";
            }
        }
        else
        {
            if (timeManager.remainingDays >= -2)
            {
                timeLabel.text = "La feria esta en curso";
            }
            if (timeManager.remainingDays > 0)
            {
                timeLabel.text = "La Feria de la Innovacción empieza en:\n" + timeManager.remainingDays + " días";
            }
        }
    }
    private IEnumerator CheckTime()
    {
        yield return StartCoroutine(TimeManager.sharedInstance.getTime());
        updateTime();
    }
    void updateTime()
    {
        currentTime = TimeSpan.Parse(TimeManager.sharedInstance.getCurrentTimeNow());
        timerSet = true;
    }
    private void Update()
    {
        if(timerSet)
        {
            if(currentTime>=eventStarTime && timeManager.remainingDays >= -2 && timeManager.remainingDays <= 0)
            {
                timeLabel.text = "La feria esta en curso";
            }
            else if(currentTime<eventStarTime)
            {
                remainingTime = eventStarTime.Subtract(currentTime);
                Tcounter = remainingTime.TotalMilliseconds;
                countIsReady = true;
            }
        }
        RemainingDays();

    }
    public string GetRemainingTime(double x)
    {
        TimeSpan tempB = TimeSpan.FromMilliseconds(x);
        TimeFormat = string.Format("{0:00}:{1:00}:{2:00}", tempB.Hours, tempB.Minutes, tempB.Seconds);
        return TimeFormat;
    }
    void startCountdown()
    {
        timerSet = false;
        Tcounter-= Time.deltaTime * 1000;
        timeLabel.text = ("La Feria de la Innovación empieza en: " + GetRemainingTime(Tcounter));

        if(Tcounter<=0)
        {
            countIsReady = false;
            timeLabel.text = "La feria esta en curso";
            validateTime();
        }
    }
    void validateTime()
    {
        StartCoroutine("CheckTime");
    }
}
