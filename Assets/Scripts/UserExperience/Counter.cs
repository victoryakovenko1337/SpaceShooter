using System;

public class Counter
{    
    public event Action OnScoreChangedEvent;

    public int TotalScore => _totalScore;

    private int _totalScore;

    public Counter()
    {
        ResetScore();
    }

    public virtual void AddPoints(int amount = 1)
    {
        if (amount < 0) return;
        
        _totalScore += amount;
        OnScoreChangedEvent?.Invoke(); 
    }

    public virtual void ResetScore()
    {
        _totalScore = 0;
    }
}
