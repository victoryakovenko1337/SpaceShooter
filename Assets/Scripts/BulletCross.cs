using System.Collections;
using UnityEngine;

public class BulletCross : Bullet
{
    [SerializeField, Min(0)] private int _countOfBullets = 4;
    [SerializeField, Min(0)] private float _secondsVariance;
    [SerializeField] private Bullet _bullet;

    private IEnumerator Start()
    {
        float seconds = Random.Range(LifetimeSeconds - _secondsVariance, LifetimeSeconds + _secondsVariance);
        
        yield return new WaitForSeconds(seconds);
        
        for (int i = 0; i < _countOfBullets; i++)
        {
            int angle = i * 360 / _countOfBullets;
            
            Bullet bullet = Instantiate(_bullet, transform.position, Quaternion.Euler(0,0, transform.localEulerAngles.z + angle));
            bullet.Initialize(Owner);
        }

        Destroy(gameObject);
    }
}
