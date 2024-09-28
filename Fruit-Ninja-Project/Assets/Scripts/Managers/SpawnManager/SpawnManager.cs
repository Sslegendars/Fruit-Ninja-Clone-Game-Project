using System.Collections;
using UnityEngine;

public class SpawnManager : MonoSingleton<SpawnManager>
{
    public float forceValue;
    public float prefabRotationSpeed;

    [SerializeField]
    private Collider[] spawnAreas;
    [SerializeField]
    private GameObject[] fruitPrefabs;
    [SerializeField]
    private GameObject bombPrefab;
    [SerializeField]
    private float minSpawnDelay = 0.25f;
    [SerializeField]
    private float maxSpawnDelay = 1f;
    [SerializeField]
    private float minAngle = -10f;
    [SerializeField]
    private float maxAngle = 10f;
    [SerializeField]
    private float bombChance = 0.05f; 
    
    private float PrefabRandomRotationSpeed()
    {
        int randomIndex = Random.Range(0, 4);
        float prefabRotationSpeed = 0;
        switch (randomIndex)
        {
            case 0:
                prefabRotationSpeed = 25;
                break;
            case 1:
                prefabRotationSpeed = -50;
                break;
            case 2:
                prefabRotationSpeed = 50;
                break;
            default:
                prefabRotationSpeed = 0;
                break;
        }
        return prefabRotationSpeed;
    }
    private float PrefabRandomForceValue()
    {
        float minForce = 11f;
        float maxForce = 15f;
        float randomForceValue = Random.Range(minForce, maxForce);
        return randomForceValue;
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
        GameObject selectedPrefab = RandomPrefab();
        //Vector3 selectedSpawnPosition = RandomSpawnPosition(spawnAreas[0]).;       
        Quaternion selectedSpawnRotation = RandomSpawnRotation();
        prefabRotationSpeed = PrefabRandomRotationSpeed();
        forceValue = PrefabRandomForceValue();
        foreach (var spawnArea in spawnAreas)
        {
            //Vector3 spawnPosition = spawnArea.ClosestPoint(selectedSpawnPosition);
            Instantiate(selectedPrefab, RandomSpawnPosition(spawnArea), selectedSpawnRotation);
        }
        
        
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
    private Vector3 RandomSpawnPosition(Collider spawnArea)
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
    private float RandomSpawnDelay()
    {
        float randomSpawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
        return randomSpawnDelay;
    }
}


