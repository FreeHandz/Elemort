using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePush : MonoBehaviour
{
    // Effective range of the spell
    [Range(0f, 15f)]
    [SerializeField]
    private float radius = 5f;

    // Angle for the cone used when casting push and pull
    [Range(0f, 359.99999f)]
    [SerializeField]
    private float pushPullConeAngle;

    [SerializeField]
    private int force;

    [SerializeField]
    private List<LayerMask> pushableLayers;

    public void init(Transform player, bool toRight)
    {
        pushItRealGood(player, toRight);
    }

    public void pushItRealGood(Transform player, bool toRight)
    {
        var movablesInRadius = Physics2D.OverlapCircleAll(player.position, radius);

        foreach (var movable in movablesInRadius)
        {
            bool isMovable = doesContainLayer(movable.gameObject.layer);

            if (!isMovable)
                continue;

            Transform other = movable.transform;

            float modifier = toRight ? 1f : -1f;

            Vector2 aimDirection = new Vector2(player.position.x + modifier, player.position.y).normalized;
            Vector2 playerToTargetVector = (other.position - player.position).normalized;

            float distance = Vector2.Distance(player.transform.position, other.transform.position);
            float angle = Vector2.Angle(playerToTargetVector, player.right);

            if (angle >= pushPullConeAngle)
                continue;

            if (distance >= radius)
                continue;

            var rb2d = other.GetComponent<Rigidbody2D>();

            if (rb2d)
                rb2d.AddForce(playerToTargetVector, ForceMode2D.Impulse);
            else
                Debug.LogFormat("Target does not have rigidbody2d");
        }
    }

    private bool doesContainLayer(int layerNum)
    {
        for (int i = 0; i < pushableLayers.Count; i++)
        {
            if (pushableLayers[i].value == layerNum)
                return true;
        }

        return false;
    }
}
