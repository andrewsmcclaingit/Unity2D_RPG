using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour {

    public int damageToGive;
    public GameObject damageBurst;
    public Transform hitPoint;

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
            // Destroy(other.gameObject);
           
            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
            //damage particle effect on sword transform position
            Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);

        }

    }
       
}
