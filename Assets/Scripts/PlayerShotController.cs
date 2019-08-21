using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotController : MonoBehaviour
{
    public float x_speed = 100f;
    public float x_bound = 62f;
    // public float timer = 3f;
    private float x_offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "obstacle" || collision.transform.tag == "enemyShip")
        {
            gameObject.SetActive(false);
        }
    }

    void Move()
    {
        x_offset = Time.deltaTime * x_speed;
        gameObject.transform.Translate(x_offset, 0, 0);
        if (gameObject.transform.position.x > x_bound)
        {
            gameObject.SetActive(false);
        }
    }
}
