using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class SwipeDetector : MonoBehaviour, IPointerClickHandler, IEndDragHandler, IBeginDragHandler, IDragHandler
{
    public Controller controller;
    private Vector2 startPoint;
    private Vector2 direction;
    private Text text;
    void Start()
    {
        text = GetComponent<Text>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        text.text = "Click";
        controller.swipeDirection = 0;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPoint = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        direction = eventData.position - startPoint;
        direction = new Vector2((int)Math.Round(direction.normalized.x), (int)Math.Round(direction.normalized.y));
        if (direction.x == 0 && direction.y == 1)
        {
            text.text = "Up";
            controller.swipeDirection = 1;
        }
        else if (direction.x == 1 && direction.y == 0)
        {
            text.text = "Right";
            controller.swipeDirection = 2;
        }
        else if (direction.x == -1 && direction.y == 0)
        {
            text.text = "Left";
            controller.swipeDirection = 3;
        }
        else if (direction.x == 0 && direction.y == -1)
        {
            text.text = "Down";
            controller.swipeDirection = 4;
        }
    }
}
