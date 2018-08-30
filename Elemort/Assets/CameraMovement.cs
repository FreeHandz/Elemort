using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public Vector3 offset;

	void Start ()
	{
		offset = transform.position - GameManager.instance.player.transform.position;
		offset.x = 0.45f;
		offset.y = -1.5f;
	}

	void LateUpdate ()
	{
		transform.position = GameManager.instance.player.transform.position + offset;
	}
}
