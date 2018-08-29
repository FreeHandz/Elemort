using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;

    public float jumpHeight;

	private bool isInAir;

    void Start() {
		isInAir = false;
    }

    void Update() {
        var x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        var jumpedButtonPressed = Input.GetButton("Jump");
		if (jumpedButtonPressed && !isInAir)
            Jump();

        transform.Translate(x, 0, 0);
    }

    private void Jump() {
        var body = GetComponent<Rigidbody2D>();
        body.velocity = new Vector2(0, jumpHeight);
		isInAir = true;
    }

	void OnCollisionEnter2D(Collision2D col)
	{
		isInAir = false;
	}

}
