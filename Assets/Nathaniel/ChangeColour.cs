using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour
{
    Material cubeMat;

    private void Start()
    {
        cubeMat = GetComponent<Renderer>().material;
    }

    public void ChangeToRed()
    {
        cubeMat.color = Color.red;
    }

    public void ChangeToGreen() 
    {
        cubeMat .color = Color.green;
    }
}
