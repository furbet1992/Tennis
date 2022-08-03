using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Ball : MonoBehaviour
{
    Vector3 initialPos;
    Rigidbody rb;

    public string hitter;

    int playerScore;
    int botScore;

    public bool playing = true;

   [SerializeField] Text playerScoreText;
   [SerializeField] Text botScoreText;
   [SerializeField] Text stringSnapText;

    void Start()
    {
        initialPos = transform.position;
        rb = GetComponent<Rigidbody>();

        playerScore = 0;
        botScore= 0;
        updateScore(); 
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

            GameObject.Find("Player").GetComponent<Player>().Reset();

            if (playing)
            {
                if (hitter == "Player")
                {
                    playerScore++;
                }
                else if (hitter == "Bot")
                {
                    botScore++;
                }
                playing = false;
                updateScore(); 
            }
        }
        else if (collision.transform.CompareTag("Out"))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            GameObject.Find("Player").GetComponent<Player>().Reset();

            if (playing)
            {
                if (hitter == "Player")
                {
                    playerScore++;
                }
                else if (hitter == "Bot")
                {
                    botScore++;
                }
                playing = false;
                updateScore();
            }
        }
     }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Out") && playing)
        {
            if(hitter == "Player")
            {
                botScore++; 
            }
            else if(hitter == "Bot")
            {
                playerScore++; 
            }
            playing = false;
            updateScore();
        }
    }

    void updateScore()
    {
        playerScoreText.text = playerScore.ToString(); 
        botScoreText.text = botScore.ToString(); 
    }

}
