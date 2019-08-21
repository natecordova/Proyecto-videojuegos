using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndController : MonoBehaviour
{

    Text flashingText;
    public string next_scene;

    // Start is called before the first frame update
    void Start()
    {
        flashingText = GetComponent<Text>();
        //Call coroutine BlinkText on Start
        StartCoroutine(BlinkText());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("x"))
        {
            SceneManager.LoadScene(next_scene);
        }
    }

    public IEnumerator BlinkText()
    {
        //blink it forever. You can set a terminating condition depending upon your requirement
        while (true)
        {
            //set the Text's text to blank
            flashingText.text = "";
            //display blank text for 0.5 seconds
            yield return new WaitForSeconds(.5f);
            //display “I AM FLASHING TEXT” for the next 0.5 seconds
            flashingText.text = "Press X to continue";
            yield return new WaitForSeconds(.5f);
        }
    }
}
