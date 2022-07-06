using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballmanager : MonoBehaviour
{
    public Rigidbody rb;
    Transform playerBallTransform;
    void Start()
    {
        playerBallTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    IEnumerator stopball()
    {
        playerBallTransform.position = new Vector3(-24.9f, -15.2f, -1);
        
        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;
        yield return new WaitForSeconds(0.01f);
        StartCoroutine("letitgo");
    }
    IEnumerator letitgo()
    {
        StopCoroutine("stopball");
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezePositionZ;
        yield return new WaitForSeconds(0.01f);
    }

    void Update()
    {
        if(playerBallTransform.position.y < -40)
        {
            StartCoroutine("stopball");
        }
    }

}
