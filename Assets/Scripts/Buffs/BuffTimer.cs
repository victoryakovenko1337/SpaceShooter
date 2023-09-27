using System;
using UnityEngine;

public class BuffTimer : MonoBehaviour 
{
    public static BuffTimer Instance
    {
        get
        {
            var go = new GameObject("[TIMER]");
            var timer = go.AddComponent<BuffTimer>();

            return timer;
        }
    }

    public Action OnCompleted;

    private Timer _timer;
    private float _targetTime;

    public void SetTargetTime(float targetTime)
    {
        if (targetTime > 0)
            _targetTime = targetTime;
        else 
            throw new ArgumentOutOfRangeException();
    }

    private void Start()
    {
        _timer = new Timer();
    }

    private void Update()
    {
        _timer.UpdateTimer();
        
        if (_timer.CurrentTime >= _targetTime)
            StopCount();
    }

    private void StopCount()
    {
        OnCompleted?.Invoke();
        Destroy(gameObject);
    }
}