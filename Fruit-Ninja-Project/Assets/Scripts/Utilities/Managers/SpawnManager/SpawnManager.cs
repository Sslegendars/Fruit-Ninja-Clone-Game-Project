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

    public float minAngle = -10f;
    public float maxAngle = 10f;
    
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
        Instantiate(RandomPrefab(), RandomSpawnPosition(), RandomSpawnRotation());
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
    private Vector3 RandomSpawnPosition()
    {
        Vector3 randomSpawnPosition = new Vector3
        {
            x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
            y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y),
            z = Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z)
        };
        return randomSpawnPosition;
    }
    private Quaternion RandomSpawnRotation()
    {
        Quaternion randomRotation = Quaternion.Euler(0, 0, Random.Range(minAngle, maxAngle));       
        return randomRotation;
    }
    /*public float RandomAngle()
    {
        float randomRotation = Random.Range(minAngle, maxAngle);        
>>>>>>> Stashed changes
        return randomRotation;
    }*/
    private float RandomSpawnDelay()
    {
        float randomSpawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
        return randomSpawnDelay;
    }
}


