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

			StartCoroutine(WaitAndDestroy (0.3f, droppedCard));

            GameManager.instance.playerHand.Draw();
		} else {
			Debug.Log ("cannot play card");
		}
	}

	IEnumerator WaitAndDestroy(float sec, CardDisplay card)
	{
		yield return new WaitForSeconds(sec);

		Destroy(card.gameObject);
	}
}
