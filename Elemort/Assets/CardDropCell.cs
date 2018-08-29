using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDropCell : MonoBehaviour {

	void OnSimpleDragAndDropEvent(DragAndDropCell.DropEventDescriptor desc)
	{
		Card droppedCard = desc.item.GetComponent<CardDisplay> ().card;
		Debug.Log (droppedCard.name);

		if (GameManager.instance.playerAction.useCard (droppedCard)) {
				GameManager.instance.player.hand.Remove (droppedCard);

				// TODO destroyoljuk a card displayert, nem kell többet
				Destroy(desc.item.gameObject, 1f);

			GameManager.instance.player.Draw ();
		}
	}
}
