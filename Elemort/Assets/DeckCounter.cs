using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckCounter : MonoBehaviour {

	public Text deckText;
	
	// Update is called once per frame
	void Update () {
		deckText.text = GameManager.instance.player.deck.Count.ToString ();
	}
}
