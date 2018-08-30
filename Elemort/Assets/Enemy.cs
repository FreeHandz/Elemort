using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int health;

	public void takeDamage(int damage, bool fromCard = false)
	{
		health -= damage;
		if (health <= 0)
		{
			Die ();
		}
	}

	public void Die()
	{
		// TODO enemy died
		gameObject.SetActive(false);
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Damage")
		{
			Damage damage = collision.gameObject.GetComponent<Damage>();

			if (damage.source == DamageSourceType.Player || damage.source == DamageSourceType.Other)
			{
				takeDamage(damage.damageAmount);
				damage.damageTaken();
			}
		}
	}
}
