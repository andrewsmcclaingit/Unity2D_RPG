using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * 
 * 
 * 
 **/

public class SlimeController : MonoBehaviour {

    //how fast slime moves
    public float moveSpeed;

    private Rigidbody2D myRigidbody;

    //is slime moving? true or false
    private bool moving;

    //how long it takes between each movement
    //
    public float timeBetweenMove;
    private float timeBetweenMoveCounter;

    //how long it takes to move for
    //
    public float timeToMove;
    private float timeToMoveCounter;

    //
    private Vector3 moveDirection;

    //
    public float waitToReload;
    private bool reloading;
    private GameObject thePlayer;

	// Use this for initialization
	void Start () {

        myRigidbody = GetComponent<Rigidbody2D>();

        //comented out vid 12
        //timeBetweenMoveCounter = timeBetweenMove;
        //timeToMoveCounter = timeToMove;

        //random movement for slime
        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);

	}
	
	// Update is called once per frame
	void Update () {
		
        //if slime moving
        //time.deltatime 1 frame update
        if(moving)
        {

            timeToMoveCounter -= Time.deltaTime;
            //slime speed
            myRigidbody.velocity = moveDirection;

            if(timeToMoveCounter < 0f)
            {
                moving = false;
                //vid 12 timeBetweenMoveCounter = timeBetweenMove;
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
            }

        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            myRigidbody.velocity = Vector2.zero;

            if(timeBetweenMoveCounter < 0f)
            {
                moving = true;
                //vid 12 timeToMoveCounter = timeToMove;
                timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);

                moveDirection = new Vector3(Random.Range(-1f,1f) * moveSpeed, Random.Range(-1f,1f) * moveSpeed, 0f);
            }
        }

        if (reloading)
        {
            waitToReload -= Time.deltaTime; //counting down
            if(waitToReload < 0)
            {
                //test i did//SceneManager.LoadSceneAsync("tent_inside");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                thePlayer.SetActive(true);
                //reloading = false;
            }
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {

        //when slime collides with other object with 2d collision box
        /* if(other.gameObject.name == "Player")
         {
             //vid 12 Destroy(other.gameObject);

             //other is what we found aka player, player no longer active
             //when reload scnee make sure player is active again
             //reloading level
             other.gameObject.SetActive(false);
             reloading = true;
             thePlayer = other.gameObject;


         //vid 15




         }*/
    }
}
