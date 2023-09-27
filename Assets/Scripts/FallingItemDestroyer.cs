using UnityEngine;

public class FallingItemDestroyer : MonoBehaviour
{
    private float _minY;

    private void Start() 
    {
        _minY = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y;
    }

    private void Update()
    {
        if (transform.position.y <= _minY)
            Destroy(gameObject);
    }
}