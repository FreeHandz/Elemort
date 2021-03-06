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

	public Image cardTemplate;

	public Sprite fireTemplate;
	public Sprite earthTemplate;
	public Sprite waterTemplate;
	public Sprite windTemplate;

	// Use this for initialization
	void Start () {
		RenderCard ();
	}

	public void RenderCard()
	{
		if (card.elementType == Card.ElementType.earth) {
			cardTemplate.sprite = earthTemplate;
		} else if (card.elementType == Card.ElementType.water) {
			cardTemplate.sprite = waterTemplate;
		} else if (card.elementType == Card.ElementType.fire) {
			cardTemplate.sprite = fireTemplate;
		} else if (card.elementType == Card.ElementType.wind) {
			cardTemplate.sprite = windTemplate;
		}

		title.text = card.name;
		description.text = card.description;
		artWork.sprite = card.artWork;
		manaCost.text = card.cost.ToString();
	}
}
