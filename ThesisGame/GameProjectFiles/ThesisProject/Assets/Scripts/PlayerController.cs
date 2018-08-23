using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
//this class sets the invisible boundary for how far a player can move around the screen
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}
/**
 * This script is responsible for the player's spaceshp's behaviour
 * */
public class PlayerController : MonoBehaviour
{
    public  Rigidbody2D Rigidbody;
    public float Speed;
    public float Tilt;
    public Boundary Boundary;
    public Transform ShotSpawn;
    public float FireRate;
    private float nextFire;
    private GameObject bullet;
    public GameObject Laser;
    public int BulletSpeed;
    public int BulletPower;
    public float LaserPower;
    public Slider BulletSpeedSlider;
    public Slider BulletPowerSlider;
    public Slider LaserBeamSlider;
    //player details
    private GameObject gameGameController;
    private GameController gameController;
    //sound effects
    private AudioSource audioSource;
    public AudioClip SoundEffect;
    //players evolution
    private SpriteRenderer playerDesign;
    public Sprite Evolution1;
    public Sprite Evolution2;
    public Sprite Evolution3;
    public GameObject Jingle;
    private int counterOne;
    private int counterTwo;
    private int counterThree;

    //initializing variables
    void Start()
    {
        gameGameController = GameObject.FindGameObjectWithTag("GameController");
        gameController = gameGameController.GetComponent<GameController>();
        LaserPower = (int)BulletPowerSlider.value *2 * gameController.newGamePlusMultiplier;
        BulletPower =(int) BulletPowerSlider.value;
        BulletSpeed =(int) BulletSpeedSlider.value;
        playerDesign = GetComponent<SpriteRenderer>();
        counterOne = 0;
        counterTwo = 0;
  
    }

  
    void Update()
    {
        LaserPower = (int)BulletPowerSlider.value *2 * gameController.newGamePlusMultiplier; //assigning the laser to have 2x the power of bullets
        //conditions for when the player's spaceship evolves
        if ((BulletSpeedSlider.value > 0 && BulletSpeedSlider.value < (BulletSpeedSlider.maxValue / 3)) && (BulletPowerSlider.value >= 0 && BulletPowerSlider.value < (BulletPowerSlider.maxValue / 4)))
        {
            playerDesign.sprite = Evolution1;
            //destroys old polygon collider 2d mesh to add a new one to reflect the change of sprite
            Destroy(GetComponent<PolygonCollider2D>());
            gameObject.AddComponent<PolygonCollider2D>();
        }
        else if ((BulletSpeedSlider.value > (BulletSpeedSlider.maxValue / 3) && BulletSpeedSlider.value < (BulletSpeedSlider.maxValue / 3) * 2) || (BulletPowerSlider.value >= (BulletPowerSlider.maxValue / 4) && BulletPowerSlider.value < (BulletPowerSlider.maxValue / 3)))
        {
            playerDesign.sprite = Evolution2;
            if (counterOne == 0) { 
            Instantiate(Jingle, transform.position, transform.rotation);
                //destroys old polygon collider 2d mesh to add a new one to reflect the change of sprite
                Destroy(GetComponent<PolygonCollider2D>());
                gameObject.AddComponent<PolygonCollider2D>();
            }
            counterOne++;
        }
        else if ((BulletSpeedSlider.value > (BulletSpeedSlider.maxValue / 2) * 2) || (BulletPowerSlider.value >(BulletPowerSlider.maxValue / 2)))
        {
            playerDesign.sprite = Evolution3;
            if (counterTwo == 0)
            {
                Instantiate(Jingle, transform.position, transform.rotation);
                //destroys old polygon collider 2d mesh to add a new one to reflect the change of sprite
                Destroy(GetComponent<PolygonCollider2D>());
                gameObject.AddComponent<PolygonCollider2D>();
            }
            counterTwo++;
        }
     
        LaserBeamSlider.value+=Time.deltaTime; //refills the laser beam's slider over time
        BulletPower = (int) BulletPowerSlider.value;
        BulletSpeed = (int) BulletSpeedSlider.value;

        //conditions for when the player's bullet gets transformed based on speed power ups collected
        if (BulletSpeedSlider.value>0 && BulletSpeedSlider.value <( BulletSpeedSlider.maxValue/3))
        {
            bullet = (GameObject)Resources.Load("projectile", typeof(GameObject));
        }else if (BulletSpeedSlider.value > (BulletSpeedSlider.maxValue / 3) && BulletSpeedSlider.value < (BulletSpeedSlider.maxValue / 3)*2)
        {
            bullet = (GameObject)Resources.Load("projectileFast", typeof(GameObject));
        }
        else if (BulletSpeedSlider.value > (BulletSpeedSlider.maxValue / 3) * 2)
        {
            bullet = (GameObject)Resources.Load("projectileFaster", typeof(GameObject));
        }
        //controls for secondary weapon
        if (Input.GetButton("Fire2") && Time.time > nextFire)
        {
            if (LaserBeamSlider.value > 1)
            {
                nextFire = Time.time + FireRate;
                audioSource = GetComponent<AudioSource>();
                audioSource.clip = SoundEffect;
                audioSource.Play();
                GameObject l = (GameObject)(Instantiate(Laser, ShotSpawn.position + new Vector3(0, (float)0.1, 0), Quaternion.identity));
                l.GetComponent<Rigidbody2D>().AddForce(transform.up * 1000);
                LaserBeamSlider.value -= (float)2;
            }
        }

        //controls for primary weapon
        if (( Input.GetButton("Fire1")) && Time.time > nextFire)

        {
            nextFire = Time.time + FireRate;
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = SoundEffect;
            audioSource.Play();
            //conditions for when the player's bullet gets transformed based on damage power ups collected
            if (BulletPowerSlider.value >=0 && BulletPowerSlider.value < (BulletPowerSlider.maxValue / 4))
            {
                GameObject b = (GameObject)(Instantiate(bullet, ShotSpawn.position, Quaternion.identity));
                b.GetComponent<Rigidbody2D>().AddForce(transform.up * BulletSpeed);
            }

           else if (BulletPowerSlider.value >= (BulletPowerSlider.maxValue / 4) && BulletPowerSlider.value < (BulletPowerSlider.maxValue / 3))
            {
                GameObject c = (GameObject)(Instantiate(bullet, ShotSpawn.position + new Vector3(0, (float)0.1, 0), Quaternion.identity));
                c.GetComponent<Rigidbody2D>().AddForce(transform.up * BulletSpeed);
                GameObject d = (GameObject)(Instantiate(bullet, ShotSpawn.position + new Vector3(0, (float)0.2, 0), Quaternion.identity));
                d.GetComponent<Rigidbody2D>().AddForce(transform.up * BulletSpeed);

            }


            else if(BulletPowerSlider.value >= (BulletPowerSlider.maxValue / 3) && BulletPowerSlider.value < (BulletPowerSlider.maxValue/1.5))
            {
                GameObject c = (GameObject)(Instantiate(bullet, ShotSpawn.position + new Vector3(0, (float)0.1, 0), Quaternion.identity));
                c.GetComponent<Rigidbody2D>().AddForce(transform.up * BulletSpeed);
                GameObject d = (GameObject)(Instantiate(bullet, ShotSpawn.position , Quaternion.identity));
                d.GetComponent<Rigidbody2D>().AddForce(transform.up * BulletSpeed);
                GameObject e = (GameObject)(Instantiate(bullet, ShotSpawn.position + new Vector3(0, (float)-0.1, 0), Quaternion.identity));
               e.GetComponent<Rigidbody2D>().AddForce(transform.up * BulletSpeed);

            }

            else if (BulletPowerSlider.value >= (BulletPowerSlider.maxValue/1.5) && BulletPowerSlider.value < (BulletPowerSlider.maxValue))
            {

              

                GameObject f = (GameObject)(Instantiate(bullet, ShotSpawn.position + new Vector3(0, (float)0.1, 0), Quaternion.identity));
                f.transform.localScale += new Vector3((float)0.15, (float)0.15, 0);
                f.GetComponent<Rigidbody2D>().AddForce(transform.up * BulletSpeed);
               

            }
            else if (BulletPowerSlider.value == BulletPowerSlider.maxValue)
            {

                GameObject g = (GameObject)(Instantiate(bullet, ShotSpawn.position + new Vector3(0, -(float)0.2, 0), Quaternion.identity));
                GameObject h= (GameObject)(Instantiate(bullet, ShotSpawn.position + new Vector3(0, (float)0.2, 0), Quaternion.identity));
                g.transform.localScale += new Vector3((float)0.2, (float)0.2, 0);
               g.GetComponent<Rigidbody2D>().AddForce(transform.up * BulletSpeed);
               h.transform.localScale += new Vector3((float)0.2, (float)0.2, 0);
               h.GetComponent<Rigidbody2D>().AddForce(transform.up * BulletSpeed);



            }


        }

    }
    //this script controls the player's movement when the appropriate key bindings are pressed
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        Rigidbody.velocity = movement * Speed;
        float x = transform.position.x;
        float y = transform.position.y;
         Vector3 newpos= new Vector3 (Mathf.Clamp(x, Boundary.xMin, Boundary.xMax), Mathf.Clamp(y, Boundary.yMin, Boundary.yMax),transform.position.z);
        transform.position = newpos;
       transform.rotation= Quaternion.Euler(GetComponent<Rigidbody2D>().velocity.y * -Tilt, transform.rotation.y, -90);
    }


}