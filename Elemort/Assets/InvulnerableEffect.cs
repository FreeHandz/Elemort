using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvulnerableEffect : MonoBehaviour {
    public SpriteRenderer spriteRenderer;
    public Color invulnerableColor;

    float effectInterval = 0.2f;

    bool isNormalColor = true;
    public int currentNumOfTimes = 0;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void StartEffect(int numOfTimes)
    {
        StartCoroutine(Effect(numOfTimes));
    }

    // bocs, cigányság kicsit
    IEnumerator Effect(int numOfTimes)
    {
        Debug.Log("hi");
        GameManager.instance.player.isInvulnerable = true;

        while(currentNumOfTimes < numOfTimes)
        {
            if (isNormalColor)
                spriteRenderer.color = invulnerableColor;
            else
                spriteRenderer.color = Color.white;

            isNormalColor = !isNormalColor;

            currentNumOfTimes += 1;

            yield return new WaitForSeconds(effectInterval);
        }

        currentNumOfTimes = 0;
        GameManager.instance.player.isInvulnerable = false;
    }
}
