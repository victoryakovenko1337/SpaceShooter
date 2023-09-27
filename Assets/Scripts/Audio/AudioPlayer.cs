using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public static AudioPlayer Instance;

    [SerializeField] private AudioSource _musicSource, _effectsSource;

    private void Awake() 
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }   
        else
        {
            Destroy(gameObject);
        } 
        ChangeEffectVolume(1f);
        ChangeMusicVolume(1f);
    }

    public void PlaySound(AudioClip clip) => _effectsSource.PlayOneShot(clip);

    public void ChangeMasterVolume(float value) => AudioListener.volume = value;

    public void ChangeEffectVolume(float value) => _effectsSource.volume = value;

    public void ChangeMusicVolume(float value) => _musicSource.volume = value;

    public float MasterVolume => AudioListener.volume;

    public float MusicVolume => _musicSource.volume;
    
    public float SFXVolume => _effectsSource.volume;
}
