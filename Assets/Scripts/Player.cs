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

    ShotManager shotManager;
    Shot currentShot; 

    void Start()
    {
        animator = GetComponent<Animator>();
        aimTargetInitialPosition = aimTarget.position;
        shotManager = GetComponent<ShotManager>();
        currentShot = shotManager.topspin; 
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButtonDown(0))
        {
            hitting = true;
            currentShot = shotManager.topspin; 
            //trail renderer to be green
        }
        else if (Input.GetMouseButtonUp(0))
        {
            hitting = false; 
        }


        if (Input.GetMouseButtonDown(1))
        {
            hitting = true;
            currentShot = shotManager.flat;
            //trail renderer to be red
        }
        else if (Input.GetMouseButtonUp(1))
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


        //Vector3 ballDir = ball.position - transform.position;
        //if (ballDir.z >= 0)
        //{
        //    Debug.Log("forehand");
        //}
        //else
        //{
        //    Debug.Log("backhand");
        //}
        //Debug.DrawRay(transform.position, ballDir); 
    }


    private void OnTriggerEnter(Collider other)
    { 
        if (other.CompareTag("Ball"))
        {
            Debug.Log("detect"); 
            Vector3 dir = aimTarget.position - transform.position;
            other.GetComponent<Rigidbody>().velocity = dir.normalized * currentShot.hitforce + new Vector3(0,currentShot.upforce,0);

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
