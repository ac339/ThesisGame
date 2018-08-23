using UnityEngine;
using System.Collections;
/**
 * This script allows to set a speed for a game object for traversing the screen horizontally
 * */ 
public class Mover : MonoBehaviour
{
    public float Speed;
    public new Rigidbody2D Rigidbody;
    public bool IsRandom;

    void Start()
    {
        if(IsRandom)
            Rigidbody.velocity = Random.value* transform.right * Speed;
        {
            Rigidbody.velocity =  transform.right * Speed;
        }
    }
}