using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class BaseLinerTutorial : MonoBehaviour
{
    int completeStage =2;
    int currrentStage;
    public Text tuteScoreText;
    public GameObject levelCompleteText; 

    bool hasIntercepted;

    public UITute uiTextsEnable;


    void Start()
    {
        currrentStage = 0;
        tuteScoreText = GetComponent<Text>();
    }

    public void Update()
    {
        if (currrentStage == completeStage)
        {
            levelCompleteText.SetActive(true);
            uiTextsEnable.EnableOffensiveText(); 
        }
    }


    public void OnTriggerEnter(Collider other)
    {
        if(other.name == "BaseLiner_Game_Right" && !hasIntercepted)
        {
            Debug.Log("bot detected"); 
            currrentStage++;
            hasIntercepted = true; 
        }
        if (other.name == "BaseLiner_Game_Left")
        {
            Debug.Log("bot detected");
            currrentStage++;
        }
    }

}
