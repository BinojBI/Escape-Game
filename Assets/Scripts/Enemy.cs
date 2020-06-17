using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Player player;
    private bool spelling = false;
    private float spellSpeed = 7f;
    RoadObjectPooler objectPooler;
    private AudioSource spellSound;

    void Start()
    {
        player = GameObject.FindWithTag("Respawn").GetComponent<Player>();
        objectPooler = RoadObjectPooler.Instance;
        spellSound = GetComponent<AudioSource>();

    }
    private void Update()
    {
        if (!player.died)
        {

            transform.position -= new Vector3(0, 0, GameMgr.movementSpeed * Time.deltaTime);

        }
        else
        {
            gameObject.SetActive(false);
        }

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Destroyer")
        {
            gameObject.SetActive(false);
        }
    }

    public void SpellEvent()
    {
        spellSound.Play();
        objectPooler.spawnFromPool("spell", new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z), Quaternion.Euler(90, 0, 0));
    }
}
