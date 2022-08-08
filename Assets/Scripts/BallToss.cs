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

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        TargetPosition = downlineTarget.position;
        shotManager = GetComponent<ShotManager>(); 
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 movementDirection = new Vector3(horizontalInput, verticalInput, 0);
            movementDirection.Normalize();
            transform.Translate(movementDirection * speed * Time.deltaTime);
           // ballTossing(); 
        }

    }

    //void ballTossing()
    //{
    //    rb.velocity = transform.transform.up * tossSpeed;
    //}


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ServiceBoxLine" || Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("detected"); 
            Vector3 dir = downlineTarget.position - transform.position;
            this.GetComponent<Rigidbody>().velocity = dir.normalized * currentShot.hitforce + new Vector3(0, currentShot.upforce, 0);
            serveSpeed *= 2;
        }
    }
}
