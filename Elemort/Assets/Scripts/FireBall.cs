using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Damage
{
    private const float maxSpeed = 1f;

    private bool isFinished = false;

    [SerializeField]
    private int force;

    public void init(int duration, int damage, DamageSourceType source, bool isRight)
    {
        this.source = source;
        this.damageAmount = damage;
        StartCoroutine(killSelf(duration));

        Rigidbody2D rigidbody = this.gameObject.GetComponent<Rigidbody2D>();

        int modifier = isRight ? 1 : -1;

        this.transform.localRotation = new Quaternion(0,0, isRight ? 0 : 180, 0);

        rigidbody.AddForce(new Vector2(force * modifier, 0), ForceMode2D.Impulse);
    }

    IEnumerator killSelf(int duration)
    {
        yield return new WaitForSeconds(duration);

        //TODO: Create bummmmm

        Destroy(this.gameObject);
    }

    public override void damageTaken()
    {
        Destroy(this.gameObject);
    }
}
