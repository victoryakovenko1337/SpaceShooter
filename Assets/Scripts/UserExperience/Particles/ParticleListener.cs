using UnityEngine;
using UnityEngine.Events;

public abstract class ParticleListener : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;
    private UnityEvent _eventToListen;

    private void Start() 
    {        
        Initialize();
        _eventToListen.AddListener(PlayParticle);
    }

    private void OnDestroy() 
    {
        _eventToListen.RemoveListener(PlayParticle);
    }

    public abstract void Initialize();

    public void SetEvent(UnityEvent unityEvent)
    {
        _eventToListen = unityEvent;
    }

    private void PlayParticle()
    {
        ParticleSystem particle = Instantiate(_particle, transform.position, transform.rotation);
        particle.Play();
        Destroy(particle.gameObject, particle.main.duration + particle.main.startLifetime.constantMax);
    }
}
