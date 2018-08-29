using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // todo: Ezt ki kell még találni
    private const int defaultMana = 10;
    private const float defaultMass = 1;
    private const float lightWeightMass = 0.3f;

    private DateTime lightWeightUntil = DateTime.Now;

	public List<Card> deck = new List<Card>();
	public List<Card> hand = new List<Card>();

    public int mana;

    public void startLightWeight(int duration)
    {
        lightWeightUntil.AddSeconds(duration);
    }

    public void Update()
    {
        if (lightWeightUntil > DateTime.Now)
        {
            this.GetComponent<Rigidbody>().mass = lightWeightMass;
        }
        else
        {
            this.GetComponent<Rigidbody>().mass = defaultMass;
        }
    }
}
