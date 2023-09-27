using UnityEngine;

public class ExplosionSound : MonoBehaviour
{
    [SerializeField] private AudioClip _explosionClip;

    private void Start()
    {
        Unit ship = GetComponent<Unit>();
        ship.OnDieEvent.AddListener(() => {            
            AudioPlayer.Instance.PlaySound(_explosionClip);
        });
    }
}
