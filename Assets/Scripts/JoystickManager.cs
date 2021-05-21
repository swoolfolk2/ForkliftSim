﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickManager : MonoBehaviour
{
    public CharacterManager characterManager;
    public LiftManager liftManager;
    public GameObject mainCamera;
    public GameObject secondaryCamera;
    private Vector2 rs;
    private float ls;
    private float lt;
    private float rt;
    public Vector2 GetRs()
    {
        return rs;
    }
    void Start()
    {
        mainCamera.SetActive(true);
        secondaryCamera.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Joystick1Button0))
        {
            liftManager.MoveLift(false);
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            Debug.Log("B Pressed");
            liftManager.SetIsLifted(!liftManager.GetIsLifted());
            liftManager.FixLiftedBox();
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            mainCamera.SetActive(!mainCamera.activeSelf);
            secondaryCamera.SetActive(!secondaryCamera.activeSelf);
        }
        if (Input.GetKey(KeyCode.Joystick1Button3))
        {
            liftManager.MoveLift(true);
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            characterManager.SetIsBrakePressed(true);
            characterManager.Brake();
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            Debug.Log("Start pressed");
        }
        rs = new Vector2(Input.GetAxis("RS Horizontal"), Input.GetAxis("RS Vertical"));
        ls = Input.GetAxis("LS Horizontal");
        rt = Input.GetAxis("RT");
        lt = Input.GetAxis("LT");

        if (Input.GetKeyUp(KeyCode.Joystick1Button5))
        {
            characterManager.SetIsBrakePressed(false);
        }

        if (!characterManager.GetIsBrakePressed())
        {
            characterManager.SetVelocityConstant(rt, lt);
            characterManager.Rotate(ls);
        }
    }
}
