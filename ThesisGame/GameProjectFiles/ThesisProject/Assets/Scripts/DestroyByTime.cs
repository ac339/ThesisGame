using UnityEngine;
using System.Collections;
/**
 * This script destroys a game object based on the duration set in the variable Lifetime
 * Explosion Effects taken from https://unity3d.com/learn/tutorials/s/space-shooter-tutorial 
 * */
public class DestroyByTime : MonoBehaviour
{
    public float Lifetime;

    void Start()
    {
        Destroy(gameObject, Lifetime);
    }
}