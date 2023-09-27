using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class KillsView: MonoBehaviour
{   
    public Counter Counter => _counter;

    private TextMeshProUGUI _text;
    private Counter _counter;

    private void Awake()
    {
        Keeper<Counter> _killsKeeper = new Keeper<Counter>();
        _counter = _killsKeeper.Counter;
        _text = GetComponent<TextMeshProUGUI>();
        Show();
        _killsKeeper.Counter.OnScoreChangedEvent += Show;
    }

    private void OnDestroy() 
    {
        _counter.OnScoreChangedEvent -= Show;
        StatsHolder.SetScore(_counter.TotalScore);
    }

    private void Show()
    {
        _text.text = $"Kills: {_counter.TotalScore}";
    }
}