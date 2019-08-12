using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipController : MonoBehaviour

{
    public float speedX;
    public float speedY;
    private GameMaster gameMaster;

    // Start is called before the first frame update
    void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        transform.position = gameMaster.lastCheckPointPos;
    }

    // Update is called once per frame
    void Update()
    {
        // Movimiento automático en eje X
        gameObject.transform.Translate(speedX * Time.deltaTime, 0, 0);

        if (Input.GetKey("up"))
        {
            gameObject.transform.Translate(0, speedY * Time.deltaTime, 0);
        }
        else if (Input.GetKey("down"))
        {
            gameObject.transform.Translate(0, -speedY * Time.deltaTime, 0);
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
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag == "spikes") {
           // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("collission");
            SceneManager.LoadScene("menu");

         } else if (collision.transform.tag == "spikesfinal") {

            SceneManager.LoadScene("ganaste");

        }   

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        


        if (collision.CompareTag("gems")) {
            Destroy(collision.gameObject);
            gameMaster.gems +=1;
        }
    }
}
