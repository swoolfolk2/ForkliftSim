using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 initialPosition;
    private Vector2 bounds;

    private void Start()
    {
        initialPosition = transform.position;
        RectTransform rectTransform = GetComponent<RectTransform>();
        RectTransform parentRectTransform = rectTransform.parent.GetComponent<RectTransform>();
        bounds.x = parentRectTransform.rect.width / 3f;
        bounds.y = parentRectTransform.rect.height / 3f;
    }

    public void OnDrag(PointerEventData data)
    {
        Vector3 currPosition = transform.position;
        transform.position = new Vector3(data.position.x, data.position.y, 0);
        if (transform.localPosition.x > bounds.x || transform.localPosition.x < -1 * bounds.x)
        {
            transform.position = new Vector3(currPosition.x, transform.position.y, transform.position.z);
        }
        if (transform.localPosition.y > bounds.y || transform.localPosition.y < -1 * bounds.y)
        {
            transform.position = new Vector3(transform.position.x, currPosition.y, transform.position.z);
        }
    }

    public void OnEndDrag(PointerEventData data)
    {
        transform.position = initialPosition;
    }
}
