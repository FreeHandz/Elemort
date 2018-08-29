using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public bool useCard(CardType type)
    {
        switch (type)
        {
            case CardType.LightWeight:
                return true;
            default:
                return false;
        }
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
