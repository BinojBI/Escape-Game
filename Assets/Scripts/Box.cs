using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public float yAmount = 5f;
    private Player player;
    private Animator anim;

    void Start()
    {
        player = GameObject.FindWithTag("Respawn").GetComponent<Player>();
        anim = GetComponent<Animator>();

    }
    private void Update()
    {
        if (!player.died)
        {
            transform.position -= new Vector3(0, 0, GameMgr.movementSpeed * Time.deltaTime);
            transform.Rotate(0, yAmount, 0, Space.Self);
        }
        
    }

 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Destroyer")
        {
            gameObject.SetActive(false);
        }

        IEnumerator wait()
        {
            yield return new WaitForSeconds(0.5f);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            gameObject.SetActive(false);
        }
    }
}
