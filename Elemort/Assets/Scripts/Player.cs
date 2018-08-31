using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySampleAssets._2D;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject safeModePrefab;
    [SerializeField]
    private GameObject forcePushPrefab;
    [SerializeField]
    private GameObject fireBallPrefab;
    [SerializeField]
    private GameObject heavyRainPrefab;

    // TODO: Ez nincs még settelve, ha akarjuk használni akkor setteljük
    [SerializeField]
    private Transform safeModeSlot;

    // todo: Ezt ki kell még találni
    public int defaultHealth = 20;
    private const float defaultMass = 1;
    private const float lightWeightMass = 0.6f;

    private DateTime lightWeightUntil = DateTime.Now;
    private DateTime safeModeUntil = DateTime.Now;

	public List<Card> deck = new List<Card>();
	public List<Card> hand = new List<Card>();
    public List<GameObject> currentCollisions = new List<GameObject>();
    
    private int health;

	public int maxMana;
	public int mana;

    public int Health
    {
        get { return health; }
    }

    public void startLightWeight(int duration)
    {
		lightWeightUntil = DateTime.Now.AddSeconds(duration);
    }

	void Start()
	{
		health = defaultHealth;
		mana = maxMana;
	}

    public void addMana(int mana)
    {
        if ((this.mana += mana) > maxMana)
            this.mana = maxMana;
        else
            this.mana += mana;
    }

    public void startSafeMode(int duration)
    {
		safeModeUntil = DateTime.Now.AddSeconds(duration);

        // TODO: Ha lesz használva a safemodeslot, akkor itt cseréljük ki a this transformot
        SafeMode safeMode = GameObject.Instantiate(safeModePrefab, this.transform).GetComponent<SafeMode>();

        safeMode.init(duration);
    }

    public void startForcePush()
    {
        // TODO: Ha lesz használva a safemodeslot, akkor itt cseréljük ki a this transformot
        GameObject forcePushObject = GameObject.Instantiate(forcePushPrefab, this.transform);

        ForcePush forcePush = forcePushObject.GetComponent<ForcePush>();

        bool isRight = GetComponent<PlatformerCharacter2D>().facingRight;

        forcePush.init(this.transform, isRight);
    }

    public void startHeavyRain(int duration)
    {
        // TODO: Ha lesz használva a safemodeslot, akkor itt cseréljük ki a this transformot
        GameObject heavyRainGameObject = GameObject.Instantiate(heavyRainPrefab, this.transform);

        HeavyRain forcePush = heavyRainGameObject.GetComponent<HeavyRain>();
        
        forcePush.init(this.transform, duration);
    }

    public void Update()
    {
        if (health <= 0)
        {
			GameManager.instance.EndGame ();
        }

        Rigidbody2D playersRigidbody = this.GetComponent<Rigidbody2D>();

        if (lightWeightUntil > DateTime.Now)
        {
			
            playersRigidbody.mass = lightWeightMass;
        }
        else
        {
            playersRigidbody.mass = defaultMass;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (GameObject gameObject in currentCollisions)
            {
                if (gameObject.tag.Equals("DialogueTriggerable"))
                {
                    DialogueTrigger objectTrigger = gameObject.GetComponent<DialogueTrigger>();
					if (!GameManager.instance.dialogueManager.isDialogShown) {
						Debug.Log ("trigger dialgoe");
						objectTrigger.TriggerDialogue();
					}
                }
            }
        }
    }

    public void takeDamage(int damage, bool fromCard = false)
    {
        // Player is in safe mode, cannot take any damage, except if it is from playing a card
        if (safeModeUntil > DateTime.Now && !fromCard)
            return;

        health -= damage;
        if (health <= 0)
        {
			GameManager.instance.EndGame ();
        }
    }

    public void fireFireball(int duration, int damage, DamageSourceType source)
    {
        GameObject fireBallGameObject = GameObject.Instantiate(fireBallPrefab);

        fireBallGameObject.transform.position = this.transform.position;

        FireBall fireBall = fireBallGameObject.GetComponent<FireBall>();
        fireBall.init(duration, damage, source);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        currentCollisions.Add(collision.gameObject);
        if (collision.tag == "Damage")
        {
            Damage damage = collision.gameObject.GetComponent<Damage>();

            if (damage.source == DamageSourceType.Enemy || damage.source == DamageSourceType.Other)
            {
                takeDamage(damage.damageAmount);
                damage.damageTaken();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        currentCollisions.Remove(collision.gameObject);
    }
}
