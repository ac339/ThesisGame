using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

    public float speed;
    private Rigidbody2D rigidbody2d;
    public bool random;
    private int fixedspeed = 1;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        if (random)
            rigidbody2d.angularVelocity = Random.value * speed;
        else
        {
            rigidbody2d.angularVelocity = fixedspeed * speed;
        }
    }
}
