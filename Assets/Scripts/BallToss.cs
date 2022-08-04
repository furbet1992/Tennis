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

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //tossControl = new Tosser();
        //tossControl.Toss.Tossing.performed += ctx => ballTossing();

        //tossControl.Toss.Movement.performed += ctx => move = ctx.ReadValue<Vector2>();
        //tossControl.Toss.Movement.canceled += ctx => move = Vector2.zero; 
    }

    void ballTossing()
    {
        rb.velocity = transform.transform.up * tossSpeed;
    }

     void OnEnable()
    {
        //tossControl.Toss.Enable(); 
    }

    void OnDisable()
    {
        //tossControl.Toss.Disable();
    }


    //void Start()
    //{
    //    rb = GetComponent<Rigidbody>(); 
    //}

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ballTossing(); 
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.velocity = this.gameObject.transform.forward * serveSpeed;
        }
        //Vector2 m = new Vector2(move.x, move.y) * Time.deltaTime;
        //transform.Translate(m, Space.World); 


        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();
        transform.Translate(movementDirection * speed * Time.deltaTime);



        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    rb.velocity = transform.transform.up * tossSpeed;
        //}
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
