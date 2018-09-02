using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{

    public List<GameObject> deckSlots;
    public CardDisplay cardDisplayPrefab;

    public void RenderDeck()
    {
        for (int i = 0; i < deckSlots.Count; i++)
        {
            CardDisplay[] cardsToDelete = deckSlots[i].GetComponentsInChildren<CardDisplay>();

            if (cardsToDelete.Length > 0)
            {
                for (int j = 0; j < cardsToDelete.Length; j++)
                {
                    Destroy(cardsToDelete[j].gameObject);
                }
            }
        }

        for (int k = 0; k < GameManager.instance.player.deck.Count; k++)
        {
            CardDisplay card = GameObject.Instantiate(cardDisplayPrefab, deckSlots[k].transform);

            card.transform.localPosition = Vector3.zero;
            card.card = GameManager.instance.player.deck[k];
            card.RenderCard();
        }
    }

    public void OpenWindow()
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
            RenderDeck();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void CloseWindow()
    {
        gameObject.SetActive(false);
    }

    void OnSimpleDragAndDropEvent(DragAndDropCell.DropEventDescriptor desc)
    {
        if (desc.triggerType == DragAndDropCell.TriggerType.DropRequest && desc.sourceCell.CompareTag("HandSlot"))
        {
            // beletette a kártyát a deckbe a kezéből
            GameManager.instance.player.hand.Remove(desc.item.GetComponent<CardDisplay>().card);
            GameManager.instance.player.deck.Add(desc.item.GetComponent<CardDisplay>().card);

            if (desc.destinationCell.GetItem())
            {
                GameManager.instance.player.deck.Remove(desc.destinationCell.GetItem().GetComponent<CardDisplay>().card);
                GameManager.instance.player.hand.Add(desc.destinationCell.GetItem().GetComponent<CardDisplay>().card);
            }
        }
    }
}
