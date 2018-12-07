using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerMovement : MonoBehaviour {

    //vid 26 npc movement
    public float moveSpeed;
    private Rigidbody2D myRigigbody;
    public bool isWalking;
    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;
    private int walkDirection;

	// Use this for initialization
	void Start () {

        myRigigbody = GetComponent<Rigidbody2D>();
        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();
	}
	
	// Update is called once per frame
	void Update () {
		
        if(isWalking)
        {
            walkCounter -= Time.deltaTime;

            switch(walkDirection)
            {
                case 0:
                    myRigigbody.velocity = new Vector2(0, moveSpeed);
                        break;
                case 1:
                    myRigigbody.velocity = new Vector2(moveSpeed, 0);
                    break;
                case 2:
                    myRigigbody.velocity = new Vector2(0, -moveSpeed);
                    break;
                case 3:
                    myRigigbody.velocity = new Vector2(-moveSpeed, 0);
                    break;
            }

            if (walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;
            myRigigbody.velocity = Vector2.zero;

            if (waitCounter < 0)
            {
                ChooseDirection(); //pick new direction to walk
            }
        }

	}

    public void ChooseDirection()
    {

        walkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
    }

}
