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
    //DownLine
    Vector3 TargetPositionDownline;
    public Transform downlineTarget;
    //CornerBox
    Vector3 TargetPositionCorner;
    public Transform cornerBoxTarget;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        shotManager = GetComponent<ShotManager>();

        //Targets
        TargetPositionDownline = downlineTarget.position;
        TargetPositionCorner = cornerBoxTarget.position;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
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
        if (other.name == "ServiceBoxLine")
        {
            {
                gameObject.transform.position = transform.position + new Vector3(0, 1.5f, 0);
                StartCoroutine(ServeDownLine()); 
            }
        }

        if (other.name == "CornerBox")
        {
            {
                gameObject.transform.position = transform.position + new Vector3(0, 1.5f, 0);
                StartCoroutine(ServeCornerLine()); 
            }
        }
    }

    IEnumerator ServeDownLine()
    {
                 yield return new WaitForSeconds(1f);
                rb.isKinematic = false;
                Vector3 dirBox = downlineTarget.position - transform.position;
                gameObject.GetComponent<Rigidbody>().velocity = dirBox.normalized * currentShot.hitforce + new Vector3(0, currentShot.upforce, 0);
                serveSpeed *= 2;
    }

    IEnumerator ServeCornerLine()
    {
                yield return new WaitForSeconds(1f);
                rb.isKinematic = false;
                Vector3 dirCorner = cornerBoxTarget.position - transform.position;
                gameObject.GetComponent<Rigidbody>().velocity = dirCorner.normalized * currentShot.hitforce + new Vector3(0, currentShot.upforce, 0);
                serveSpeed *= 2;
    }

}
