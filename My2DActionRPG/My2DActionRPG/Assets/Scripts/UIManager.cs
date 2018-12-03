using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Slider healthBar;
    public Text hpText;
    public PlayerHealthManager playerHealth;
    private static bool UIExists;
    private PlayerStats thePlayerStats;
    public Text levelText;

	// Use this for initialization
	void Start () {

        //if player does not exist, see line 23
        if (!UIExists)
        {
            UIExists = true;
            //dont destroy objects on load like transform game object. keeping camera and player the same and move to new area/scene
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            //no duplicate player creations
            Destroy(gameObject);
        }

        thePlayerStats = GetComponent<PlayerStats>();
    }
	
	// Update is called once per frame
	void Update () {

        healthBar.maxValue = playerHealth.playerMaxHealth;
        healthBar.value = playerHealth.playerCurrentHealth; //bar shows current health calling from playerhealth manager
        //healthBar.minValue = 0f;
        hpText.text = "HP: " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;
        levelText.text = "LVL: " + thePlayerStats.currentLevel;
	}
}
