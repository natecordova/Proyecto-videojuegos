using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipController : MonoBehaviour

{
    // public float speedX;
    [SerializeField]
    private float speedY;
    // private BaterryPoint point;
    public int energyCounter = 0;
    public int shieldCounter;
    [SerializeField]
    private GameObject playerShot;
    [SerializeField]
    private Transform attackPoint;
    private float yNegative = 27f;
    private float yPositive = -1.4f;
    public float shotTimer = 2f;
    private float currentShotTimer;
    private bool canShoot;

    // Start is called before the first frame update
    void Start()
    {
        // point = GameObject.FindGameObjectWithTag("pointBatery").GetComponent<BaterryPoint>();
        currentShotTimer = shotTimer;
        shieldCounter = 4;
    }

    // Update is called once per frame
    void Update()
    {
        // Movimiento automático en eje X
        // gameObject.transform.Translate(speedX * Time.deltaTime, 0, 0);

        if (Input.GetKey("up"))
        {
            gameObject.transform.Translate(0, speedY * Time.deltaTime, 0);
        }
        else if (Input.GetKey("down"))
        {
            gameObject.transform.Translate(0, -speedY * Time.deltaTime, 0);
        }
        if (gameObject.transform.position.y < -yNegative) {
            transform.position = new Vector2(transform.position.x, -yNegative);
        }
        if (gameObject.transform.position.y > yPositive)
        {
            transform.position = new Vector2(transform.position.x, yPositive);
        }


      


        /*else if (Input.GetKey("left"))
        {
            if (gameObject.transform.eulerAngles.z != 0)
            {
                gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            }
            gameObject.transform.localScale = new Vector3(-1.5F, 1.5F, 1.5F);
            gameObject.transform.Translate(-5 * Time.deltaTime, 0, 0);
        }*/
        /*else if (Input.GetKey("right"))
        {
            if (gameObject.transform.eulerAngles.z != 0)
            {
                gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            }
            gameObject.transform.localScale = new Vector3(1.5F, 1.5F, 1.5F);
            gameObject.transform.Translate(5 * Time.deltaTime, 0, 0);
        }*/
        Shoot();
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
       

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "obstacle" || collision.transform.tag == "enemyShot") {
            shieldCounter--;
            if (shieldCounter == 0)
            {
                SceneManager.LoadScene("level_1");
            }
        } else if (collision.transform.tag == "battery")
        {
            Destroy(collision.gameObject);
            if (energyCounter < 10)
            {
                energyCounter++;
            }
            Debug.Log("energy: " + energyCounter);
        }
    }

    void Shoot()
    {
        shotTimer += Time.deltaTime;
        if (shotTimer > currentShotTimer)
        {
            canShoot = true;
        }
        if (Input.GetKeyDown("z"))
        {
            if (canShoot && energyCounter > 0)
            {
                canShoot = false;
                shotTimer = 0f;
                energyCounter--;
                Instantiate(playerShot, attackPoint.position, Quaternion.identity);
            }
        }
    }
}
