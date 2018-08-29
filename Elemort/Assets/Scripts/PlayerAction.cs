using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public Player player;

    public bool useCard(Card card)
    {
        if (player.mana < card.manaCost)
        {
            return false;
        }

        player.mana -= card.manaCost;

        switch (card.type)
        {
            case CardType.LightWeight:
                player.startLightWeight(card.duration);
                break;
            case CardType.ForcePush:
                break;
            case CardType.FireBall:
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
