using System;
using UnityEngine;

public class Timer
{
    public Action OnOneSecondLeft;

    private float _currentTime;
    private float _oneSecTimer;
    private bool _isEnabled;

    public float CurrentTime => _currentTime;

    public Timer()
    {
        _currentTime = 0;
        _isEnabled = true;
    }

    public void UpdateTimer()
    {
        if (_isEnabled)
        {
            _currentTime += Time.deltaTime;
            CountOneSecond();
        }
    }

    public void Stop() => _isEnabled = false;

    private void CountOneSecond()
    {
        _oneSecTimer += Time.deltaTime;
        if (_oneSecTimer >= 1f)
        {
            _oneSecTimer -= 1;
            OnOneSecondLeft?.Invoke();
        }
    }
}