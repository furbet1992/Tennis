using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UITute : MonoBehaviour
{
    public GameObject BaselinerUIText;
    public GameObject OffensiveUIText;
    public GameObject DefensiveUIText;

    //Baseliner
    public void EnableBaseLinerText()
    {
        BaselinerUIText.SetActive(true);
        Invoke("DisableBaseLinerUI", 6.0f);
    }

    public void DisableBaseLinerUI()
    {
        BaselinerUIText.SetActive(false);
    }

    //play start BEGIN sound beep

    //Offensive
    public void EnableOffensiveText()
    {
        OffensiveUIText.SetActive(true);
        Invoke("DisableOffensiveUI", 6.0f);
    }

    public void DisableOffensiveUI()
    {
        OffensiveUIText.SetActive(false);
    }

    //Defensive
    public void EnableDefensiveText()
    {
        OffensiveUIText.SetActive(true);
        Invoke("DisableDefensiveUI", 6.0f);
    }

    public void DisableDefensiveUI()
    {
        OffensiveUIText.SetActive(false);
    }
}
