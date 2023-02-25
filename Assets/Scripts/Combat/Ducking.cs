using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ducking : MonoBehaviour
{
    // Start is called before the first frame update
  

    // Update is called once per frame
    // Key to Duck, subjected to change
    void Update()
    {
        if(Input.GetKey("z"))
        {
            Duck();
        }
    }
    //Need to be updated once the assets are there
    void Duck()
    {
        Debug.Log("You Ducked");
    }
}
