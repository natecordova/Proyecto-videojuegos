using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableSpeedObstacle : MonoBehaviour
{
    [SerializeField]
    private float x_speed;
    [SerializeField]
    private float max_speed;
    [SerializeField]
    private float x_bound;
    [SerializeField]
    private float x_maxspeed_start_pos;
    private float x_offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x <= x_maxspeed_start_pos) {
            x_speed = max_speed;
        }
        Move();
    }

    void Move()
    {
        x_offset = Time.deltaTime * x_speed;
        gameObject.transform.Translate(-x_offset, 0, 0);
        if (transform.position.x < x_bound) {
            gameObject.SetActive(false);
        }
    }
}
