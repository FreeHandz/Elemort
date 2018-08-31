using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDrop : MonoBehaviour {

    public Card cardToDrop;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.player.deck.Add(cardToDrop);
            gameObject.SetActive(false);
        }
    }
}
