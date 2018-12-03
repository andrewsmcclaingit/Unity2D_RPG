using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public int currentLevel;
    public int currentExp;
    public int[] toLevelUp;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //reset your exp back to zero at each level, and have any spill over exp be added on
        if (currentExp >= toLevelUp[currentLevel])
        {
            currentExp -= toLevelUp[currentLevel];
            currentLevel++;
        }
    }

    public void AddExperience(int experienceToAdd)
    {
        currentExp += experienceToAdd;
    }
}
