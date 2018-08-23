using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * This script is repsonsible for adding a flashing colour effect to the Bullet Damage Increase Game Power Up game object over time
 *  
 *  */
public class PowerUpBulletPower : MonoBehaviour {

    private float t = 0;
    private bool flag;
    public float Duration = 1f;
    // The script below linearly interpolate between two colour values over time to create a flashing colour effect over a predefined Duration of time 
    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.LerpUnclamped(new Color32(255, 16, 0, 255), new Color32(121, 10, 2, 255), t);
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
