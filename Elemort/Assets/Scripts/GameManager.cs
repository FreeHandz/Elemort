﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public Player player;

	public static GameManager instance;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		// scenek közötti váltáskor ne pusztuljon el ez az object, mert ez lesz a felelős a globális dolgokért
		DontDestroyOnLoad (gameObject);
	}
}
