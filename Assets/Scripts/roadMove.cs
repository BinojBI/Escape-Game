using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadMove : MonoBehaviour
{

    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Respawn").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!player.died)
        {
            transform.position -= new Vector3(0, 0, GameMgr.movementSpeed * Time.deltaTime);
        }
    }
        

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            transform.position = new Vector3(0,0,45f);
        }
    }
}
