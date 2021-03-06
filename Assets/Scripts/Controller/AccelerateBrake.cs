using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AccelerateBrake : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public int direction = 1;
    private bool hold = false;
    private bool friction = false;
    public Controller pausePlay;
    private float velocityConstant;
    private void Start()
    {
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
        else if (friction)
        {
            if (velocityConstant - Time.deltaTime < 0f)
            {
                velocityConstant = 0;
            }
            else
            {
                velocityConstant -= Time.deltaTime;
            }
            pausePlay.velocityConstant = velocityConstant;
        }
    }
    public void OnPointerDown(PointerEventData data)
    {
        hold = true;
        friction = false;
    }

    public void OnPointerUp(PointerEventData data)
    {
        hold = false;
        friction = true;
    }
}
