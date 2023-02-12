using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    // Start is called before the first frame update
 
    // Update is called once per frame
    // Key to jump, subjected to change
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Jump();
        }
    }
    // Need to be updated once the assets are there
    void Jump()
    {

        Debug.Log("You Jumped");


    }
}
