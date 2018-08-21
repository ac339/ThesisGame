using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHealthIncrease : MonoBehaviour {

    private float t = 0;
    private bool flag;
    public float duration = 1f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.LerpUnclamped(new Color32(206,199, 255, 255), new Color32(28, 0, 255, 255), t);
        if (flag == true)
        {
            t -= Time.deltaTime / duration;
            if (t < 0.01f)
                flag = false;
        }
        else
        {
            t += Time.deltaTime / duration;
            if (t > 0.99f)
                flag = true;
        }
    }
}
