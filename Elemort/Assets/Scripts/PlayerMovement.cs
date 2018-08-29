using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    void Update() {
        var z = Input.GetAxis("Horizontal") * 15f;
        transform.Translate(z, 0, 0);
    }
}
