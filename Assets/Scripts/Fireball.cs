using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Fireball : MonoBehaviour
{

    public GameObject roadSpawners;
    public float movementSpeed = 5f;
    RoadObjectPooler objectPooler;
    private Player player;

    private void Start()
    {
        objectPooler = RoadObjectPooler.Instance;
        player = GameObject.FindWithTag("Respawn").GetComponent<Player>();

    }
    // Update is called once per frame
    public void Update()
    {

        transform.position -= new Vector3(0, movementSpeed * Time.deltaTime,  0);

        if (player.died)
        {
            movementSpeed = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Floor")
        {

            CameraShaker.Instance.ShakeOnce(1f, 8f, .1f, .5f);
            //roadSpawners.GetComponent<RoadSpawners>().spawnBox(transform.position);
            //spawnFromPool(string tag, Vector3 position);
            float randomSpawner = Random.Range(0,50f);

            if (randomSpawner<5f)
            {
                objectPooler.spawnFromPool("health", transform.position, transform.rotation);
            }
            else if(randomSpawner < 15f && randomSpawner >= 11f)
            {
                objectPooler.spawnFromPool("sheild", new Vector3(transform.position.x, 0.5f, transform.position.z), Quaternion.Euler(180, 0, 0));
            }
            else
            {
                objectPooler.spawnFromPool("enemy", new Vector3(transform.position.x, 0.2f, transform.position.z), Quaternion.Euler(0, 220, 0));
            }

            gameObject.SetActive(false);

        }
    }

}
