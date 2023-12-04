using System.Collections;
using UnityEngine;

public class RandomSpawner : Spawner
{
    private Vector2 _spawnPoint;

    private void Start() 
    {            
        StartCoroutine(Spawn());
    }

    public override IEnumerator Spawn()
    {
        var player = FindObjectOfType<Player>();
        while (player.IsAlive)
        {
            yield return new WaitForSeconds(GetRandomSpawnRate());
            _spawnPoint = new Vector2(Random.Range(-4, 5), 8.5f);
            Instantiate(GetRandomObject(), _spawnPoint, Quaternion.identity);
        }
    }
}
