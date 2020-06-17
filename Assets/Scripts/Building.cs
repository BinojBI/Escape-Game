using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
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
}
