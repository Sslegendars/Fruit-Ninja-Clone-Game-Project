using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*private Camera mainCamera;
    [SerializeField]
    private Blade _blade;
    private void Awake()
    {
        mainCamera = Camera.main;
    }
    private void Update()
    {
        CheckInput();
    }
    private void CheckInput()
    {
        *//*if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                 _blade.StartSlice();
            }
            else if(touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                 _blade.StopSlice();
            }
            else if (_blade.Slicing)
            {
                 _blade.ContinueSlice();
            }
        }*//*

        // Fare kontrollerini de desteklemek için
        if (Input.GetMouseButtonDown(0))
        {
            _blade.StartSlice();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _blade.StopSlice();
        }
        else if (_blade.Slicing)
        {
            _blade.ContinueSlice();
        }
    }*/
}
