using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTest : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private LineController lr;
    
    void Start()
    {
        lr.SetUpLine(points); 
    }

}
