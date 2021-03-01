using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AccelerateBrake : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public int direction = 1;
    private bool hold = false;
    public GameObject controller;
    private Control pausePlay;
    private float velocityConstant;
    private void Start()
    {
        pausePlay = controller.GetComponent<Control>();
        pausePlay.velocityConstant = 0;
    }
    private void Update()
    {
        if (hold)
        {
            velocityConstant = pausePlay.velocityConstant;
            velocityConstant += pausePlay.truckSpeed * direction * Time.deltaTime;
            if (velocityConstant < 0f)
            {
                velocityConstant = 0;
            }
            pausePlay.velocityConstant = velocityConstant;
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
