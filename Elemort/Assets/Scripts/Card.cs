using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



// ezáltal lesz létrehozható egy ilyen object az editorból
// jobb klikk -> new card, és kész is
// gecijó
[CreateAssetMenu(fileName = "New Card", menuName = "Cards")]
public class Card: ScriptableObject {

	public enum ElementType {
		fire = 1,
		water = 2,
		earth = 3,
		wind = 4
	}

	public new string name;
	public string description;

	public Image artWork;
	public int manaCost;

	public ElementType elementType;
	// ez egy nagy nagy enum
	public string type;
}
