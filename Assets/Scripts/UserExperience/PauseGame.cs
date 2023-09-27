using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject _pauseCanvas;
    [SerializeField] private Button _menuButton;
    private bool _isPaused = false;

    private void Start() 
    {
        _menuButton.onClick.AddListener(() => { 
            Time.timeScale = 1.0f; 
        });
    }

    public void ToggleCanvas()
    {   
        _isPaused = !_isPaused;
        Time.timeScale = _isPaused ? 0.0f : 1.0f;
        _pauseCanvas.SetActive(_isPaused);
    }
}
