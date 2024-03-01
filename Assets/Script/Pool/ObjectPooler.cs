using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public Brick prefab;
        public int size;
    }

    #region Singleton
    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public List<Pool> pools;
    public Dictionary<string, Queue<Brick>> poolDictionary;

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<Brick>>();

        foreach (Pool pool in pools)
        {
            Queue<Brick> objectPool = new Queue<Brick>();

            for (int i = 0; i < pool.size; i++)
            {
                Brick obj = Instantiate(pool.prefab,transform);
                obj.gameObject.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public Brick SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            //Debug.LogWarning("Pool with tag " + tag + " doesn't exist.");
            return null;
        }

        Brick objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.gameObject.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
    public void DespawnBrickPool()
    {
        if (ObjectPooler.Instance.poolDictionary.TryGetValue("brick", out Queue<Brick> poolQueue))
        {
            foreach (Brick brick in poolQueue)
            {
                brick.gameObject.SetActive(false);
                brick.gameObject.transform.SetParent(transform);
            }
        }
    }
}
