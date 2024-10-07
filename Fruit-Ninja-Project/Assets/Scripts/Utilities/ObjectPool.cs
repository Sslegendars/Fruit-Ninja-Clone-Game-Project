using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag; 
        public GameObject prefab; 
        public int size; 
    }

    public List<Pool> pools; 
    private Dictionary<string, Queue<GameObject>> poolDictionary; 

    private void Awake()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (var pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false); 
                obj.transform.SetParent(transform); 
                objectPool.Enqueue(obj); 
            }
            poolDictionary.Add(pool.tag, objectPool); 
        }        
        DontDestroyOnLoad(gameObject);
    }    
    public GameObject GetObject(string tag)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("There is no such tag in the pool: " + tag);
            return null;
        }
        GameObject objectToSpawn = poolDictionary[tag].Dequeue(); 
        if(objectToSpawn.activeSelf == false)
        {
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.SetParent(transform);
            poolDictionary[tag].Enqueue(objectToSpawn);
            return objectToSpawn;
        }
        else
        {
            GameObject newObject = Instantiate(objectToSpawn);
            newObject.SetActive(true);
            newObject.transform.SetParent(transform);
            poolDictionary[tag].Enqueue(newObject);
            return newObject;
        }
        
        
    }
}
