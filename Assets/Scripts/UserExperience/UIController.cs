using UnityEngine;

public class UIController : MonoBehaviour
{
    private PauseGame _pause;

    private void Awake()
    {
        _pause = FindObjectOfType<PauseGame>();
    }

    private void OnPause()
    {
        _pause.ToggleCanvas();
    }
}
