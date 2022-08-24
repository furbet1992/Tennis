using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class TranScene : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Jack_Trainer")
        {
            Debug.Log("detect"); 
            SceneManager.LoadScene(sceneBuildIndex: 4); 
        }
    }
}
