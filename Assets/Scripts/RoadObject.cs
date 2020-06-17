using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadObject : MonoBehaviour
{
    public string name;
    private Player player;
    private float positionZ, positionY, positionX;

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

            transform.position = SpawningPositon();
        }
    }

    public Vector3 SpawningPositon()
    {
        positionY = transform.position.y;
        positionZ = 90.0f;
       

        if (name == "LightHolder" || name == "ThreeBlock")
        {
            positionX = transform.position.x;


        }
        else if (name == "TwoBlock")
        {
            float positionXpoint = Random.Range(0, 2);//70-90

            if (positionXpoint == 0)
            {
                positionX = 0.0f;
            }
            else
            {
                positionX = -0.806f;
            }


        }else if (name == "OneBlock")
        {
            float positionXpoint = Random.Range(0, 3);//70-90

            if (positionXpoint == 0)
            {
                positionX = -0.82f;
            }
            else if(positionXpoint == 0)
            {
                positionX = 0.0f;
            }
            else
            {
                positionX = 0.82f;
            }
        }


        return new Vector3(positionX, positionY, positionZ);

    }


}
