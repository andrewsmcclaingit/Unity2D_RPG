using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //player variable move speed
    //float allows for decimal points unlike an 'int'
    public float moveSpeed;

    //reference to the Animator
    //reference to the Rigidbody 2D
    private Animator anim;
    private Rigidbody2D myRigidbody;

    // true or false for player moving to know which way to face
    private bool playerMoving;
    public Vector2 lastMove;

    //true or false
    //any object with this script attached, all playerExists will use this bool (that's what static means)
    private static bool playerExists;

    //vid16 attack anim
    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;

    public string startPoint;

    // Use this for initialization
    //when scene start
    void Start()
    {

        //Finds animator object, related to line 14
        anim = GetComponent<Animator>();
        //get rigidbody object, related to line 15
        myRigidbody = GetComponent<Rigidbody2D>();

        //if player does not exist, see line 23
        if (!playerExists)
        {
            playerExists = true;
            //dont destroy objects on load like transform game object. keeping camera and player the same and move to new area/scene
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            //no duplicate player creations
            Destroy(gameObject);
        }


    }

    // Update is called once per frame
    void Update()
    {

        //each frame will set to false unless player is moving
        playerMoving = false;
        //if (!attacking) { 

        // horizontal axis (left or right)
        // || in unity means OR
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            // move character in world
            // deltaTime function creates value -> last update happens like frames
            // not using y or z at the end of the vector, f = float
            //video 8 -> transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));

            //using rigidbody2d physics
            myRigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, myRigidbody.velocity.y);

            playerMoving = true;

            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }

        // vertical axis (up or down)
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            // move character in world
            // deltaTime function creates value -> last update happens like frames
            // not using x or z at the end of the vector, f = float
            //video 8 -> transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));

            //getting raw velocity
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxis("Vertical") * moveSpeed);

            playerMoving = true;

            //Declaring our last move to that of the input during the last frame before the update
            //so if player goes left and then stops, character will remain facing left
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }


        //reseting velocity of play movement so that you are not 'ice skating' around
        if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
        {
            myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
        }

        if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
        }

        //player attack press J
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            attackTimeCounter = attackTime;
            attacking = true;
            myRigidbody.velocity = Vector2.zero;
            anim.SetBool("Attack", true);

        }

        //}
        if (attackTimeCounter > 0)
        {

            attackTimeCounter -= Time.deltaTime;

        }

        if (attackTimeCounter <= 0)
        {

            attacking = false;
            anim.SetBool("Attack", false);
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x); // telling the animator to do the LastMoveX according to the lastMove vector in the IF statements above
        anim.SetFloat("LastMoveY", lastMove.y);

    }
}
