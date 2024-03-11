using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool isPaused;
    public event Action OnMinutePassed, OnSecondPassed;
    public void MinutePassed() => OnMinutePassed?.Invoke();
    public void SecondPassed() => OnSecondPassed?.Invoke();
    public int minute, second;

    float _time;
    private void Update()
    {
        if (isPaused) return;
        _time += Time.deltaTime;
        print(_time);
        if (_time < 1) return;
        _time = 0;
        second++;
        SecondPassed();

        if (second < 60) return;
        second = 0;
        minute++;
        MinutePassed();
    }
}
