using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public Player player;

    /// <summary>
    /// Call use card method when player tries to play a card.
    /// </summary>
    /// <param name="card">Returns true, when it is a valid move to play the card, otherwise false</param>
    /// <returns></returns>
    public void useCard(Card card)
    {
		if (player.mana < card.cost) {
			return;
		}

		player.mana -= card.cost;

        switch (card.type)
        {
            case CardType.LightWeight:
                player.startLightWeight(card.duration);
                break;
            case CardType.ForcePush:
                player.startForcePush();
                break;
            case CardType.FireBall:
                player.fireFireball(card.duration, card.damage, DamageSourceType.Player);
                break;
            case CardType.SafeMode:
                GameObject.Find("ShieldSound").GetComponent<AudioSource>().Play();
                player.startSafeMode(card.duration);
                break;
            case CardType.Draw:
                //player.startDrawCard();
                break;
            case CardType.Freeze:
                break;
            case CardType.HeavyRain:
                player.startHeavyRain(card.duration);
                break;
			case CardType.Mana:
                GameObject.Find("HealManaSound").GetComponent<AudioSource>().Play();
                player.addMana(20);
				break;
			case CardType.Heal:
                GameObject.Find("HealManaSound").GetComponent<AudioSource>().Play();
                player.Heal();
				break;
            default:
                return;
        }
    }

	public bool canPlayCard(Card card)
	{
		if (player.mana < card.cost) {
			return false;
		}

		return true;
	}
}

public enum CardType
{
    LightWeight = 1,
    ForcePush = 2,
    FireBall = 3,
    SafeMode = 4,
    Draw = 5,
    Freeze = 6,
    HeavyRain = 7,
	Heal = 8,
	Mana = 9,
}
