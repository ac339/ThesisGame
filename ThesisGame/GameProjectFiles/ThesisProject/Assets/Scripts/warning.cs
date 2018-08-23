using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * This script is responsible for changing the size in scale and colour of the warning sign that appears before wormholes are spawned
 * */

public class warning : MonoBehaviour {


    private float t = 0;
    private bool flag;
    public float Duration = 1f;
    // Use this for initialization
    void Start()
    {

    }

    // The script below linearly interpolate between two colour values and scale of the size of the game object over time to create a flashing colour effect over a predefined Duration of time 
    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.LerpUnclamped(new Color32(255, 255,255, 255), new Color32(255, 0, 0, 255), t);
        gameObject.transform.localScale = Vector3.LerpUnclamped(new Vector3(0.01f, 0.01f, 1), new Vector3(0.1f, 0.1f, 1), t);
        if (flag == true)
        {
            t -= Time.deltaTime / Duration;
            if (t < 0.01f)
                flag = false;
        }
        else
        {
            t += Time.deltaTime / Duration;
            if (t > 0.99f)
                flag = true;
        }
    }
}
