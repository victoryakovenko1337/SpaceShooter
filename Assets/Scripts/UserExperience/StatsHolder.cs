using TMPro;
using UnityEngine;

public class StatsHolder: MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _timeText;

    private static string _time; 
    private static string _score;

    public static void SetTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        _time = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public static void SetScore(int score)
    {
        _score = score.ToString("000000000");
    }

    private void Start() 
    {
        _scoreText.text = $"Your score:\n{_score}";
        _timeText.text = $"Your time:\n{_time}";
    }
}
