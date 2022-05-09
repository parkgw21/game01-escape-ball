using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] float speed;

    void Update()
    {
        transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
    }
}
