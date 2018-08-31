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
    private List<int> pushableLayers;

    public void init(Transform player, bool toRight)
    {
        pushItRealGood(player, toRight);
    }

    public void pushItRealGood(Transform player, bool toRight)
    {
        var movablesInRadius = Physics2D.OverlapCircleAll(player.position, radius);

        Debug.Log("Movable objects : " + movablesInRadius.Length);

        foreach (var movable in movablesInRadius)
        {
            bool isMovable = doesContainLayer(movable.gameObject.layer);

            Debug.Log("Is movable: " + (isMovable ? movable.gameObject.name : "no"));

            if (!isMovable)
                continue;

            Transform other = movable.transform;

            float modifier = toRight ? 1f : -1f;

            Vector2 aimDirection = new Vector2(player.position.x + modifier, 0).normalized;
            Vector2 playerToTargetVector = (other.position - player.position).normalized;

            float distance = Vector2.Distance(player.transform.position, other.transform.position);

            Debug.DrawLine(Vector3.zero, new Vector3(other.position.x, other.position.y, 0), Color.red, 10000);
            Debug.DrawLine(Vector3.zero, new Vector3(aimDirection.x, aimDirection.y, 0), Color.blue, 10000);

            float angle1 = Vector2.Angle(aimDirection, playerToTargetVector);
            float angle2 = Vector2.Angle(playerToTargetVector, aimDirection);

            angle1 = Mathf.Abs(90f - angle1);
            angle2 = Mathf.Abs(90f - angle2);

            float finalAngle = Mathf.Min(angle1, angle2);

            Debug.Log("Angle is greater : " + (finalAngle >= pushPullConeAngle) + " | Current angle is : " + finalAngle);

            if (finalAngle >= pushPullConeAngle)
                continue;

            var rb2d = other.GetComponent<Rigidbody2D>();

            if (rb2d)
                rb2d.AddForce(playerToTargetVector.normalized * force, ForceMode2D.Impulse);
            else
                Debug.LogFormat("Target does not have rigidbody2d");
        }
    }

    private bool doesContainLayer(int layerNum)
    {
        for (int i = 0; i < pushableLayers.Count; i++)
        {
            if (pushableLayers[i] == layerNum)
                return true;
        }

        return false;
    }
}
