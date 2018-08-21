using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveMover : MonoBehaviour {
    public float speed;
    public new Rigidbody2D rigidbody;
    public bool random;
    // Use this for initialization
    void Start()
    {

        if (random)
        {
            rigidbody.velocity = Random.value * transform.right * speed;
        }
        else
        {
            rigidbody.velocity = transform.right * speed;
        }
    }

        // Update is called once per frame
        void Update () {
		
	    }
}
