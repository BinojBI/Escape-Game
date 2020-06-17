using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;
    private Player player;

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
        Invoke("spawnObject", 1f);
        player = GameObject.FindWithTag("Respawn").GetComponent<Player>();

    }

    public void spawnObject()
    {
        if (!player.died)
        {

  
        float num = Random.Range(1, 11);

        if (num == 1)
        {
            objectPooler.spawnFromPool("church", transform.position, Quaternion.identity);
        }
        else if(num == 2)
        {
            objectPooler.spawnFromPool("house8", transform.position, Quaternion.identity);
        }
        else if (num == 3)
        {
            objectPooler.spawnFromPool("house11", transform.position, Quaternion.Euler(0, 90, 0));
        }
        else if (num == 4)
        {
            objectPooler.spawnFromPool("shop1", transform.position, Quaternion.identity);
        }
        else if (num == 5)
        {
            objectPooler.spawnFromPool("shop2", transform.position, Quaternion.Euler(0, 90, 0));
        }
        else if (num == 6)
        {
            objectPooler.spawnFromPool("station1", transform.position, Quaternion.Euler(0,90,0));
        }
        else if (num == 7)
        {
            objectPooler.spawnFromPool("station2", transform.position, Quaternion.identity);
        }
        else if (num == 8)
        {
            objectPooler.spawnFromPool("officeOctagon", transform.position, Quaternion.identity);
        }
        else if(num == 9)
        {
            objectPooler.spawnFromPool("apartment1", transform.position, Quaternion.Euler(0, -90, 0));
        }
        else
        {
            objectPooler.spawnFromPool("apartment4", transform.position, Quaternion.identity);
        }

        }

        if (GameMgr.movementSpeed< 8f)
        {
            Invoke("spawnObject", 1f);
        }
        else if(GameMgr.movementSpeed > 8f && GameMgr.movementSpeed < 10f )
        {
            Invoke("spawnObject", .9f);
        }
        else if (GameMgr.movementSpeed >= 10f && GameMgr.movementSpeed < 12f)
        {
            Invoke("spawnObject", .75f);
        }
        else if (GameMgr.movementSpeed >= 12f && GameMgr.movementSpeed < 16f)
        {
            Invoke("spawnObject", .6f);
        }
        else
        {
            Invoke("spawnObject", .5f);
        }
        
    }
}
