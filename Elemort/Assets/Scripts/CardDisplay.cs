using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour {

	public Card card;

	public Text title;
	public Text description;
	public Image artWork;
	public Text manaCost;

	// Use this for initialization
	void Start () {
		RenderCard ();
	}

	void RenderCard()
	{
		title.text = card.name;
		description.text = card.description;
		artWork = card.artWork;
		manaCost.text = card.manaCost.ToString();
	}
}
