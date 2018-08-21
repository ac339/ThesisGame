using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour
{
    public  Rigidbody2D rigidbody;
    public float speed;
    public float tilt;
    public Boundary boundary;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;
    private GameObject bullet;
    public GameObject laser;
    public int bulletSpeed;
    public int bulletPower;
    public float laserPower;
    public Slider bulletSpeedSlider;
    public Slider bulletPowerSlider;
    public Slider LaserBeamSlider;
    //player details
    private GameObject gameGameController;
    private GameController gameController;
    //sound effects
    private AudioSource audioSource;
    public AudioClip soundeffect;

    void Start()
    {
        gameGameController = GameObject.FindGameObjectWithTag("GameController");
        gameController = gameGameController.GetComponent<GameController>();
        laserPower = (int)bulletPowerSlider.value + 2.5f * gameController.newGamePlusMultiplier;
        bulletPower =(int) bulletPowerSlider.value;
        bulletSpeed =(int) bulletSpeedSlider.value;
    }

  
    void Update()
    {
       
     
        LaserBeamSlider.value+=Time.deltaTime;
        bulletPower = (int) bulletPowerSlider.value;
        bulletSpeed = (int) bulletSpeedSlider.value;
        //increase sliders in NG+
      /* if (gameController.newGamePlusMultiplier > 1) { 
        bulletSpeedSlider.maxValue = bulletSpeedSlider.maxValue * (1+(gameController.newGamePlusMultiplier/10));
        bulletPowerSlider.maxValue = bulletPowerSlider.maxValue * (1 + (gameController.newGamePlusMultiplier / 10));
       LaserBeamSlider.maxValue = LaserBeamSlider.maxValue * (1 + (gameController.newGamePlusMultiplier / 10));
        }*/

        if (bulletSpeedSlider.value>0 && bulletSpeedSlider.value < 500)
        {
            bullet = (GameObject)Resources.Load("projectile", typeof(GameObject));
        }else if (bulletSpeedSlider.value >500 && bulletSpeedSlider.value < 800)
        {
            bullet = (GameObject)Resources.Load("projectileFast", typeof(GameObject));
        }
        else if (bulletSpeedSlider.value > 800 )
        {
            bullet = (GameObject)Resources.Load("projectileFaster", typeof(GameObject));
        }

        if (Input.GetKey(KeyCode.F) && Time.time > nextFire)
        {
            if (LaserBeamSlider.value > 1)
            {
                nextFire = Time.time + fireRate;
                audioSource = GetComponent<AudioSource>();
                audioSource.clip = soundeffect;
                audioSource.Play();
                GameObject l = (GameObject)(Instantiate(laser, shotSpawn.position + new Vector3(0, (float)0.1, 0), Quaternion.identity));
                l.GetComponent<Rigidbody2D>().AddForce(transform.up * 1000);
                LaserBeamSlider.value -= (float)2;
            }
        }

       /* if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey(KeyCode.W))

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

     }*/

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetButton("Fire1")) && Time.time > nextFire)

        {
            nextFire = Time.time + fireRate;
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = soundeffect;
            audioSource.Play();
            if (bulletPowerSlider.value >=0 && bulletPowerSlider.value < (bulletPowerSlider.maxValue / 4))
            {
                GameObject b = (GameObject)(Instantiate(bullet, shotSpawn.position, Quaternion.identity));
                b.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed);
            }

           else if (bulletPowerSlider.value >= (bulletPowerSlider.maxValue / 4) && bulletPowerSlider.value < (bulletPowerSlider.maxValue / 3))
            {
                GameObject c = (GameObject)(Instantiate(bullet, shotSpawn.position + new Vector3(0, (float)0.1, 0), Quaternion.identity));
                c.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed);
                GameObject d = (GameObject)(Instantiate(bullet, shotSpawn.position + new Vector3(0, (float)0.2, 0), Quaternion.identity));
                d.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed);

            }


            else if(bulletPowerSlider.value >= (bulletPowerSlider.maxValue / 3) && bulletPowerSlider.value < (bulletPowerSlider.maxValue/1.5))
            {
                GameObject c = (GameObject)(Instantiate(bullet, shotSpawn.position + new Vector3(0, (float)0.1, 0), Quaternion.identity));
                c.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed);
                GameObject d = (GameObject)(Instantiate(bullet, shotSpawn.position , Quaternion.identity));
                d.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed);
                GameObject e = (GameObject)(Instantiate(bullet, shotSpawn.position + new Vector3(0, (float)-0.1, 0), Quaternion.identity));
               e.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed);

            }

            else if (bulletPowerSlider.value >= (bulletPowerSlider.maxValue/1.5) && bulletPowerSlider.value < (bulletPowerSlider.maxValue))
            {

              

                GameObject f = (GameObject)(Instantiate(bullet, shotSpawn.position + new Vector3(0, (float)0.1, 0), Quaternion.identity));
                f.transform.localScale += new Vector3((float)0.3, (float)0.3, 0);
                f.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed);
               

            }
            else if (bulletPowerSlider.value == bulletPowerSlider.maxValue)
            {



                GameObject g = (GameObject)(Instantiate(bullet, shotSpawn.position + new Vector3(0, -(float)0.2, 0), Quaternion.identity));
                GameObject h= (GameObject)(Instantiate(bullet, shotSpawn.position + new Vector3(0, (float)0.2, 0), Quaternion.identity));
                g.transform.localScale += new Vector3((float)0.3, (float)0.3, 0);
               g.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed);
               h.transform.localScale += new Vector3((float)0.3, (float)0.3, 0);
               h.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed);



            }


        }

    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rigidbody.velocity = movement * speed;
        float x = transform.position.x;
        float y = transform.position.y;
         Vector3 newpos= new Vector3 (Mathf.Clamp(x, boundary.xMin, boundary.xMax), Mathf.Clamp(y, boundary.yMin, boundary.yMax),transform.position.z);
        transform.position = newpos;
       transform.rotation= Quaternion.Euler(GetComponent<Rigidbody2D>().velocity.y * -tilt, transform.rotation.y, -90);
    }


}