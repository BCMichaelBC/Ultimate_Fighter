using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punching : MonoBehaviour
{

 

    // Update is called once per frame
    void Update()
    {
        //Key to attack, subjected to change
        if(Input.GetKey("x"))
        {
            Punch();

        }
    }
    // Need to be updated once the assets are there
    void Punch()
    {

        Debug.Log("You Punched");



    }
}
