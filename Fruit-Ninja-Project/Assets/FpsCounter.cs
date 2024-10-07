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
        // Delta zamaný güncelle
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

        // FPS deðerini hesapla
        float fps = 1.0f / deltaTime;

        // FPS deðerini UI'da göster


        // Konsola yazdýrmak isterseniz
        Debug.Log("FPS: " + Mathf.Ceil(fps));
    }
}