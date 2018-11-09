using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	// Use this for initialization
	void Start () {

        myRigidbody = GetComponent<Rigidbody2D>();

        timeBetweenMoveCounter = timeBetweenMove;
        timeToMoveCounter = timeToMove;

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
                timeBetweenMoveCounter = timeBetweenMove;
            }

        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            myRigidbody.velocity = Vector2.zero;

            if(timeBetweenMoveCounter < 0f)
            {
                moving = true;
                timeToMoveCounter = timeToMove;

                moveDirection = new Vector3(Random.Range(-1f,1f) * moveSpeed, Random.Range(-1f,1f) * moveSpeed, 0f);
            }
        }

	}
}
