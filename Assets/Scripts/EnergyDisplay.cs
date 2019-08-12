using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class EnergyDisplay : MonoBehaviour
{
    public Image energyMeterImg;
    private ShipController shipController;
    private Dictionary<int, Sprite> sprites = new Dictionary<int, Sprite>();

    // Start is called before the first frame update
    void Start()
    {
        GameObject ship = GameObject.Find("Ship");
        shipController = ship.GetComponent<ShipController>();

        energyMeterImg.overrideSprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Sprites/energy_meter/energy_0.png", typeof(Sprite));

        for (int i = 0; i <= 10; i++)
        {
            sprites.Add(i, (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Sprites/energy_meter/energy_" + i + ".png", typeof(Sprite)));
        }
    }

    // Update is called once per frame
    void Update()
    {
        energyMeterImg.overrideSprite = sprites[shipController.energyCounter];
    }
}