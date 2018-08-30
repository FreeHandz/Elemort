                                        using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // todo: Ezt ki kell még találni
    private const int defaultHealth = 20;
    private const float defaultMass = 1;
    private const float lightWeightMass = 0.6f;

    private DateTime lightWeightUntil = DateTime.Now;
    private DateTime safeModeUntil = DateTime.Now;

	public List<Card> deck = new List<Card>();
	public List<Card> hand = new List<Card>();

    public GameObject fireBallPrefab;
    
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
			GameManager.instance.EndGame ();
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
			GameManager.instance.EndGame ();
        }
    }

    public void fireFireball(int duration, int damage, DamageSourceType source)
    {
        GameObject fireBallGameObject = GameObject.Instantiate(fireBallPrefab);

        fireBallGameObject.transform.position = this.transform.position;

        FireBall fireBall = fireBallGameObject.GetComponent<FireBall>();
        fireBall.init(duration, damage, source);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Damage")
        {
            Damage damage = collision.gameObject.GetComponent<Damage>();

            if (damage.source == DamageSourceType.Enemy || damage.source == DamageSourceType.Other)
            {
                health -= damage.damageAmount;
            }
        }
    }
}
