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
}
