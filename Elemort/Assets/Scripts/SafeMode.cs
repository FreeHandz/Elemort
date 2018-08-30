using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeMode : MonoBehaviour
{
    public void init(int duration)
    {
        StartCoroutine(killSelf(duration));
    }

    IEnumerator killSelf(int duration)
    {
        yield return new WaitForSeconds(duration);

        Destroy(this.gameObject);
    }
}
