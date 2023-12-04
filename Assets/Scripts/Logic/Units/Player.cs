using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Shooter))]
public class Player : Unit
{
    public override float MoveSpeed => _currentMoveSpeed;
    public override int Damage => _currentDamage;
    
    private float _currentMoveSpeed;
    private int _currentDamage;
    
    private void Awake()
    {
        Initialize();
        _currentMoveSpeed = base.MoveSpeed;
        _currentDamage = base.Damage;
    }

    public void ChangeSpeed(float multiplier)
    {
        _currentMoveSpeed *= multiplier;
        _currentMoveSpeed = Mathf.Max(base.MoveSpeed, _currentMoveSpeed);
    }

    public void ChangeDamage(int amount)
    {
        _currentDamage += amount;
        _currentDamage = Mathf.Max(base.Damage, _currentDamage);
    }

    public Shield AddShield(Shield shield)
    {
        if (shield == null) return null;

        return Instantiate(shield, transform);        
    }

    public void RemoveShield(Shield shield)
    {
        if (shield == null || gameObject == null) return;

        Destroy(shield.gameObject);
    }

    public List<Gun> AddGuns(List<Gun> guns)
    {
        if (guns == null) return null;

        var shooter = GetComponent<Shooter>();
        var _additionalGuns = new List<Gun>();

        foreach(var gun in guns)
        {
            Gun additionalGun = Instantiate(gun, transform);
            _additionalGuns.Add(additionalGun);
            shooter.AddGun(additionalGun);
        }

        return _additionalGuns;
    }

    public void RemoveGuns(List<Gun> guns)
    {
        if (guns == null || gameObject == null) return;

        var shooter = GetComponent<Shooter>();
        foreach(var gun in guns)
        {
            shooter.RemoveGun(gun);            
            Destroy(gun.gameObject);
        }
    }
}
