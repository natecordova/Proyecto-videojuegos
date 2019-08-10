using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BaterryPoint : MonoBehaviour
{

    private static BaterryPoint instance;
    public Vector2 lastCheckPointPos;
    // Start is called before the first frame update

    // Update is called once per frame

    public int point;
    public Text pointsBaterryUI;
    void Update()
    {
        pointsBaterryUI.text = ("Point: " + point);
    }


}
