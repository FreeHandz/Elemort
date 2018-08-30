using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandDisplay : MonoBehaviour{
	
	public List<GameObject> handSlots = new List<GameObject>();
	public CardDisplay cardDisplayPrefab;
    
    public void Draw()
    {
        var hand = GameManager.instance.player.hand;
        var deck = GameManager.instance.player.deck;

        if (hand.Count < 5)
        {
            if (deck.Count == 0)
            {
                Debug.Log("no more cards in deck!");
                return;
            }

            int randomIndex = ((int)UnityEngine.Random.Range(0, deck.Count - 1));
            Card drawedCard = deck[randomIndex];

			if (drawedCard != null)
			{
				hand.Add(drawedCard);
				deck.RemoveAt(randomIndex);
			}

            for (int i = 0; i < handSlots.Count; i++)
            {
                CardDisplay[] cardsInSlot = handSlots[i].GetComponentsInChildren<CardDisplay>();

                if (cardsInSlot.Length == 0)
                {
                    CardDisplay card = GameObject.Instantiate(cardDisplayPrefab, handSlots[i].transform);

                    card.transform.localPosition = Vector3.zero;
					card.card = drawedCard;
					card.RenderCard ();

                    return;
                }
            }
        }
    }
}
