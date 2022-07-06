using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sleepball : MonoBehaviour
{

    
    public Rigidbody rb;
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            StartCoroutine("freeze");

        }
    }
    void Update()
    {
        
    }
    IEnumerator freeze()
    {   
        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;
        yield return new WaitForSeconds(0.01f);
        StartCoroutine("unfreeze");
    }
    IEnumerator unfreeze()
    {   
        StopCoroutine("freeze");
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezePositionZ;
        yield return new WaitForSeconds(1f);
       
    }
}
