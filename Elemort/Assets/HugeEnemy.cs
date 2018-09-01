using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugeEnemy : MonoBehaviour {

    private bool isFallen = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (gameObject.GetComponent<Enemy>().health <= 20 && !isFallen)
        {
            isFallen = true;

            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            gameObject.GetComponent<PatrolingEnemy>().speed = 0;
        }
	}
}
