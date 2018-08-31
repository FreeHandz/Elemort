using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolingEnemy : MonoBehaviour {

	public Transform[] patrolPoints;
	public float speed = 0.1f;
	int currentPoint;

	// Use this for initialization
	void Start () {
		StartCoroutine (Patrol ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Patrol(){
		while (true) {    
			if (this.transform.position.x == patrolPoints [currentPoint].position.x) {
				currentPoint++;

				yield return new WaitForSeconds (2);

			}

			if (currentPoint >= patrolPoints.Length) {

				currentPoint = 0;   
			}

			this.transform.position = Vector2.MoveTowards (this.transform.position, new Vector2 (patrolPoints [currentPoint].position.x, transform.position.y), speed);

			if (transform.position.x > patrolPoints [currentPoint].position.x) {
				SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer> ();
				sprite.flipX = true;

			} else if (transform.position.x < patrolPoints [currentPoint].position.x) {
				SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer> ();
				sprite.flipX = false;

			}

			yield return null;
		}
	}
}
