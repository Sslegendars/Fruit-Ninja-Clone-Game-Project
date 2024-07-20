using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private Collider spawnArea;

    public GameObject[] fruitPrefabs;    

    public float minSpawnDelay = 0.25f;
    public float maxSpawnDelay = 1f;

    public float minAngle = -15f;
    public float maxAngle = 15f;

    


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
            
            SpawnFruitPrefab();           

            yield return new WaitForSeconds(RandomSpawnDelay());
        }
    }
    private void SpawnFruitPrefab()
    {
        Instantiate(RandomFruitPrefab(), RandomPosition(), RandomRotation());
    }
    private GameObject RandomFruitPrefab()
    {
        GameObject randomFruitPrefab = fruitPrefabs[Random.Range(0, fruitPrefabs.Length)];
        return randomFruitPrefab;
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
        Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(minAngle, maxAngle));
        return randomRotation;
    }
    private float RandomSpawnDelay()
    {
        float randomSpawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
        return randomSpawnDelay;
    }
}


