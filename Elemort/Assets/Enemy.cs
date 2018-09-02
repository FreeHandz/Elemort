using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int health;
	public int damage;

    public bool isDead;

    public Card cardToDrop;

    public CardDrop droppedCardPrefab;

	public void takeDamage(int damage, bool fromCard = false)
	{
		health -= damage;
        GameObject.Find("EnemyDamageSound").GetComponent<AudioSource>().Play();
        if (health <= 0)
		{
			Die ();
		}
	}

	public void Die()
	{
        // TODO enemy died
        isDead = true;
        var droppedCard = Instantiate(droppedCardPrefab, gameObject.transform.position, new Quaternion());
        droppedCard.GetComponent<CardDrop>().cardToDrop = cardToDrop;
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

	void OnCollisionEnter2D(Collision2D coll)
	{
		Debug.Log ("Coll enter");
		if (coll.gameObject.CompareTag ("Player")) {
			coll.gameObject.GetComponent<Player> ().takeDamage(damage);
		}
	}
}
