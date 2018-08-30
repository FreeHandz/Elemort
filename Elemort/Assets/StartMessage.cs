using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMessage : MonoBehaviour {

	public Sprite openedSprite;
	public bool isOpened = false;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.E) && !isOpened)
		{
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
}
