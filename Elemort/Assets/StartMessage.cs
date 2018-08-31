using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMessage : MonoBehaviour {

	public Sprite openedSprite;
	public bool isOpened = false;
	public bool isTriggered = false;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.E) && !isOpened && isTriggered)
		{
			GameManager.instance.player.deck = GameManager.instance.defaultDeck;

			isOpened = true;
			gameObject.GetComponent<SpriteRenderer> ().sprite = openedSprite;

			while (GameManager.instance.player.hand.Count < 5)
			{
				if (GameManager.instance.player.deck.Count == 0)
					break;

				GameManager.instance.playerHand.Draw();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		isTriggered = true;
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		isTriggered = false;
	}
}
