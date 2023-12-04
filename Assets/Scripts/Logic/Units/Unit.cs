using UnityEngine;
using UnityEngine.Events;


[DisallowMultipleComponent]
public abstract class Unit : MonoBehaviour, IDamagable
{    
    public UnityEvent OnDamageTakenEvent;
    public UnityEvent<int> OnHealthChanged;
    public UnityEvent OnDieEvent;

    [SerializeField, Min(0)] private float _moveSpeed;
    [SerializeField, Min(0)] private int _damage;
    [SerializeField, Min(0)] private int _maxHp;

    public virtual float MoveSpeed => _moveSpeed;
    public virtual int Damage => _damage;
    public int MaxHp => _maxHp;
    public int Health => _hp;    
    public bool IsAlive => _hp > 0;
    
    private int _hp;

    protected void Initialize()
    {
        _hp = MaxHp;
    }

    public void ApplyDamage(int amount)
    {
        if (amount < 0) return;

        OnDamageTakenEvent?.Invoke();
        ChangeHealth(-amount);
        if (IsAlive == false)
        {
            Die();   
            return; 
        }   
    }

    public void ChangeHealth(int amount)
    {
        _hp = Mathf.Clamp(_hp + amount, 0, MaxHp);
        OnHealthChanged?.Invoke(amount);
    }

    private void Die()
    {
        OnDieEvent?.Invoke();
        Destroy(gameObject);
    }
}
