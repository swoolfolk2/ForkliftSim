using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public GameObject menuContainer;
    public GameObject gameContainer;
    public float height;
    public float liftingSpeed = 0.1f;
    public float truckSpeed = 0.5f;
    public Vector3 truckDirection;
    public float velocityConstant;
    public Text text;
    public int swipeDirection = -1;

    private void Start()
    {
        Screen.orientation = ScreenOrientation.Landscape;
    }

    public void pauseGame()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        menuContainer.SetActive(true);
        gameContainer.SetActive(false);
        text.text = "Desliza y Navega\nToca y Elije";
    }

    public void playGame()
    {
        Screen.orientation = ScreenOrientation.Landscape;
        gameContainer.SetActive(true);
        menuContainer.SetActive(false);
        Debug.Log(Screen.orientation);
    }
}
