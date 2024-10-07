using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsCounter : MonoBehaviour
{
    private float deltaTime = 0.0f;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        // Delta zaman� g�ncelle
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

        // FPS de�erini hesapla
        float fps = 1.0f / deltaTime;

        // FPS de�erini UI'da g�ster


        // Konsola yazd�rmak isterseniz
        Debug.Log("FPS: " + Mathf.Ceil(fps));
    }
}