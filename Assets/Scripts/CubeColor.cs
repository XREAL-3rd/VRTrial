using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeColor : MonoBehaviour
{
    Transform pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(pos.position.y > 0.5)
        {
            changeBlue();
        }
        else
        {
            changeRed();
        }
    }
    
    void changeBlue()
    {
        pos.GetComponent<Renderer>().material.color = Color.blue;
    }

    void changeRed()
    {
        pos.transform.GetComponent<Renderer>().material.color = Color.red;
    }
}
