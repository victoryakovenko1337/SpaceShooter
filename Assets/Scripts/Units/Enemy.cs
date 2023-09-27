using UnityEngine;

public class Enemy : Unit
{
    private Transform _path;
    private int _currentWaypointIndex = 0;

    private void Awake()
    {
        Initialize();
        _path = FindObjectOfType<EnemySpawner>().CurrentPath;
        transform.position = _path.GetChild(0).position;
    }

    public virtual void Move()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        if (_currentWaypointIndex < _path.childCount)
        {
            MoveToPoint();
            ChangeWaypoint();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void MoveToPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, _path.GetChild(_currentWaypointIndex).position, MoveSpeed * Time.deltaTime);
    }

    private void ChangeWaypoint()
    {
        if (transform.position == _path.GetChild(_currentWaypointIndex).position)
            _currentWaypointIndex++;
    }

    private void Update()
    {
        Move();
    }    
}