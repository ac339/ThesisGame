using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * This script is repsonsible for adding a flashing colour effect to the Epic Game Power Up game object over time
 *  
 *  */

public class PowerUpEpic : MonoBehaviour {

    private float t = 0;
    private bool flag;
    public float Duration = 1f;


    // The script below linearly interpolate between two colour values over time to create a flashing colour effect over a predefined Duration of time 
    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.LerpUnclamped(new Color32(0,255,241, 255), new Color32(255, 255, 0, 255), t);
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
