using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class SurvivalTimer : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private Timer _timer;

    private void Start()
    {
        _timer = new Timer();
        _text = GetComponent<TextMeshProUGUI>();
        ShowTime();
        FindObjectOfType<Player>().OnDieEvent.AddListener(() => {
            _timer.Stop();
            StatsHolder.SetTime(_timer.CurrentTime);
        });
        _timer.OnOneSecondLeft += ShowTime;
    }

    private void OnDestroy() 
    {
        _timer.OnOneSecondLeft -= ShowTime;
    }

    private void Update() 
    {
        _timer.UpdateTimer();
    }

    private void ShowTime()
    {
        int minutes = Mathf.FloorToInt(_timer.CurrentTime / 60);
        int seconds = Mathf.FloorToInt(_timer.CurrentTime % 60);
        _text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}