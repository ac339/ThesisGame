using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSpaceShipMover : MonoBehaviour {

    public float speed;
    public new Rigidbody2D rigidbody;
    public bool random;

    void Start()
    {
        if (random)
            rigidbody.velocity = Random.value * transform.right * speed;
        {
            rigidbody.velocity = transform.up * speed;
        }
    }
}