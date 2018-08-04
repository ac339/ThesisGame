using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOffScreen : MonoBehaviour {
    bool hasAppeared;
	// Use this for initialization
	void Start () {
        hasAppeared = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<Renderer>().isVisible)
        {
            hasAppeared = true;
        }

        if (hasAppeared)
        {
            if (!GetComponent<Renderer>().isVisible)
            {
                Destroy(gameObject);
            }
        }
	}
}
