using UnityEngine;
using UnityEngine.UI;

public class SFXVolumeSlider : MonoBehaviour
{    
    private void Start()
    {
        AudioSlider SFXVolumeSlider = new AudioSlider();
        Slider slider = GetComponent<Slider>();   
        SFXVolumeSlider.Initialize(slider, AudioPlayer.Instance.SFXVolume, AudioPlayer.Instance.ChangeEffectVolume);    
    }
}
