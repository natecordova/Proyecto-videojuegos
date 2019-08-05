using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float x_speed = 5f;
    public float x_bound = -45f;
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

    void Move()
    {
        x_offset = Time.deltaTime * x_speed;
        gameObject.transform.Translate(-x_offset, 0, 0);
        if (transform.position.x < x_bound)
        {
            gameObject.SetActive(false);
        }
    }
}
