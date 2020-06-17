using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private AudioSource fireballTrigger;

    private void Start()
    {
        fireballTrigger = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "fireball")
        {
            fireballTrigger.Play();
        }
    }
}
