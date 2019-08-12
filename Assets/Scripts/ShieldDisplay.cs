using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class ShieldDisplay : MonoBehaviour
{
    public Image shieldMeterImg;
    private ShipController shipController;
    private Dictionary<int, Sprite> sprites = new Dictionary<int, Sprite>();

    // Start is called before the first frame update
    void Start()
    {
        GameObject ship = GameObject.Find("Ship");
        shipController = ship.GetComponent<ShipController>();

        shieldMeterImg.overrideSprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Sprites/shield_meter/shield_3.png", typeof(Sprite));

        for (int i = 0; i <=  3; i++)
        {
            sprites.Add(i, (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Sprites/shield_meter/shield_" + i + ".png", typeof(Sprite)));
        }
    }

    // Update is called once per frame
    void Update()
    {
        shieldMeterImg.overrideSprite = sprites[shipController.shieldCounter];
    }
}
