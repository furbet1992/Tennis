using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSyle : MonoBehaviour
{
    //Player player;
    Shot currentShot;
    public ShotManager shotManager;

    private void Start()
    {      
        shotManager = GetComponent<ShotManager>();
    }
    public void Baseliner()
    {
        currentShot = shotManager.topspin;
        currentShot.upforce = 8f;
        currentShot.hitforce = 17f;

        currentShot = shotManager.flat;
        currentShot.upforce = 8f;
        currentShot.hitforce = 20f;

    }

    void Allcourt()
    {

    }
    void Offensive()
    {

    }
    void Defensive()
    {

    }

    void ServeVolley()
    {

    }
}
