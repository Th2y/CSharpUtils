using System;
using UnityEngine;

public class SessionController : MonoBehaviour
{
    private DateTime _startTime;

    public static SessionController Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        _startTime = DateTime.Now;
    }

    public string GetSessionDuration()
    {
        TimeSpan elapsedTime = DateTime.Now - _startTime;

        return string.Format("{0:00}:{1:00}:{2:00}", elapsedTime.Hours, elapsedTime.Minutes, elapsedTime.Seconds);
    }
}
