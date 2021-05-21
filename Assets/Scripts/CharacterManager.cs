using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float friction;
    public Transform liftTransform;
    public float liftSpeed;
    private float velocityConstant;
    private bool isBrakePressed;
    private float translation;
    private Vector3 liftPosition;
    public void SetVelocityConstant(float rt, float lt)
    {
        if (rt > 0 && lt == 0)
        {
            velocityConstant = -rt;
        }
        else if (lt > 0 && rt == 0)
        {
            velocityConstant = lt;
        }
        else if (lt > 0 && rt > 0)
        {
            velocityConstant = 0;
        }
        else
        {
            if (velocityConstant != 0)
            {
                if (velocityConstant >= -friction / 10000 && velocityConstant <= friction / 10000)
                {
                    velocityConstant = 0;
                }
                else if (velocityConstant > 0)
                {
                    velocityConstant -= friction / 10000;
                }
                else if (velocityConstant < 0)
                {
                    velocityConstant += friction / 10000;
                }
            }
        }
    }
    public bool GetIsBrakePressed()
    {
        return isBrakePressed;
    }
    public void SetIsBrakePressed(bool isBrakePressed)
    {
        this.isBrakePressed = isBrakePressed;
    }
    void Start()
    {
        liftPosition = liftTransform.transform.position;
    }
    void Update()
    {
        if (!isBrakePressed)
        {
            Accelerate();
        }
        else
        {
            Brake();
        }
    }
    public void Rotate(float ls)
    {
        if (velocityConstant != 0)
        {
            transform.Rotate(0, ls * rotationSpeed * Time.deltaTime * Mathf.Rad2Deg, 0);
        }
    }
    public void Brake()
    {
        isBrakePressed = true;
        if (velocityConstant > 0)
        {
            velocityConstant -= 0.01f;
        }
        else if (velocityConstant < 0)
        {
            velocityConstant += 0.01f;
        }
        else
        {
            velocityConstant = 0;
        }
    }
    private void Accelerate()
    {
        translation = velocityConstant * speed * Time.deltaTime;
        transform.Translate(translation, 0, 0);
    }
}
