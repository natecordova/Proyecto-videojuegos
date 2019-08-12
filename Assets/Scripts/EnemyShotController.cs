using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotController : MonoBehaviour
{
    public float xSpeed = 100f;
    public float xBound = -35f;
    private float xOffset;
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
        xOffset = Time.deltaTime * xSpeed;
        gameObject.transform.Translate(-xOffset, 0, 0);
        if (gameObject.transform.position.x < xBound)
        {
            gameObject.SetActive(false);
        }
    }
}
