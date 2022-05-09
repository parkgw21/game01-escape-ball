using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropsGenerator : MonoBehaviour
{
    [SerializeField] GameObject dropsPrefab;

    void Start() {
        // call coroutine
        StartCoroutine(CreateDrops());    
    }

    IEnumerator CreateDrops(){
        Vector3 generatePoint = new Vector3(Random.Range(-9, 10), transform.position.y, 0);
        Instantiate(dropsPrefab, generatePoint, Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(2,5));

        StartCoroutine(CreateDrops());
    }
}
