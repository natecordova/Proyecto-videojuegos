using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeShipController : MonoBehaviour
{
    [SerializeField]
    private float x_speed;
    [SerializeField]
    private float warmup_speed;
    [SerializeField]
    private float max_speed;
    [SerializeField]
    private float x_bound;
    private float x_offset;
    private bool engage;
    private float warmup_start;
    private float delta_warmup;
    [SerializeField]
    private float warmup_threshold;

    // Start is called before the first frame update
    void Start()
    {
        engage = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x <= 54f && !engage) {
            x_speed = warmup_speed;
            engage = true;
            warmup_start = Time.time;
        }
        if (engage) {
            delta_warmup = Time.time - warmup_start;
            if (delta_warmup >= warmup_threshold)
            {
                x_speed = max_speed;
            }
        }
        
        Move();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.transform.tag == "playerShot")
        {
            gameObject.SetActive(false);
        }
    }

    void Move()
    {
        x_offset = Time.deltaTime * x_speed;
        gameObject.transform.Translate(x_offset, 0, 0);
        if (transform.position.x < x_bound)
        {
            gameObject.SetActive(false);
        }
    }
}
