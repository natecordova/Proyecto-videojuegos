using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public Transform trans;
    public ShipController player;
    public float offsetY;

    private void Awake()
    {
        trans = this.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        //trans.position = new Vector3(10, 10, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPos = trans.position;
        cameraPos.x = player.gameObject.transform.position.x;
        cameraPos.y = player.gameObject.transform.position.y + offsetY;
        trans.position = cameraPos;

        //this.transform.position = player.transform.position;
    }
}
