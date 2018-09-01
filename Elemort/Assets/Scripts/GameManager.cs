using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public Player player;
	public HandDisplay playerHand;
	public PlayerAction playerAction;
    public DialogueManager dialogueManager;
    public NewCardDisplay newCardPopup;

	public static GameManager instance;

	public List<Card> defaultDeck = new List<Card> ();
	public List<Card> defaultHand = new List<Card>();

	public Image endGameImage;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		// scenek közötti váltáskor ne pusztuljon el ez az object, mert ez lesz a felelős a globális dolgokért
		// DontDestroyOnLoad (gameObject);
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
		endGameImage.gameObject.SetActive (true);
	}

	public void StartGame()
	{
		SceneManager.LoadScene ("Elemort");
	}
}
