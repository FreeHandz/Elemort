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

				if (i < GameManager.instance.player.hand.Count) {
					var card = GameObject.Instantiate (cardDisplayPrefab, handSlots[i].transform);

					cardDisplayPrefab.card = GameManager.instance.player.hand [i];

					cardDisplayPrefab.RenderCard ();

					cardDisplayPrefab.transform.localPosition = handSlots [i].transform.position;
				}
			}
		}
	}
}
