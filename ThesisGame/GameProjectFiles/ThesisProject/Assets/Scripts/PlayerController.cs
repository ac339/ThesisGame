using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public GameObject bullet;
    public GameObject laser;
    public int bulletSpeed;
    public int bulletPower;
    public int laserSpeed;
    public int laserPower;
    public Slider bulletSpeedSlider;
    public Slider bulletPowerSlider;
    public Slider LaserBeamSlider;

    void Start()
    {
        bulletPower =(int) bulletPowerSlider.value;
        bulletSpeed =(int) bulletSpeedSlider.value;
    }
    void Update()
    {
        LaserBeamSlider.value+=Time.deltaTime;
        bulletPower = (int) bulletPowerSlider.value;
        bulletSpeed = (int) bulletSpeedSlider.value;

        if (Input.GetKey(KeyCode.F))
        {
            if (LaserBeamSlider.value > 1)
            {
                GameObject l = (GameObject)(Instantiate(laser, transform.position + transform.up, Quaternion.identity));
                l.GetComponent<Rigidbody2D>().AddForce(transform.up * 1000);
                LaserBeamSlider.value -= (float)0.5;
            }
        }

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

            if (bulletPowerSlider.value >=0 && bulletPowerSlider.value < (bulletPowerSlider.maxValue / 4))
            {
                GameObject b = (GameObject)(Instantiate(bullet, transform.position + transform.up, Quaternion.identity));
                b.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed);
            }
            if (bulletPowerSlider.value>=(bulletPowerSlider.maxValue/4) && bulletPowerSlider.value < (bulletPowerSlider.maxValue / 3))
            {
                GameObject c = (GameObject)(Instantiate(bullet, transform.position + transform.up + new Vector3(0,(float)0.1,0), Quaternion.identity));
               c.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed);
               

            }

            if (bulletPowerSlider.value >= (bulletPowerSlider.maxValue / 3) && bulletPowerSlider.value < (bulletPowerSlider.maxValue / 2))
            {
                GameObject c = (GameObject)(Instantiate(bullet, transform.position + transform.up + new Vector3(0, (float)0.1, 0), Quaternion.identity));
                c.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed);
                GameObject d = (GameObject)(Instantiate(bullet, transform.position + transform.up + new Vector3(0, (float)0.2, 0), Quaternion.identity));
                d.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed);

            }


            if (bulletPowerSlider.value >= (bulletPowerSlider.maxValue / 2) && bulletPowerSlider.value < (bulletPowerSlider.maxValue-2))
            {
                GameObject c = (GameObject)(Instantiate(bullet, transform.position + transform.up + new Vector3(0, (float)0.1, 0), Quaternion.identity));
                c.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed);
                GameObject d = (GameObject)(Instantiate(bullet, transform.position + transform.up + new Vector3(0, (float)0.2, 0), Quaternion.identity));
                d.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed);
                GameObject e = (GameObject)(Instantiate(bullet, transform.position + transform.up + new Vector3(0, (float)-0.1, 0), Quaternion.identity));
               e.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed);

            }

            if (bulletPowerSlider.value > (bulletPowerSlider.maxValue-2))
            {

              

                GameObject f = (GameObject)(Instantiate(bullet, transform.position + transform.up + new Vector3(0, (float)0.1, 0), Quaternion.identity));
                f.transform.localScale += new Vector3((float)0.3, (float)0.3, 0);
                f.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed);
               

            }


        }

    }


}