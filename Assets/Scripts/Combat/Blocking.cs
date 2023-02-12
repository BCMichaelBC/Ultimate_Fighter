using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocking : MonoBehaviour
{

    // Update is called once per frame
    // Key to block , subjected to change
    void Update()
    {
        if(Input.GetKey("c"))
        {
            Block();
        }
    }

    // Need to be updated once the assets are there
    void Block()
    {
        Debug.Log("You Blocked");
    }
}
