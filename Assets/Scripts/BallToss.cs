using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem; 
public class BallToss : MonoBehaviour
{
    public float serveSpeed;
    public float speed;

    public float tossSpeed;
    Rigidbody rb;

    //Tosser tossControl;
    Vector2 move;

    public Shot currentShot;
    ShotManager shotManager;



    //Landmarks within ServiceBox
    Vector3 TargetPosition;
    public Transform downlineTarget; 




    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        TargetPosition = downlineTarget.position;
        shotManager = GetComponent<ShotManager>(); 
    }

    void ballTossing()
    {
        rb.velocity = transform.transform.up * tossSpeed;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ballTossing(); 
        }
        //else if (Input.GetKeyUp(KeyCode.Space))
        //{
        //   // rb.velocity = this.gameObject.transform.forward * serveSpeed;
        //}

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();
        transform.Translate(movementDirection * speed * Time.deltaTime);

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "ServiceBoxLine" || Input.GetKeyUp(KeyCode.Space))
        {
            Vector3 dir = downlineTarget.position - transform.position;
            this.GetComponent<Rigidbody>().velocity = dir.normalized * currentShot.hitforce + new Vector3(0, currentShot.upforce, 0);
            serveSpeed *= 2;
        }
    }

    //void Grow()
    //{

    //    //if the position of the ball is <0, make localscale the ball UP
    //    //if(this.transform.position.x <= 0.5)
    //    //{
    //    //    transform.localScale *= 0.4f; 
    //    //}

    //}
}
