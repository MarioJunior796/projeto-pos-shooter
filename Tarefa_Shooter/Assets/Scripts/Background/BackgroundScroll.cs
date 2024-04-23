using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeed = 0.1f;
    private float xScroll;
    private MeshRenderer mesh_Renderer;

    void Start()
    {
        mesh_Renderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        ScrollBackground();
    }

    private void ScrollBackground()
    {
        xScroll = Time.time * scrollSpeed;

        Vector2 offSet = new Vector2(xScroll, 0f);
        mesh_Renderer.sharedMaterial.SetTextureOffset("_MainTex", offSet);
    }
}
