﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCredits : MonoBehaviour
{
   public float scroll_speed = 0.5f;
    private MeshRenderer mesh_renderer;
    private float y_offset;

    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        mesh_renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        y_offset = Time.time * scroll_speed;
        Vector2 offset = new Vector2(0, y_offset);
        // GetComponent<Renderer>().material.mainTextureOffset = offset;
        mesh_renderer.material.mainTextureOffset = offset;
    }
}
