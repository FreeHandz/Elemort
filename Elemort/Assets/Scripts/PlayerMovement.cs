using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;

    void Start() {

    }

    void Update() {
        var x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        transform.Translate(x, 0, 0);
    }

}
