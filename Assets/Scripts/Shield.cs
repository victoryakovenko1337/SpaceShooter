using UnityEngine;

public class Shield : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        bool hasBulletComponent = other.gameObject.TryGetComponent(out Bullet bullet);

        if (hasBulletComponent && bullet.IsEnemyOwner)
            Destroy(other.gameObject);
    }
}
