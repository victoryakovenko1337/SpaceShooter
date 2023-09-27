using System;

public class ScoreCounter: Counter
{
    public event Action OnBossSpawn;

    private static int _pointsToSpawnBoss = 5000;
    private int _bossScore;

    public override void AddPoints(int amount)
    {
        base.AddPoints(amount);
        _bossScore += amount;
        if (_bossScore >= _pointsToSpawnBoss)
        {
            _bossScore -= _pointsToSpawnBoss;
            OnBossSpawn?.Invoke();
        }
    }

    public override void ResetScore()
    {
        base.ResetScore();
        _bossScore = 0;
    }
}