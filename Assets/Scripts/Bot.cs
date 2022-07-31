using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    public float speed;
    Animator animator;
    public Transform ball; 
    public Transform hitTarget;

    float force = 13; 

    Vector3 targetPosition; 
    void Start()
    {
        targetPosition = transform.position;
        animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Move(); 
    }

    public void Move()
    {
        targetPosition.z = ball.position.z;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    { 
        if (other.CompareTag("Ball"))
        {
            Vector3 dir = hitTarget.position - transform.position;
            other.GetComponent<Rigidbody>().velocity = dir.normalized * force + new Vector3(0,8,0);

            Vector3 ballDir = ball.position - transform.position;
            if(ballDir.x >= 0)
            {
            animator.Play("Forehand");
            }
            else
            {
            animator.Play("Backhand");
            }
        }
    }
}
