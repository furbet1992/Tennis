using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntialScene : MonoBehaviour
{
    public Animator animCamera; 
    public Animator animTrainer; 

    void Start()
    {
        animCamera.GetComponent<Animator>();

        Debug.Log("Hey Jnr");
        StartCoroutine(FirstCutScene()); 
    }

    IEnumerator FirstCutScene()
    {
        yield return new WaitForSeconds(2);
        animCamera.Play("Initial_Turn");
        StartCoroutine(JackTrainerTurning()); 
    }

    IEnumerator JackTrainerTurning()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("come and watch me play when you’re ready mate. Let me show you what a world ranked 200 plays. before your ATP debut"); 
        animTrainer.Play("Jack_Trainer_first"); 
    }


}
