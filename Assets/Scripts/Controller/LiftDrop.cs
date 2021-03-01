using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LiftDrop : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public int direction = 1;
    private bool hold = false;
    public GameObject controller;
    private Control pausePlay;
    private float height;
    private void Start()
    {
        pausePlay = controller.GetComponent<Control>();
        pausePlay.height = 0;
    }
    private void Update()
    {
        if (hold)
        {
            height = pausePlay.height;
            height += pausePlay.liftingSpeed * direction * Time.deltaTime;
            if (height < 0f)
            {
                height = 0;
            }
            pausePlay.height = height;
        }
    }
    public void OnPointerDown(PointerEventData data)
    {
        hold = true;
    }

    public void OnPointerUp(PointerEventData data)
    {
        hold = false;

    }
}