using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Oculus.Interaction.Input;



public class ColorChange : MonoBehaviour
{
    
    //public Renderer rend;
    public GameObject Cube1;
    //private OVRInput.Button button1;
    private OVRGrabbable ovrgrabbable;
    


    void Start()
    {
        
    }

    void CubeTouched()
    {
        if (ovrgrabbable.isGrabbed)
            ChangeColor();
    }

    void ChangeColor()
    {
         Cube1.GetComponent<Renderer>().material.color = Color.black;
    }
    void Update()
    {
        
    }
}
