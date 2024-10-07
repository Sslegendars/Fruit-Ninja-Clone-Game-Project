using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SpawnManager : MonoSingleton<SpawnManager>
{
    public float prefabForceValue = 10f;
    public float prefabRotationSpeed;

    [SerializeField]
    private Collider[] spawnAreas;
    [SerializeField]
    private ObjectPool objectPool;
    [SerializeField]
    private float minSpawnDelay = 0.3f;
    [SerializeField]
    private float maxSpawnDelay = 1f;
    [SerializeField]
    private float minAngle = -30f;
    [SerializeField]
    private float maxAngle = 30f;
    [SerializeField]
    private float bombChance = 0.8f;

    public Quaternion prefabSpawnRotation;

    private readonly string[] fruitTags = { "CoconutFruit", "AppleFruit", "OrangeFruit", "PearFruit", "WatermelonFruit"};
    protected override void Awake()
    {
        base.Awake();
        objectPool = GameObject.Find("ObjectPool").GetComponent<ObjectPool>();
    }
    private float PrefabRandomRotationSpeed()
    {
        int randomIndex = Random.Range(0, 5);
        float prefabRotationSpeed;
        switch (randomIndex)
        {
            case 0:
                prefabRotationSpeed = 15f;
                break;
            case 1:
                prefabRotationSpeed = 30f;
                break;
            case 2:
                prefabRotationSpeed = -30f;
                break;
            case 3:
                prefabRotationSpeed = -15f;
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
        return Random.Range(minForce,maxForce);
    }
    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    private void OnDisable()
    {
        StopCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2f);

        while (enabled)
        {
            SpawnPrefab();
            float delay = RandomSpawnDelay();
            yield return new WaitForSeconds(delay);
        }
    }

    private void SpawnPrefab()
    {
        string selectedTag = RandomPrefabWithTag();       
        Quaternion selectedSpawnRotation = RandomSpawnRotation();
        prefabRotationSpeed = PrefabRandomRotationSpeed();
        prefabForceValue = PrefabRandomForceValue();
        foreach (Collider spawnArea in spawnAreas)
        {
            Vector3 spawnPosition = RandomSpawnPosition(spawnArea);
            GameObject spawnedObject = objectPool.GetObject(selectedTag); 
            if(spawnedObject != null)
            {
                spawnedObject.transform.position = spawnPosition;
                spawnedObject.transform.rotation = selectedSpawnRotation;              

            }
        }
    }
    private string RandomPrefabWithTag()
    {
        if (Random.value < bombChance)
        {
            return "Bomb";
        }        
        int randomIndex = Random.Range(0, fruitTags.Length);
        return fruitTags[randomIndex]; 
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
        float randomZ = Random.Range(minAngle, maxAngle);
        return Quaternion.Euler(0, 0, randomZ);
    }

    private float RandomSpawnDelay()
    {
        return Random.Range(minSpawnDelay, maxSpawnDelay);
    }

}


