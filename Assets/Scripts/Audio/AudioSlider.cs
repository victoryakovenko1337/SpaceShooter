using System;
using UnityEngine.UI;

public class AudioSlider
{
    private Action<float> _changeValueCallback;

    public void Initialize(Slider slider, float volume, Action<float> changeVolumeFunction)
    {
        _changeValueCallback = changeVolumeFunction;
        slider.value = volume;
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float value)
    {
        _changeValueCallback.Invoke(value);
    }
}