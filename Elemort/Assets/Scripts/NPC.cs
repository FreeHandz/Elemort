﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    public SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
        sprite.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            sprite.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
		GameManager.instance.dialogueManager.EndDialogue ();
        if (collision.gameObject.CompareTag("Player"))
            sprite.enabled = false;
    }
}
