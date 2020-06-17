using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpawner : MonoBehaviour
{
    private float zspowning, xspawning;
    private GameObject fireball;
    public float[] xPositions;
    RoadObjectPooler objectPooler;
    private void Start()
    {
        objectPooler = RoadObjectPooler.Instance;
        Invoke("spawnObject", 2f);
        fireball = GameObject.FindWithTag("fireball");

    }
  

    public void spawnObject()
    {
       
        int xspawning = Random.Range(0,xPositions.Length);
        float zspowning = Random.Range(7f, 12f);


        transform.position = new Vector3(xPositions[xspawning], 17f, zspowning);
        objectPooler.spawnFromPool("fireball", transform.position, transform.rotation);

        float spawningTime = Random.Range(0.5f,4f);
        Invoke("spawnObject", spawningTime);
    }
}
