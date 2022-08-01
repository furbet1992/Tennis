using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdrenalineBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill; 

    public void SetMaxAdrenaline(int Adrenaline)
    {
        slider.maxValue = Adrenaline;
        slider.value = Adrenaline;
        fill.color = gradient.Evaluate(1f); 
    }

    public void SetMinAdrenaline(int Adrenaline)
    {
        slider.minValue = Adrenaline;
        slider.value = Adrenaline;
        fill.color = gradient.Evaluate(0f);
    }

    public void SetAdrenaline(int Adrenaline)
    {
        slider.value = Adrenaline;

        fill.color = gradient.Evaluate(slider.normalizedValue); 
    }
     

}
