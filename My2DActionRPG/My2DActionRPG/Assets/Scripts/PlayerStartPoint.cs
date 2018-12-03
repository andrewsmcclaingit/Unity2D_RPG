using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour {

    //
    private PlayerController thePlayer;
    private CameraController theCamera;
    //which way character will face when entering new area
    public Vector2 startDirection;

    //name of point starting
    public string pointName;

	// Use this for initialization
	void Start () {

        //find the object with playercontroller script attached
        //finding player character
        thePlayer = FindObjectOfType<PlayerController>();

        if(thePlayer.startPoint == pointName)
        {

        thePlayer.transform.position = transform.position;
        thePlayer.lastMove = startDirection;

        theCamera = FindObjectOfType<CameraController>();
        theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
