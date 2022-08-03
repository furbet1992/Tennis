using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    public float speed;
    Animator animator;
    public Transform ball; 
    public Transform hitTarget;

    public Transform[] targets;

    Vector3 targetPosition;

    ShotManager shotManager;

    void Start()
    {
        targetPosition = transform.position;
        animator = GetComponent<Animator>();
        shotManager = GetComponent<ShotManager>();
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

    Vector3 PickTarget()
    {
        int randomValue = Random.Range(0, targets.Length);
        return targets[randomValue].position; 
    }

    Shot Pickshot()
    {
        int randomValue = Random.Range(0, 2);
        if (randomValue == 0)
            return shotManager.topspin;
        else 
            return shotManager.flat; 
    }


    private void OnTriggerEnter(Collider other)
    { 
        if (other.CompareTag("Ball"))
        {
            Shot currentShot = Pickshot(); 

            Vector3 dir = PickTarget() - transform.position; //get the direction to where to send the ball 
            other.GetComponent<Rigidbody>().velocity = dir.normalized * currentShot.hitforce + new Vector3(0, currentShot.upforce, 0);

            Vector3 ballDir = ball.position - transform.position;
            if(ballDir.x >= 0)
            {
            animator.Play("Forehand");
            }
            else
            {
            animator.Play("Backhand");
            }
            ball.GetComponent<Ball>().hitter = "Bot";
        }
    }
}
