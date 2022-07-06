using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    Transform playerBallTransform;
    public Transform target;

    private Vector3 velocity = Vector3.zero;
    void Start()
    {
        playerBallTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = playerBallTransform.position + new Vector3(28.4f, 15.2f, -39f);
    }
}
