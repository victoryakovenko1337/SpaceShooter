using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeSlider : MonoBehaviour
{
    void Start()
    {
        AudioSlider musicSlider = new AudioSlider();
        Slider slider = GetComponent<Slider>();
        musicSlider.Initialize(slider, AudioPlayer.Instance.MusicVolume, AudioPlayer.Instance.ChangeMusicVolume);
    }
}
