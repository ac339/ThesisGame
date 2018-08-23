using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * This script is repsonsible for adding a flashing colour effect to the Health Replenishing Game Power Up game object over time
 *  
 *  */
public class PowerUpHealth : MonoBehaviour {

    private float t = 0;
    private bool flag;
    public float Duration = 1f;
    // The script below linearly interpolate between two colour values over time to create a flashing colour effect over a predefined Duration of time 
    void Update () {
        gameObject.GetComponent<SpriteRenderer>().color = Color.LerpUnclamped(new Color32(255, 158, 248,255), new Color32(255, 0, 0,237), t);
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
