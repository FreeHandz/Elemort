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
			GameManager.instance.player.hand = GameManager.instance.defaultHand;

			isOpened = true;
			gameObject.GetComponent<SpriteRenderer> ().sprite = openedSprite;

			List<GameObject> handSlots = GameManager.instance.playerHand.handSlots;

			for (int j = 0; j < GameManager.instance.player.hand.Count; j++) {
				for (int i = 0; i < handSlots.Count; i++)
				{
					CardDisplay[] cardsInSlot = handSlots[i].GetComponentsInChildren<CardDisplay>();

					if (cardsInSlot.Length == 0)
					{
						CardDisplay cardDisplay = GameObject.Instantiate(GameManager.instance.playerHand.cardDisplayPrefab, handSlots[i].transform);

						cardDisplay.transform.localPosition = Vector3.zero;
						cardDisplay.card = GameManager.instance.player.hand[j];
						cardDisplay.RenderCard ();
						break;
					}
				}
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
