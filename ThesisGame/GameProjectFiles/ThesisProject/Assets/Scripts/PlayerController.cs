using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public GameObject bullet;
    public int bulletSpeed;
    public int bulletPower;

    void Start()
    {
        bulletPower = 1;
        bulletSpeed = 300;
    }
    void Update()
    {
        if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey(KeyCode.W))

     {

          gameObject.transform.Translate (Vector3.left * 0.1f);

     }

     if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))

     {

          gameObject.transform.Translate (Vector3.right * 0.1f);

     }

     if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))

     {

          gameObject.transform.Translate (Vector3.down * 0.1f);

     }

     if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))

     {

          gameObject.transform.Translate (Vector3.up * 0.1f);

     }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButton("Fire1"))

        {

            GameObject b = (GameObject)(Instantiate(bullet, transform.position + transform.up , Quaternion.identity));

            b.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed);

        }

    }


}