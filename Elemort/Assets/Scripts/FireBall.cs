using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Damage
{
    private const float maxSpeed = 1f;

    private bool isFinished = false;

    [SerializeField]
    private int force;

    public void init(int duration, int damage)
    {
        this.damage = damage;
        StartCoroutine(killSelf(duration));

        Rigidbody rigidbody = this.gameObject.GetComponent<Rigidbody>();

        rigidbody.AddForce(new Vector3(force, 0, 0), ForceMode.Impulse);
    }

    IEnumerator killSelf(int duration)
    {
        yield return new WaitForSeconds(duration);

        //TODO: Create bummmmm

        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
    }
}
