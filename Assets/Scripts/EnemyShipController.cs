using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipController : MonoBehaviour
{
    public float x_speed = 44f;
    public float y_speed = 44f;
    public float attackSpeed = 5f;
    public float x_bound = -45f;
    private float x_offset;
    private float y_offset;
    private bool isSlow;
    private bool startAttack;
    private Dictionary<int, float> lanes = new Dictionary<int, float>();

    [SerializeField]
    private GameObject enemyShot;
    [SerializeField]
    private Transform attackPoint;
    public float shotTimer;
    private float currentShotTimer;
    private bool canShoot;

    public int shotsPerLane;
    public int shotsLeft;

    public float maxTimePerLane = 5f;
    private float currentTimeInLane;

    private float currentDestination;

    public int startingLane = 2;
    private int currentLane;

    private Vector3 currentPosition;

    // Start is called before the first frame update
    void Start()
    {
        isSlow = false;
        startAttack = false;
        lanes.Add(1, -5f);
        lanes.Add(2, -15f);
        lanes.Add(3, -25f);

        currentShotTimer = shotTimer;
        shotsLeft = shotsPerLane;

        currentTimeInLane = 0;

        currentLane = startingLane;
        currentPosition = gameObject.transform.position;
        currentPosition.y = lanes[currentLane];
        gameObject.transform.position = currentPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x <= 54f && !isSlow)
        {
            x_speed = attackSpeed;
            isSlow = true;
            startAttack = true;

            // ChangeLane();
        }
        if (startAttack)
        {
            Shoot();
        }
        Move();
    }

    void Move()
    {
        x_offset = Time.deltaTime * x_speed;
        gameObject.transform.Translate(-x_offset, 0, 0);
        if (transform.position.x < x_bound)
        {
            gameObject.SetActive(false);
        }
    }

    /*void MoveY(bool up)
    {
        y_offset = Time.deltaTime * y_speed;
        if (up)
        {
            gameObject.transform.Translate(0, -y_offset, 0);
        }
        else {
            gameObject.transform.Translate(0, y_offset, 0);
        }
    }*/

    void Shoot()
    {
        shotTimer += Time.deltaTime;
        if (shotTimer > currentShotTimer)
        {
            canShoot = true;
        }
        if (canShoot)
        {
            canShoot = false;
            shotTimer = 0f;
            Instantiate(enemyShot, attackPoint.position, Quaternion.identity);
        }
    }

    /*void ChangeLane()
    {
        currentTimeInLane += Time.deltaTime;
        if (currentTimeInLane >= maxTimePerLane)
        {
            int randomLane = Random.Range(1, 3);
            currentDestination = lanes[randomLane];
            if (randomLane > currentLane)
            {
                if (gameObject.transform.position.y < currentDestination)
                {
                    MoveY(false);
                }
            }
            else {
                if (gameObject.transform.position.y > currentDestination)
                {
                    MoveY(true);
                }
            }
        }
    }*/

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.transform.tag == "playerShot")
        {
            gameObject.SetActive(false);
        }
    }
}
