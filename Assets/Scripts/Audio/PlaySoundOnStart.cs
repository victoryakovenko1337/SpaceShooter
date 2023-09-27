using UnityEngine;

public class PlaySoundOnStart : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;

    private void Start()
    {
        AudioPlayer.Instance.PlaySound(_clip);
    }
}
