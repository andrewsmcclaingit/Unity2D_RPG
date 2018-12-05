using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

    public int damageToGive;
    public GameObject damageNumber;

    //vid 25
    private PlayerStats thePS;
    private int currentDMG;

    // Use this for initialization
    void Start() {

        thePS = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update() {

    }

    void OnCollisionEnter2D(Collision2D other)
    {

        //when slime collides with other object with 2d collision box
        if (other.gameObject.name == "Player")
        {
            currentDMG = damageToGive - thePS.currentDEF;
            if(currentDMG < 0)
            {
                currentDMG = 1;
            }

            var clone = (GameObject)Instantiate(damageNumber, other.transform.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = currentDMG;

            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(currentDMG);
        }
    }
}
