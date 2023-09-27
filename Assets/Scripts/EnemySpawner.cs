using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner: Spawner
{
    [SerializeField] private float _timeBetweenWaves;
    [SerializeField, Range(0, 100)] private int _minWaveEnemies;
    [SerializeField, Range(0, 100)] private int _maxWaveEnemies;
    [SerializeField] private Boss _bossPrefab;
    [SerializeField] private List<Transform> _paths;

    public Transform CurrentPath { get; private set; }
    private int _enemyCount;
    private Coroutine _spawnCoroutine;

    private void Start()
    {
        GetRandomPath();
        GetRandomEnemyCount();
        _spawnCoroutine = StartCoroutine(Spawn());
        ScoreCounter scoreKeeper = FindObjectOfType<ScoreView>().Counter;
        scoreKeeper.OnBossSpawn += SpawnBoss;
    }

    public override IEnumerator Spawn() 
    {
        var player = FindObjectOfType<Player>();
        
        while(player.IsAlive)
        {
            Transform pathStart = CurrentPath.GetChild(0);

            for (int i = 0; i < _enemyCount; ++i)
            {
                Enemy _enemyPrefab = GetRandomObject().GetComponent<Enemy>();
                Instantiate(_enemyPrefab, pathStart.position, Quaternion.identity, transform);            
                yield return new WaitForSeconds(GetRandomSpawnRate()); 
            }

            GetRandomPath();
            GetRandomEnemyCount();
            yield return new WaitForSeconds(_timeBetweenWaves);
        }
    }

    private void SpawnBoss()
    {
        StopCoroutine(_spawnCoroutine);
        Boss boss = Instantiate(_bossPrefab);
        boss.OnDieEvent.AddListener(() => { _spawnCoroutine = StartCoroutine(Spawn()); });
    }

    private void GetRandomPath()
    {   
        CurrentPath = _paths[UnityEngine.Random.Range(0, _paths.Count)];
    }

    private void GetRandomEnemyCount()
    {
        if (_minWaveEnemies < _maxWaveEnemies)
            _enemyCount = UnityEngine.Random.Range(_minWaveEnemies, _maxWaveEnemies);
        else 
            throw new ArgumentOutOfRangeException();
    }
}