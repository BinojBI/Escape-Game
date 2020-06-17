using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private float upforce = 0.05f;
    private float slideforce = 0.1f;
    public void Update()
    {
        transform.position += new Vector3(0, 0, 10f * Time.deltaTime);
    }


}
