using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftManager : MonoBehaviour
{
    public Transform boxesTransform;
    private bool isLifted;
    private GameObject box;
    public bool GetIsLifted()
    {
        return isLifted;
    }
    public void SetIsLifted(bool isLifted)
    {
        this.isLifted = isLifted;
    }
    void Start()
    {
    }
    void Update()
    {
        if (isLifted && box)
        {
            box.transform.SetParent(transform);
        }
        else if (!isLifted && box)
        {
            box.transform.SetParent(boxesTransform);
        }
        else if (isLifted && !box)
        {
            isLifted = false;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        box = other.gameObject;
    }
    private void OnCollisionExit(Collision other)
    {
        box = null;
    }
}
