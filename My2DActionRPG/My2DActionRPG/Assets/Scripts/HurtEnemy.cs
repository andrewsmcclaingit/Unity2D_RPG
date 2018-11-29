using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour {

    public int damageToGive;
    public GameObject DamageBurst;
    public Transform hitPoint;
    public GameObject damageNumber;

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
            Instantiate(DamageBurst, hitPoint.position, hitPoint.rotation);
            //vid 18 ~24min
            var clone = (GameObject) Instantiate(damageNumber, hitPoint.position, Quaternion.Euler (Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = damageToGive;
            //clone.transform.position = new Vector2(transform.position.x, transform.position.y);
            // number appears at the hitPoint of sword on enemy
            clone.transform.position = hitPoint.position;

        }

    }
       
}
