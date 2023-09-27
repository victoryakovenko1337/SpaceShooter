using System;
using UnityEngine;

[Serializable]
public class SpawnableObject
{
    [SerializeField] private GameObject _prefab;
    [SerializeField, Min(1)] private int _prefabWeight;

    public GameObject Prefab => _prefab;
    public int PrefabWeight => _prefabWeight;
}
