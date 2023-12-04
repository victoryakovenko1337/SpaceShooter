using System;
using UnityEngine;

public class MoveStraight : MonoBehaviour
{    
    public enum Direction
    {
        up = 1,
        down = -1
    }

    [SerializeField] private float _moveSpeed;
    [SerializeField] private Direction _direction;
    private Vector3 _moveDirection;

    public void SetMoveSpeed(float movespeed)
    {
        if (movespeed < 0) 
            throw new ArgumentOutOfRangeException();

        _moveSpeed = movespeed;
    }

    public void SetDirection(Direction direction)
    {
        _direction = direction;
    }

    private void Start()
    {
        _moveDirection = transform.up * (int)_direction;
    }

    private void Update()
    {
        Move();
    }
    
    private void Move()
    {
        transform.position += _moveDirection * _moveSpeed * Time.deltaTime;
    }   
}
