using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Building")
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "SpawningBuildings")
        {
            other.gameObject.SetActive(false);
        }
    }
}
