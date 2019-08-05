using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour 
{
    // Start is called before the first frame update

    // Update is called once per frame

    public int gems;
    public Text pointsGems;
    void Update()
    {
        pointsGems.text = ("Gems: " + gems);
    }
}
