using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnRate;
    [SerializeField] private float _spawnRateVariance;
    [SerializeField] private List<SpawnableObject> _spawnableObjects;

    public float SpawnRate => _spawnRate;
    public float SpawnRateVariance => _spawnRateVariance;

    public abstract IEnumerator Spawn();

    public float GetRandomSpawnRate()
    {
        return Random.Range(SpawnRate - SpawnRateVariance, SpawnRate + SpawnRateVariance);
    }

    protected GameObject GetRandomObject()
    {
        var randomObject = new SpawnableObject();
        int weightSum = 0;
        foreach(var spawnableObject in _spawnableObjects)
        {
            weightSum += spawnableObject.PrefabWeight;
        }

        var random = Random.Range(0, weightSum);

        foreach(var spawnableObject in _spawnableObjects)
        {
            if (random < spawnableObject.PrefabWeight)
            {
                randomObject = spawnableObject;
                break;
            }
            random -= spawnableObject.PrefabWeight;
        }

        return randomObject.Prefab;
    }
}
