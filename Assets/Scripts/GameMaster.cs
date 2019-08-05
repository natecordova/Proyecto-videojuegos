using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour 
{

    private static GameMaster instance;
    public Vector2 lastCheckPointPos;
    // Start is called before the first frame update

    // Update is called once per frame

    public int gems;
    public Text pointsGems;
    void Update()
    {
        pointsGems.text = ("Gems: " + gems);
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
