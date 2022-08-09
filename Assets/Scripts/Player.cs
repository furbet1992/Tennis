using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Player : MonoBehaviour
{
    public Transform aimTarget; 
    public float speed;
    // public float force;
    //public float ballHeight; 
    
    bool hitting;
    public Transform ball; 
    Animator animator;

    Vector3 aimTargetInitialPosition;

    ShotManager shotManager;
    Shot currentShot;
    public int flatShotCount; 

    public AdrenalineBar adrenalineBar;
    public int maxAdrenaline = 100;
    public int minAdrenaline = 0; 
    public int currentAdrenaline;

    public ParticleSystem adrenalineParticle;

    [SerializeField] Transform serveRight;
    [SerializeField] Transform serveLeft;

    bool servedRight = true;

    public Text stringBrokenText; 


    void Start()
    {
        animator = GetComponent<Animator>();
        aimTargetInitialPosition = aimTarget.position;
        shotManager = GetComponent<ShotManager>();
        currentShot = shotManager.topspin;

        currentAdrenaline = minAdrenaline;
        adrenalineBar.SetMinAdrenaline(minAdrenaline);

        adrenalineParticle.Stop(); 
    }

    // Update is called once per frame
    void Update()
    { 
        //if(flatShotCount == 6)
        //if(flatShotCount == 3)

        //{
        //    stringBrokenText.text = "String Snapped, Change Racquet".ToString();
        //    Time.timeScale = 0; 
        //}

            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

        //FlatHit
        if (Input.GetMouseButtonDown(0))
        {
            hitting = true;
            currentShot = shotManager.topspin;
            flatShotCount++; 
            //trail renderer to be green
        }
        else if (Input.GetMouseButtonUp(0))
        {
            hitting = false; 
        }

        //FlatHit
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

        //FlatServe
        if (Input.GetKeyDown(KeyCode.R))
        {
            hitting = true;
            currentShot = shotManager.flatServe;
            GetComponent<BoxCollider>().enabled = false;
            animator.Play("Serve_Prepare");
        }

        //KickServe
        if (Input.GetKeyDown(KeyCode.T))
        {
            hitting = true;
            currentShot = shotManager.kickServe;
            GetComponent<BoxCollider>().enabled = false;
            animator.Play("Serve_Prepare");
        }
        if (Input.GetKeyUp(KeyCode.R) || Input.GetKeyUp(KeyCode.T))
        {
            hitting = false;
            GetComponent<BoxCollider>().enabled = true;
            ball.transform.position = transform.position + new Vector3(0.2f, 3f, 0);
            Vector3 dir = aimTarget.position - transform.position;
            ball.GetComponent<Rigidbody>().velocity = dir.normalized * currentShot.hitforce + new Vector3(0, currentShot.upforce, 0);            
            animator.Play("Serve");
            ball.GetComponent<Ball>().hitter = "Player";
            ball.GetComponent<Ball>().playing = true;

        }

        if (hitting)
        {
            aimTarget.Translate(new Vector3(h, 0, 0) * speed * Time.deltaTime); 
        }

            if ((h != 0 || v != 0) && !hitting)
        {
            transform.Translate(new Vector3(h, 0, v) * speed * Time.deltaTime);
        }

        //activate Adrenaline Bar
        if (Input.GetKeyDown(KeyCode.Y) && currentAdrenaline > 0)
        {
            speed = 8;
            adrenalineParticle.Play(); 
            //currentAdrenaline decreases in increments using time, until current Adrenaline equals 0 
            if (currentAdrenaline == 0)
            {
                speed = 5; 
            }
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
            ball.GetComponent<Ball>().hitter = "Player"; 
            aimTarget.position = aimTargetInitialPosition;
            IncreaseAD(10);       
        }
    }

    void IncreaseAD(int adrenaline)
    {
        currentAdrenaline += adrenaline;
        adrenalineBar.SetAdrenaline(currentAdrenaline); 
    }

    public void Reset()
    {
        if (servedRight)
            transform.position = serveLeft.position;
        else
            transform.position = serveRight.position;

        servedRight = !servedRight; 
    }
}
