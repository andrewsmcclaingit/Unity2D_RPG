using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour {

    public int playerMaxHealth;
    public int playerCurrentHealth;
    //vid 24 showing player dmg numbers
    private bool flashActive;
    public float flashLength;
    private float flashCounter;

    private SpriteRenderer playerSprite;

	// Use this for initialization
	void Start () {

        playerCurrentHealth = playerMaxHealth;
        playerSprite = GetComponent<SpriteRenderer>(); //get sprtite renderer component attached to player

	}
	
	// Update is called once per frame
	void Update () {
		
        if(playerCurrentHealth <= 0 )
        {

            gameObject.SetActive(false);
            

        }

        if(flashActive)
        {
            if (flashCounter > flashLength * .66f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f); //invisible
            }
            else if (flashCounter > flashLength * .33f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f); //rbg
            }
            else if (flashCounter > 0f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f); //invis
            }
            else
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f); //rbg, 
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }

	}

    public void HurtPlayer(int damageToGive)
    {
        //taking damage, removing hp from player
        playerCurrentHealth -= damageToGive;

        flashActive = true;
        flashCounter = flashLength;
    }

    public void SetMaxHealth()
    {

        playerCurrentHealth = playerMaxHealth;

    }

}
