﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // todo: Ezt ki kell még találni
    private const int defaultHealth = 20;
    private const float defaultMass = 1;
    private const float lightWeightMass = 0.3f;

    private DateTime lightWeightUntil = DateTime.Now;
    private DateTime safeModeUntil = DateTime.Now;

	public List<Card> deck = new List<Card>();
	public List<Card> hand = new List<Card>();
    
    private int health = defaultHealth;
    public int Health
    {
        get { return health; }
    }

    public void startLightWeight(int duration)
    {
		lightWeightUntil = DateTime.Now.AddSeconds(duration);
    }

    public void Update()
    {
        if (health <= 0)
        {
            //TODO: Init endgame
        }

        Rigidbody2D playersRigidbody = this.GetComponent<Rigidbody2D>();

        if (lightWeightUntil > DateTime.Now)
        {
			
            playersRigidbody.mass = lightWeightMass;
        }
        else
        {
            playersRigidbody.mass = defaultMass;
        }
    }

    public void takeDamage(int damage, bool fromCard = false)
    {
        // Player is in safe mode, cannot take any damage, except if it is from playing a card
        if (safeModeUntil > DateTime.Now && !fromCard)
            return;

        health -= damage;
        if (health <= 0)
        {
            //TODO: init endgame
        }
    }
}
