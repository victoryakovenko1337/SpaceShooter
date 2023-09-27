using UnityEngine;
using UnityEngine.UI;

public class HeatlhDisplay : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    Player _player;

    private void Start() 
    {
        _player = FindObjectOfType<Player>();        
        Initialize();
        _player.OnHealthChanged.AddListener(SetHpBar);
    }

    private void OnDestroy() 
    {
        _player.OnHealthChanged.RemoveListener(SetHpBar);
    }

    private void SetHpBar(int amount)
    {
        _slider.value += amount;
    }

    private void Initialize()
    {
        _slider.maxValue = _player.MaxHp;
        _slider.value = _player.MaxHp;
    }
}
