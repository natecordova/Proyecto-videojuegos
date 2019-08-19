using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CerrarCreditos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "cerrar")
        {
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("collission");
            SceneManager.LoadScene("Main_menu");

        }
        /*else if (collision.transform.tag == "spikesfinal")
        {

            SceneManager.LoadScene("ganaste");

        }
        */

    }

}
