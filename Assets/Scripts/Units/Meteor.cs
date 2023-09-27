using UnityEngine;

public class Meteor : Unit
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            player.ApplyDamage(Damage);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        Move();
    }

    private void Awake()
    {
        Initialize();
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -180));
        gameObject.AddComponent<FallingItemDestroyer>();
    }

    private void Move()
    {
        transform.position += transform.up * MoveSpeed * Time.deltaTime;
    }
}
