using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Damage
{
    public void Start()
    {
        this.damageAmount = 10000;
    }

    public override void damageTaken()
    {
        return;
    }

    public void stopIt()
    {
        Destroy(gameObject);
    }
}
