using System.Collections;
using UnityEngine;

public class Boss : Enemy
{
    private float _minX;
    private float _maxX;
    private float _y;
    private Vector3 _direction;
   
    private void Awake() 
    {
        Initialize();
        _minX = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
        _maxX = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).x;
        _y = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).y;

        _direction = Vector3.right;

        Bounds _bounds = FindObjectOfType<Bounds>();  
        _minX += _bounds.PaddingSides * transform.localScale.x;
        _maxX -= _bounds.PaddingSides * transform.localScale.x;
        _y -= transform.localScale.y / 2;
        
        StartCoroutine(Appear());
    }

    public override void Move()
    {
        Vector3 delta = _direction * MoveSpeed * Time.deltaTime;

        float x = Mathf.Clamp(transform.position.x + delta.x, _minX, _maxX);
        transform.position = new Vector2(x, transform.position.y);
        if (transform.position.x == _maxX || transform.position.x == _minX)
            ChangeDirection();
    }

    private IEnumerator Appear()
    {
        while (transform.position.y != _y + Mathf.Epsilon)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, _y), MoveSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private void ChangeDirection()
    {
        _direction *= -1;
    }
}
