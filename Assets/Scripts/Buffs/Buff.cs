using UnityEngine;

public abstract class Buff: MonoBehaviour
{
    public abstract void ApplyBuff(Player player);

    private void Start()
    {
        gameObject.AddComponent<FallingItemDestroyer>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.TryGetComponent(out Player player))
        {
            ApplyBuff(player);
            Destroy(gameObject);
        }
    }
}
