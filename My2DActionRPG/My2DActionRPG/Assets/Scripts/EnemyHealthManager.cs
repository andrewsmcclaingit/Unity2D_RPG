﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

    public int  MaxHealth;
    public int  CurrentHealth;
    private PlayerStats thePlayerStats;
    public int expToGive;
 

    // Use this for initialization
    void Start()
    {

         CurrentHealth =  MaxHealth;
        thePlayerStats = FindObjectOfType<PlayerStats>();

    }

    // Update is called once per frame
    void Update()
    {

        if (CurrentHealth <= 0)
        {

            //gameObject.SetActive(false);
            Destroy(gameObject);
            thePlayerStats.AddExperience(expToGive);

        }

    }

    public void HurtEnemy (int damageToGive)
    {
        //taking damage, removing hp from  
         CurrentHealth -= damageToGive;


    }

    public void SetMaxHealth()
    {

         CurrentHealth =  MaxHealth;

    }

}
