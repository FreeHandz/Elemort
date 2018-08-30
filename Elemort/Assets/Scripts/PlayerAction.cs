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
    public bool useCard(Card card)
    {
        player.takeDamage(card.cost, true);

        switch (card.type)
        {
            case CardType.LightWeight:
                player.startLightWeight(card.duration);
                break;
            case CardType.ForcePush:
                break;
            case CardType.FireBall:
                player.fireFireball(card.duration, card.damage, DamageSourceType.Player);
                break;
            case CardType.SafeMode:
                break;
            case CardType.Draw:
                break;
            case CardType.Freeze:
                break;
            default:
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
    Freeze = 6
}
