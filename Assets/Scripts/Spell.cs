using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, 0, (GameMgr.movementSpeed+5f) * Time.deltaTime);
        //Debug.Log(GameMgr.movementSpeed + 5f);
    }
}
