using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiftManager : MonoBehaviour
{
    public Transform boxesTransform;
    public Image rawImage;
    public Color defaultColor;
    public Color statusColor;
    public Color successColor;
    public float speed;
    private bool isLifted = false;
    private GameObject box;
    private Collider[] colliders;
    private float liftTranslation;
    public bool GetIsLifted()
    {
        return isLifted;
    }
    public void SetIsLifted(bool isLifted)
    {
        this.isLifted = isLifted;
    }
    public void FixLiftedBox()
    {
        if (isLifted && box != null)
        {
            box.transform.SetParent(transform);
            rawImage.color = successColor;
        }
        else if (!isLifted && box != null)
        {
            box.transform.SetParent(boxesTransform);
            box = null;
        }
        else if (isLifted && box == null)
        {
            isLifted = false;
        }
        else if (!isLifted && box == null)
        {
            rawImage.color = defaultColor;
        }
    }
    public void MoveLift(bool isUp)
    {
        if (isUp)
        {
            liftTranslation = speed * Time.deltaTime;
        }
        else
        {
            liftTranslation = -speed * Time.deltaTime;
        }
        transform.Translate(0, 0, liftTranslation);
        transform.position = transform.position;
        if (transform.position.y > 1.9)
        {
            transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        }
        else if (transform.position.y < 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }
    private void Start()
    {
        colliders = GetComponents<Collider>();
    }
    private void OnCollisionStay(Collision other)
    {
        if (box == null)
        {
            box = other.gameObject;
            rawImage.color = statusColor;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (!isLifted && box != null)
        {
            box = null;
            rawImage.color = defaultColor;
        }
    }
}
