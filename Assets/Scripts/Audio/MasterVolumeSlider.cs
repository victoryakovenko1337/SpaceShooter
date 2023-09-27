using UnityEngine;
using UnityEngine.UI;

public class MasterVolumeSlider : MonoBehaviour
{
    private void Start() 
    {        
        AudioSlider masterSlider = new AudioSlider();
        Slider slider = GetComponent<Slider>();
        masterSlider.Initialize(slider, AudioPlayer.Instance.MasterVolume, AudioPlayer.Instance.ChangeMasterVolume);
    }
}
