using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : ObjectMovement {

    private void Update() {
        int x, y = 0;
        x = (int) Input.GetAxisRaw("Horizontal");
        y = (int) Input.GetAxisRaw("Vertical");
        AttemptMove<Block>(x, y);
        // transform.Translate(x, y, 0);
    }

}
