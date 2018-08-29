using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;

    public float jumpHeight;

    private float distanceFromGround;

    void Start() {
        distanceFromGround = GetComponent<BoxCollider2D>().bounds.extents.y;
    }

    void Update() {
        var x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        var jumpedButtonPressed = Input.GetButton("Jump");
        if (jumpedButtonPressed && IsPlayerOnGround())
            Jump();

        transform.Translate(x, 0, 0);
    }

    private void Jump() {
        Debug.Log("jumped");
        var asd = GetComponent<Rigidbody2D>();
        asd.velocity = new Vector2(0, jumpHeight);
    }

    private bool IsPlayerOnGround() {
        var dist = Physics.Raycast(transform.position, -Vector3.up, distanceFromGround + 0.1f);
        return dist;
    }

}
