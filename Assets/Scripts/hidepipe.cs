using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hidepipe : MonoBehaviour
{
    public GameObject pipe;
    void Start()
    {
        
    }

   IEnumerator hide()
    {
        yield return new WaitForSeconds(1f);
        pipe.SetActive(false);
        yield return new WaitForSeconds(1f);
        StartCoroutine("show");
    }
    IEnumerator show()
    {
        pipe.SetActive(true);
        yield return new WaitForSeconds(0.1f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            StartCoroutine("hide");
        }
    }
    void Update()
    {
        
    }
}
