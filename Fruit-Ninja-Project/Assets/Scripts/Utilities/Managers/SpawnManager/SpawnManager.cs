using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoSingleton<SpawnManager>
{
    private Collider spawnArea;

    public GameObject[] fruitPrefabs;

    public GameObject bombPrefab;

    public float minSpawnDelay = 0.25f;
    public float maxSpawnDelay = 1f;

    public float minAngle = -15f;
    public float maxAngle = 15f;
    
    private const float bombChance = 0.05f;   
    private void Awake()
    {
        spawnArea = GetComponent<Collider>();
    }
    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }    
    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2f);

        while (enabled)
        {            
            SpawnPrefab();         
            yield return new WaitForSeconds(RandomSpawnDelay());
        }
    }
    private void SpawnPrefab()
    {
        Instantiate(RandomPrefab(), RandomPosition(), RandomRotation());
    }    
    private GameObject RandomPrefab()
    {
        GameObject randomPrefab = fruitPrefabs[Random.Range(0, fruitPrefabs.Length)];
        if (Random.value < bombChance)
        {
            randomPrefab = bombPrefab;            
        }
        return randomPrefab;
    }    
    private Vector3 RandomPosition()
    {
        Vector3 randomPosition = new Vector3
        {
            x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
            y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y),
            z = Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z)
        };
        return randomPosition;
    }
    private Quaternion RandomRotation()
    {
        Quaternion randomRotation = Quaternion.Euler(0, 0, Random.Range(minAngle, maxAngle));
        return randomRotation;
    }
    private float RandomSpawnDelay()
    {
        float randomSpawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
        return randomSpawnDelay;
    }
}


