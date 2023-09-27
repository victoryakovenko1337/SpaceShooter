using System;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    public UnityEvent OnHit;

    [SerializeField, Range(1f, 3f)] private float _lifetimeSeconds = 2f;
    Unit _owner;

    public Unit Owner => _owner;
    public float LifetimeSeconds => _lifetimeSeconds; 

    private void Start()
    {
        Destroy(gameObject, _lifetimeSeconds);
    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.TryGetComponent(out Unit spaceObject))
        {
            if (spaceObject.GetType() != _owner.GetType())
            {
                spaceObject.ApplyDamage(_owner.Damage);
                if (spaceObject.Health > 0)
                    OnHit?.Invoke();
                Destroy(gameObject);
            }
        }        
    }

    public bool IsEnemyOwner => _owner.GetType() != typeof(Player); 
    public void Initialize(Unit owner) => _owner = owner;
}
