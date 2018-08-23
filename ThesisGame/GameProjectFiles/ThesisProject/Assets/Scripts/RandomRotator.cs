using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * This script is repsonsbile for adding constant random or fixed rotation to a game object
 * */
public class RandomRotator : MonoBehaviour {

    public float Speed;
    private Rigidbody2D Rigidbody2d;
    public bool IsRandom;
    private int fixedSpeed = 1;

    void Start()
    {
        Rigidbody2d = GetComponent<Rigidbody2D>();
        if (IsRandom)
            Rigidbody2d.angularVelocity = Random.value * Speed;
        else
        {
            Rigidbody2d.angularVelocity = fixedSpeed * Speed;
        }
    }
}
