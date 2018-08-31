using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CardDropCell : MonoBehaviour {
	void OnSimpleDragAndDropEvent(DragAndDropCell.DropEventDescriptor desc)
	{
		if (desc.triggerType != DragAndDropCell.TriggerType.DropEventEnd)
			return;

		CardDisplay droppedCard = desc.item.GetComponent<CardDisplay> ();

		if (GameManager.instance.playerAction.canPlayCard(droppedCard.card)) {

			GameManager.instance.playerAction.useCard (droppedCard.card);

			GameManager.instance.player.hand.Remove (droppedCard.card);

			StartCoroutine(WaitAndDestroy (0.3f, droppedCard));

            GameManager.instance.playerHand.Draw();
		} else {
			List<GameObject> handSlots = GameManager.instance.playerHand.handSlots;

			Destroy (droppedCard.gameObject);

			for (int i = 0; i < handSlots.Count; i++)
			{
				CardDisplay[] cardsInSlot = handSlots[i].GetComponentsInChildren<CardDisplay>();

				if (cardsInSlot.Length == 0)
				{
					CardDisplay cardDisplay = GameObject.Instantiate(GameManager.instance.playerHand.cardDisplayPrefab, handSlots[i].transform);

					cardDisplay.transform.localPosition = Vector3.zero;
					cardDisplay.card = droppedCard.card;
					cardDisplay.RenderCard ();

					return;
				}
			}

		}
	}

	IEnumerator WaitAndDestroy(float sec, CardDisplay card)
	{
		yield return new WaitForSeconds(sec);

		List<GameObject> handSlots = GameManager.instance.playerHand.handSlots;

		Destroy(card.gameObject);
	}
}
