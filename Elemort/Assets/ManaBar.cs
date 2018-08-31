using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour {

	public int maxValue;
	public Slider slider;

	// Use this for initialization
	void Start () {
		slider.maxValue = GameManager.instance.player.maxMana;
	}

	// Update is called once per frame
	void Update () {
		slider.value = GameManager.instance.player.mana;
	}
}
