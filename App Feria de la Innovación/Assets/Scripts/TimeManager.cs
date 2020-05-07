using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager sharedInstance = null;
    private string _url = "http://leatonm.net/wp-content/uploads/2017/candlepin/getdate.php"; //change this to your own
    private string _timeData;
    private string _currentTime;
    private string _currentDate;
    public int remainingDays=0;
    public int EventDay = 30;
    public int EndEvent = 32;
    public Event _event;
    void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else if (sharedInstance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public IEnumerator getTime()
    {
        Debug.Log("connecting to php");
        WWW www = new WWW(_url);
        yield return www;
        if (www.error != null)
        {
            Debug.Log("Error");
        }
        else
        {
            Debug.Log("got the php information");
        }
        _timeData = www.text;
        string[] words = _timeData.Split('/');

        string[] currentDay = _timeData.Split('-');
        remainingDays = EventDay- System.Convert.ToInt32(currentDay[1]);
        _event.RemainingDays();
        Debug.Log("The date is : " + words[0]);
        Debug.Log("The time is : " + words[1]);

        _currentDate = words[0];
        _currentTime = words[1];
    }

    void Start()
    {
        StartCoroutine("getTime");
    }
    //get the current date - also converting from string to int.
    //where 12-4-2017 is 1242017
    public int getCurrentDateNow()
    {
        string[] words = _currentDate.Split('-');
        int x = int.Parse(words[0] + words[1] + words[2]);
        return x;
    }
    public string getCurrentTimeNow()
    {
        return _currentTime;
    }
}

