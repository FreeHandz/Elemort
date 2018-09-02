using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPile : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GroundNoise"))
        {
            GameObject.Find("FallingSound").GetComponent<AudioSource>().Play();
        }
    }
}
