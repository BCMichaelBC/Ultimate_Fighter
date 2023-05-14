using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{

    void Start()
    {
        // Spawn player 1
        Instantiate(GameManager.instance.p1, new Vector2(-6,-1), Quaternion.identity);

        // Spawn player 2 
        Instantiate(GameManager.instance.p2, new Vector2(6,-1), Quaternion.identity);
    }
}