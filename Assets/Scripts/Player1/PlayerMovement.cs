using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float movement;
    [SerializeField] public int walkspeed = 5;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] float jumpForce = 500.0f;
    [SerializeField] bool isGrounded = true;
    [SerializeField] Animator animator;
    [SerializeField] Animator p2animator;
    public Timer timerScript;
    public Combat combatScript;

    public StateManager states;

    // Start is called before the first frame update
    void Start()
    {
        p2animator = GameObject.FindGameObjectWithTag("Player 2").GetComponent<Animator>();
        timerScript = GameObject.Find("Canvas").GetComponent<Timer>();
        combatScript = this.GetComponent<Combat>();
        states = GetComponent<StateManager>();
        // we do this to get the component rigid body form inspector so we can interact with it in code
        if (rigid == null)
        {
            rigid = GetComponent<Rigidbody2D>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (states == null)
        {
            states = GetComponent<StateManager>();
        }
        // Getting the x values of movement from the player so if the player wants to move left or right
        if (!states.dontMove)
        {
            movement = Input.GetAxis("Horizontal");
            combatScript.roundOver = false;
        }
        else {
            combatScript.roundOver = true;
        }

        //Check if the player is moving, and changes the animation accordingly 
        animator.SetFloat("Speed", Mathf.Abs(movement));
        if (Input.GetKeyDown(KeyCode.W))
            jumpPressed = true;

        faceOpponent();
    }

    // fixed update is for ui changes if chages were made in update they would look kinda cluncky
    void FixedUpdate()
    {

        rigid.velocity = new Vector2(movement * walkspeed, rigid.velocity.y);
        if (jumpPressed && isGrounded && !states.dontMove)
        {
            Jump();
        }


    }

    public void Jump()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        // its like (x, y) when u press to jump we arent moving horizonlty but vertically
        rigid.AddForce(new Vector2(0, jumpForce));
        isGrounded = false; // not on ground any more 
        states.onGround = false;
        //states.movementcolliders[1].SetActive(false);
        animator.SetBool("Jumping", true);
        jumpPressed = false; // to avoid double jump
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true; // youve hit the ground again

            if (states != null)
            {
                states.onGround = true;
                states.movementcolliders[1].SetActive(true);
            }

            animator.SetBool("Jumping", false);
        }
    }
    void ResetGame()
    {
        animator.SetBool("NextRound", true);
        p2animator.SetBool("NextRound", true);
        timerScript.Reset();
    }
    public void faceOpponent()
    {
        if (states != null && states.opponent != null)
        {
            if (transform.position.x - states.opponent.transform.position.x < 0)
            {
                states.lookLeft = false;
            }
            else
            {
                states.lookLeft = true;
            }
        }
    }
}