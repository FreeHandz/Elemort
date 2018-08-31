using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyRain : MonoBehaviour
{
    [SerializeField]
    private float radius;

    public void init(Transform player, int duration)
    {
        stopAllFireInCircle(player);

        StartCoroutine(killSelf(duration));
    }

    private void stopAllFireInCircle(Transform player)
    {
        Vector2 size = new Vector2(radius,radius);
        var objectsWithinRadius = Physics2D.OverlapBoxAll(player.position, size, 0);

        for (int i = 0; i < objectsWithinRadius.Length; i++)
        {
            var fireObject = objectsWithinRadius[i].GetComponent<Fire>();

            if(fireObject == null)
                continue;

            fireObject.stopIt();
        }
    }

    IEnumerator killSelf(int duration)
    {
        yield return new WaitForSeconds(duration);

        Destroy(this.gameObject);
    }
}
