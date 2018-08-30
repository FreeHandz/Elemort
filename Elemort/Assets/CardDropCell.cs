using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CardDropCell : MonoBehaviour {
	public GameObject cardParticle;

	void OnSimpleDragAndDropEvent(DragAndDropCell.DropEventDescriptor desc)
	{
		if (desc.triggerType != DragAndDropCell.TriggerType.DropEventEnd)
			return;

		CardDisplay droppedCard = desc.item.GetComponent<CardDisplay> ();

		if (GameManager.instance.playerAction.useCard (droppedCard.card)) {

			GameManager.instance.player.hand.Remove (droppedCard.card);

			GameObject particleSystem = GameObject.Instantiate (cardParticle, desc.destinationCell.gameObject.transform);
			particleSystem.transform.localPosition = new Vector3(0, 0, 20f) ;

			StartCoroutine(WaitAndDestroy (1, droppedCard, particleSystem.GetComponent<ParticleSystem> ()));

            GameManager.instance.playerHand.Draw();
		} else {
			Debug.Log ("cannot play card");
		}
	}

	IEnumerator WaitAndDestroy(float sec, CardDisplay card, ParticleSystem particle)
	{
		yield return new WaitForSeconds(sec);

		Destroy(card.gameObject);
		particle.Play ();
	}
}
