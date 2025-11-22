using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Objectpool : MonoBehaviour
{
    public List<GameObject> enemies;
    private ObjectPool<GameObject> pool;


    void Start()
    {
        pool = new ObjectPool<GameObject>(createFunc: () => Instantiate(enemies[Random.Range(0, enemies.Count)]),
            actionOnGet: obj => obj.SetActive(true),
            actionOnRelease: obj => obj.SetActive(false),
            actionOnDestroy: obj => Destroy(obj.gameObject),
            collectionCheck:true, defaultCapacity:100,
            maxSize:1000);
    }

    public GameObject GetObject(Vector3 position, Quaternion rotation)
    {
        var obj = pool.Get();
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        return obj;
    }

    public void ReleaseObject(GameObject obj)
    {
        pool.Release(obj);
    }
    
    
    
}