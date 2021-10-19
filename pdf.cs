using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pdf : MonoBehaviour
{
 
    // Update is called once per frame
    void Start()
    {
       
    }

    public void EnlacesWeb(string enlace)
    {
        Application.OpenURL(enlace);
    }
}
