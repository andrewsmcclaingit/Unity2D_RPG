using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour {

    public int damageToGive;
    public GameObject DamageBurst;
    public Transform hitPoint;
    public GameObject damageNumber;

    //vid 25
    private PlayerStats thePS;
    private int currentDMG;

	// Use this for initialization
	void Start () {

        thePS = FindObjectOfType<PlayerStats>();

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

            currentDMG = damageToGive + thePS.currentATK;

            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(currentDMG);
            //damage particle effect on sword transform position
            Instantiate(DamageBurst, hitPoint.position, hitPoint.rotation);
            //vid 18 ~24min
            var clone = (GameObject) Instantiate(damageNumber, hitPoint.position, Quaternion.Euler (Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = currentDMG;
            //clone.transform.position = new Vector2(transform.position.x, transform.position.y);
            // number appears at the hitPoint of sword on enemy
            clone.transform.position = hitPoint.position;

        }

    }
       
}
