using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;

    public float jumpHeight;

	private bool isInAir;

    private float modifiedSpeed;

    void Start() {
		isInAir = false;
        modifiedSpeed = speed;
    }

    void Update() {
        var jumpedButtonPressed = Input.GetButton("Jump");
        var x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * modifiedSpeed;
        if (jumpedButtonPressed && !isInAir)
            Jump();

        transform.Translate(x, 0, 0);
    }

    private void Jump() {
        var body = GetComponent<Rigidbody2D>();
		body.velocity = new Vector2(0, (jumpHeight * (1 / body.mass)));
        modifiedSpeed = 5;
        isInAir = true;
    }

	void OnCollisionEnter2D(Collision2D col)
	{
		isInAir = false;
        modifiedSpeed = speed;
	}

}
