using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {
	// Update is called once per frame
	void Update ()
	{
		this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x + 0.05f, this.gameObject.transform.localPosition.y, this.gameObject.transform.localPosition.z);
	}
}
