using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour {

	// Use this for initialization
	void Start () {


    }
	
	// Update is called once per frame
	void Update () {


    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        //tag all enemies as tag so that they have same?
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }

    }
       
}
