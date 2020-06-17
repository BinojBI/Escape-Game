using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooler : MonoBehaviour
{
    public GameObject pooledObject;
    public int pooledAmount;

    List<GameObject> pooledObjects;

    private void Start()
    {
        pooledObjects = new List<GameObject>();

        for (int x = 0; x < pooledAmount; x++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObjects()
    {
        for (int x = 0; x < pooledAmount; x++)
        {
            if (!pooledObjects[x].activeInHierarchy)
            {
                return pooledObjects[x];
            }


        }

        GameObject obj = (GameObject)Instantiate(pooledObject);
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;
    }
}
