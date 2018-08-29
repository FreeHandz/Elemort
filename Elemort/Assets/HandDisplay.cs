﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandDisplay : MonoBehaviour {
	
	public List<GameObject> handSlots = new List<GameObject>();
	public CardDisplay cardDisplayPrefab;

	public void EraseHand()
	{
		for (int i = 0; i < handSlots.Count; i++) {
			CardDisplay[] items = handSlots [i].gameObject.GetComponentsInChildren<CardDisplay> ();

			for (int j = 0; j < items.Length; j++) {
				Destroy (items [j].gameObject);
			}
		}
	}
		
	public void RenderHand()
	{
		EraseHand ();

		if (GameManager.instance.player.hand.Count > 0) {
			for (int i = 0; i < handSlots.Count; i++) {
				if (i < GameManager.instance.player.hand.Count) {

					var card = GameObject.Instantiate (cardDisplayPrefab, handSlots[i].transform);

					cardDisplayPrefab.transform.localPosition = Vector3.zero;
					cardDisplayPrefab.card = GameManager.instance.player.hand [i];

					cardDisplayPrefab.RenderCard ();

				}
			}
		}
	}
}
