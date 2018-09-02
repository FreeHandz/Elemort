using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSlot : MonoBehaviour {

    void OnSimpleDragAndDropEvent(DragAndDropCell.DropEventDescriptor desc)
    {
        if (desc.triggerType == DragAndDropCell.TriggerType.DropRequest 
            && desc.sourceCell.CompareTag("DeckSlot"))
        {
            GameManager.instance.player.deck.Remove(desc.item.GetComponent<CardDisplay>().card);
            GameManager.instance.player.hand.Add(desc.item.GetComponent<CardDisplay>().card);

            if (desc.destinationCell.GetItem())
            {
                GameManager.instance.player.hand.Remove(desc.destinationCell.GetItem().GetComponent<CardDisplay>().card);
                GameManager.instance.player.deck.Add(desc.destinationCell.GetItem().GetComponent<CardDisplay>().card);
            }
        }
    }
}
