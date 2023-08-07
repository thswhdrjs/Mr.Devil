using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPS_TextMeshPro : MonoBehaviour
{
    private TextMeshPro tmp;

    private string text;

    private float deltaTime;
    private float msec;

    private float fps;

    private void Start()
    {
        tmp = GetComponent<TextMeshPro>();

        deltaTime = 0.0f;
    }

    private void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;

        msec = deltaTime * 1000.0f;
        fps = 1.0f / deltaTime;

        text = fps.ToString("F1") + "FPS";
        tmp.text = text;
    }
}
