using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    //default game object
    public GameObject followTarget;
    //player or target chosen position
    private Vector3 targetPos;
    //camera movespeed
    public float moveSpeed;

    private static bool cameraExists;



    // Use this for initialization
    void Start () {

        DontDestroyOnLoad(transform.gameObject);

        //if player does not exist, see line 23
        if (!cameraExists)
        {
            cameraExists = true;
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
	void Update () {

        //get targets current position via coordinates x,y,z 
        targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);

        // move camera to target position
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);

	}
}
