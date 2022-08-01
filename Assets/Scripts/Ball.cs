using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector3 initialPos;
    Rigidbody rb; 
    void Start()
    {
        initialPos = transform.position;
        rb = GetComponent<Rigidbody>(); 
    }

    private void Update()
    {
        if(rb.velocity.x == 0)
        {
            transform.position = initialPos;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("wall"))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero; 
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            //transform.position = initialPos; 
        }
    }

}
