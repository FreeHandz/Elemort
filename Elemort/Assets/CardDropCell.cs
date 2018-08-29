using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDropCell : MonoBehaviour {

	void OnSimpleDragAndDropEvent(DragAndDropCell.DropEventDescriptor desc)
	{
		Card droppedCard = desc.item.GetComponent<CardDisplay> ().card;
		GameManager.instance.playerAction.useCard (droppedCard);
	}
}
