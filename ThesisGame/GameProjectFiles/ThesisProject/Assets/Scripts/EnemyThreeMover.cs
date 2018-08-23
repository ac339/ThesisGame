using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * This script controls enemy type C movement. Enemy Type C's behaviour looks for the player's position on the screen, and then the enemies rotate around the player at a constant speed, while always locking their aim towards 
 * the player's position. Script taken and adapted from the following URL: https://answers.unity.com/questions/517868/c-how-to-make-an-object-move-toward-in-a-circular.html
 * */
public class EnemyThreeMover : MonoBehaviour {
    private float minRotationSpeed = 40.0f;
    private float maxRotationSpeed = 80.0f;
    private float minMovementSpeed = 1f;
    private float maxMovementSpeed = 1.9f;
    private float rotationSpeed = 75.0f; // Degrees per second
    private float movementSpeed = 2.0f; // Units per second;
    private Transform target;
    private Quaternion qTo;

    void Start()
    {
        target = GameObject.Find("Player").transform;
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
        movementSpeed = Random.Range(minMovementSpeed, maxMovementSpeed);
    }

    void Update()
    {
        Vector3 v3 = target.position - transform.position;
        float angle = Mathf.Atan2(v3.y, v3.x) * Mathf.Rad2Deg;
        qTo = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, qTo, rotationSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
    }
}
