using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreView: MonoBehaviour
{   
    public ScoreCounter Counter => _counter;

    private TextMeshProUGUI _text;
    private ScoreCounter _counter;

    private void Awake()
    {
        Keeper<ScoreCounter> _scoreKeeper = new Keeper<ScoreCounter>();
        _counter = _scoreKeeper.Counter;
        _text = GetComponent<TextMeshProUGUI>();
        Show();
        _scoreKeeper.Counter.OnScoreChangedEvent += Show;
    }

    private void OnDestroy() 
    {
        _counter.OnScoreChangedEvent -= Show;
        StatsHolder.SetScore(_counter.TotalScore);
    }

    private void Show()
    {
        _text.text = _counter.TotalScore.ToString("000000000");
    }
}