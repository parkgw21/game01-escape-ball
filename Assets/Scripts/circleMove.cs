using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleMove : MonoBehaviour
{
    private float dirSwitch = 1.0f;

    private void Update() {
        transform.Translate(0.1f * dirSwitch, 0,0);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.name == "RightBar"){
            dirSwitch = -1.0f;
        }else if(other.transform.name == "LeftBar"){
            dirSwitch = 1.0f;
        }
    }
}
