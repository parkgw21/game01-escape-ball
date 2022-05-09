using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropsController : MonoBehaviour
{
    [SerializeField] float speed;

    private void Update()
    {
        transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;

        if(transform.position.y == -10){
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.CompareTag("Player")){
            Destroy(gameObject);
        }
    }
}
