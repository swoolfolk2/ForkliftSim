using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public GameObject menuContainer;
    public GameObject gameContainer;
    public float height;
    public float liftingSpeed = 0.1f;
    public float truckSpeed = 0.5f;
    public Vector3 truckDirection;
    public float velocityConstant;

    public void pauseGame()
    {
        menuContainer.SetActive(true);
        gameContainer.SetActive(false);
    }

    public void playGame()
    {
        gameContainer.SetActive(true);
        menuContainer.SetActive(false);
    }
}
