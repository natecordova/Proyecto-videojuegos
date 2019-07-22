using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public ShipController ship;
    public float offsetX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newCameraPosition = gameObject.transform.position;
        newCameraPosition.x = ship.gameObject.transform.position.x + offsetX;
        gameObject.transform.position = newCameraPosition;
    }
}
