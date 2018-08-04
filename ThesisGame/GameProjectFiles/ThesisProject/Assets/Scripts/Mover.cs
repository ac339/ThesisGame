using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    public float speed;
    public new Rigidbody2D rigidbody;
    public bool random;

    void Start()
    {
        if(random)
        rigidbody.velocity = Random.value* transform.right * speed;
        {
            rigidbody.velocity =  transform.right * speed;
        }
    }
}