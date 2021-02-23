using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRotate : MonoBehaviour
{
    // This rotates the pickup object in some random direction

    private float rand_x;
    private float rand_y;
    private float rand_z;

    void Start()
    {
        rand_x = Random.value >= 0.5f? Random.Range(45.0f, 60.0f)*Time.deltaTime: Random.Range(-60.0f, -45.0f)*Time.deltaTime;
        rand_y = Random.value >= 0.5f? Random.Range(45.0f, 60.0f)*Time.deltaTime: Random.Range(-60.0f, -45.0f)*Time.deltaTime;
        rand_z = Random.value >= 0.5f? Random.Range(45.0f, 60.0f)*Time.deltaTime: Random.Range(-60.0f, -45.0f)*Time.deltaTime;
    }

    void Update()
    {
        transform.Rotate(rand_x,rand_y,rand_z);
    }
}
