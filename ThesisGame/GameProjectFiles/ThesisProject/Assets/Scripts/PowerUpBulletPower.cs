using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBulletPower : MonoBehaviour {

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
        gameObject.GetComponent<SpriteRenderer>().color = Color.LerpUnclamped(new Color32(255, 16, 0, 255), new Color32(121, 10, 2, 255), t);
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
