using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawners : MonoBehaviour
{
    public BoxPooler boxPooler;
    public EnemyPooler enemyPooler;
    public void spawnBox(Vector3 firedposition)
    {
        GameObject newBox = boxPooler.GetPooledObjects();
        GameObject newEnemy = enemyPooler.GetPooledObjects();

        int spawnRandom = Random.Range(0, 5);
        if (spawnRandom == 0)
        {
            newBox.transform.position = new Vector3(firedposition.x, 0.5f, firedposition.z);
            newBox.SetActive(true);
        }
        else
        {
            newEnemy.transform.position = new Vector3(firedposition.x, 0.2f, firedposition.z);
            newEnemy.SetActive(true);
        }

        
    }
}
