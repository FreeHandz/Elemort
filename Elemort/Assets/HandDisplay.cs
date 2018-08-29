using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandDisplay : MonoBehaviour {
	
	public List<GameObject> handSlots = new List<GameObject>();
	public CardDisplay cardDisplayPrefab;

	public void RenderHand()
	{
		if (GameManager.instance.player.hand.Count > 0) {
			for (int i = 0; i < handSlots.Count; i++) {
				GameObject.Instantiate (cardDisplayPrefab, gameObject.transform);
				cardDisplayPrefab.card = GameManager.instance.player.hand [i];

				cardDisplayPrefab.RenderCard();
			}
		}
	}
}
