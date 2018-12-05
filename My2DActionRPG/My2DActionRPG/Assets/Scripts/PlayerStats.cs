using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public int currentLevel;
    public int currentExp;
    public int[] toLevelUp;
    //vid 25
    public int[] HPLevels;
    public int[] atkLevels;
    public int[] defLevels;
    public int currentHP;
    public int currentATK;
    public int currentDEF;
    private PlayerHealthManager thePlayerHealth;

	// Use this for initialization
	void Start () {

        currentHP = HPLevels[1]; //position 1 of array, value set in unity main ui
        currentATK = atkLevels[1];
        currentDEF = defLevels[1];

        thePlayerHealth = FindObjectOfType<PlayerHealthManager>();
	}
	
	// Update is called once per frame
	void Update () {

        //reset your exp back to zero at each level, and have any spill over exp be added on
        if (currentExp >= toLevelUp[currentLevel])
        {
            currentExp -= toLevelUp[currentLevel];
            //currentLevel++; moved to function LevelUp
            LevelUp();
        }
    }

    public void AddExperience(int experienceToAdd)
    {
        currentExp += experienceToAdd;
    }

    public void LevelUp()
    {
        currentLevel++;

        currentHP = HPLevels[currentLevel];
        thePlayerHealth.playerMaxHealth = currentHP; //setting max player hp to new value in array
        thePlayerHealth.playerCurrentHealth = currentHP; //on level up, your hp goes back to full of new max hp value

        currentATK = atkLevels[currentLevel];
        currentDEF = defLevels[currentLevel];
    }

}
