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

		if (GameManager.instance.playerAction.useCard (droppedCard.card)) {

			GameManager.instance.player.hand.Remove (droppedCard.card);

				// TODO destroyoljuk a card displayert, nem kell többet
			Destroy(droppedCard.gameObject, 1f);

			GameManager.instance.player.Draw ();
		} else {
			Debug.Log ("cannot play card");
			Destroy (desc.item.gameObject);
			GameManager.instance.playerHand.RenderHand ();
		}
	}
}
