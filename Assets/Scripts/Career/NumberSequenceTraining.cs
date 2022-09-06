using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberSequenceTraining : MonoBehaviour
{
    int completeLevelScore = 2;
    int currrentLevelScore;

    private bool firsthasIntercepted;
    private bool secondhasIntercepted;

    public SceneMan scene;

    void Start()
    {
        currrentLevelScore = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        if (currrentLevelScore == completeLevelScore)
        {
            scene.ChangeScene(6);
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Target_01" && !firsthasIntercepted)
        {
            Debug.Log("1"); 
            currrentLevelScore += 1;
            firsthasIntercepted = true;
        }

        if (other.gameObject.name == "Target_02" && !secondhasIntercepted)
        {
            Debug.Log("2");
            currrentLevelScore += 1;
            secondhasIntercepted = true;
        }
    }
}
