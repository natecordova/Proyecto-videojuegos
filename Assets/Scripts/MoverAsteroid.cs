using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverAsteroid : MonoBehaviour
{
    
    public float Speed = 1.0f;
    // Start is called before the first frame update
    void Awake()
    {
       
    }

    // Update is called once per frame
   

    void Update()
    {
        transform.Translate(Vector3.left  * Speed * Time.deltaTime);
    }
}
