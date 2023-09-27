using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _fireRateSeconds = 0.25f;
    private Transform _gun;
    [SerializeField] private Unit _owner;

    private void Start()
    {
        _gun = GetComponent<Transform>();
        Attack();
    }

    public void Attack()
    {         
        StartCoroutine(AttackRoutine());
    }

    public void SetOwner(Unit owner)
    {
        _owner = owner;
    }
    
    private IEnumerator AttackRoutine()
    {
        while (_owner.IsAlive)
        {
            Bullet bullet = Instantiate(_bullet, _gun.position, _gun.rotation);    
            bullet.Initialize(_owner); 

            yield return new WaitForSeconds(_fireRateSeconds);
        }
    }
}
