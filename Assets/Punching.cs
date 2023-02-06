using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punching : MonoBehaviour
{

 

    // Update is called once per frame
    void Update()
    {
        //Key to attack might change later down the line
        if(Input.GetKey("x"))
        {
            Punch();

        }
    }
    // Punch Function. Need to be updated once enemy , collision , and animations are introduced. 
    void Punch()
    {

        Debug.Log("You Punched");



    }
}
