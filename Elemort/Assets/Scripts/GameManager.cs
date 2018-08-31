using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public Player player;
	public HandDisplay playerHand;
	public PlayerAction playerAction;
    public DialogueManager dialogueManager;

	public static GameManager instance;

	public List<Card> defaultDeck = new List<Card> ();
	public List<Card> defaultHand = new List<Card>();

	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		// scenek közötti váltáskor ne pusztuljon el ez az object, mert ez lesz a felelős a globális dolgokért
		DontDestroyOnLoad (gameObject);
	}

	void Start()
	{
		InitGame ();
	}

	public void InitGame()
	{
		// TODO 
	}

	public void EndGame()
	{
		Debug.Log ("player died!");
		// TODO
	}
}
