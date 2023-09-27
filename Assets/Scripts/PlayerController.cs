using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _controllableObject;
    private Player _player;
    
    private Vector2 _rawInput;
    private Bounds _bounds;

    private void Start() 
    {
        _player = _controllableObject.GetComponent<Player>();
        
        if (_player == null)
            throw new NullReferenceException();

        _player.OnDieEvent.AddListener(() => {
            Destroy(gameObject);
        });
        
        _bounds = FindObjectOfType<Bounds>();    
    }

    public void Move()
    {
        Vector3 delta = _rawInput * _player.MoveSpeed * Time.deltaTime; 
  
        _player.transform.position = _bounds.CalculateBounds(_player.transform.position, delta);
    }

    private void Update()
    {
        Move();
    }

    private void OnMove(InputValue value)
    {
        _rawInput = value.Get<Vector2>();
    }
}