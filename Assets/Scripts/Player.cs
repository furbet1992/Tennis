using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform aimTarget; 
    public float speed;
    public float force;
    public float ballHeight; 

    bool hitting;
    public Transform ball; 
    Animator animator;

    Vector3 aimTargetInitialPosition; 

    void Start()
    {
        animator = GetComponent<Animator>();
        aimTargetInitialPosition = aimTarget.position; 
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.F))
        {
            hitting = true; 
        }else if (Input.GetKeyUp(KeyCode.F))
        {
            hitting = false; 
        }

        if (hitting)
        {
            aimTarget.Translate(new Vector3(h, 0, 0) * speed * Time.deltaTime); 
        }

            if ((h != 0 || v != 0) && !hitting)
        {
            transform.Translate(new Vector3(h, 0, v) * speed * Time.deltaTime);
        }


        Vector3 ballDir = ball.position - transform.position;
        if (ballDir.z >= 0)
        {
            Debug.Log("forehand");
        }
        else
        {
            Debug.Log("backhand");
        }
        Debug.DrawRay(transform.position, ballDir); 
    }


    private void OnTriggerEnter(Collider other)
    { 
        if (other.CompareTag("Ball"))
        {
            Debug.Log("detect"); 
            Vector3 dir = aimTarget.position - transform.position;
            other.GetComponent<Rigidbody>().velocity = dir.normalized * force *2  + new Vector3(0,ballHeight,0);

            Vector3 ballDir = ball.position - transform.position;
            if(ballDir.z >= 0)
            {
            animator.Play("Forehand");
            }
            else
            {
            animator.Play("Backhand");
            }
            aimTarget.position = aimTargetInitialPosition; 
        }
    }
}
