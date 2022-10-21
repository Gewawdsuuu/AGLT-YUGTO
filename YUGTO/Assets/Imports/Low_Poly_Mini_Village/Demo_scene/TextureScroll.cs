using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScroll : MonoBehaviour
{
    public float ScrollX = 0f;
    public float ScrollY = -0.05f;

    float currentTime = 0f;
    float startingTime = 3f;
    float waveoutTime = 6f;

    private void Start()
    {
        currentTime = startingTime;

    }

    private void Update()
    {
        float OffsetX = Time.time * ScrollX;
        float OffsetY = Time.time * ScrollY;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(OffsetX, OffsetY);

        currentTime -= 1 * Time.deltaTime;

        if (currentTime <= 0)
        {
            ScrollX = -0.05f;
            ScrollY = 0.07f;
            waveoutTime -= 1 * Time.deltaTime;

            if (waveoutTime <= 0)
            {
                ScrollX = 0.02f;
                ScrollY = -0.02f;
                currentTime = startingTime;
                waveoutTime = 6f;
            }
        }
    }
}
