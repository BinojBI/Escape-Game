using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private Player player;

    void Start()
    {
        player = GameObject.FindWithTag("Respawn").GetComponent<Player>();
    }
    private void Update()
    {
        if (!player.died)
        {
            transform.position -= new Vector3(0, 0, GameMgr.movementSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Destroyer")
        {
            Spawning();
        }
    }

    public void Spawning()
    {
        float positionZ = Random.Range(7f,22f);
        transform.position = new Vector3(transform.position.x, transform.position.y, positionZ);
    }
}
