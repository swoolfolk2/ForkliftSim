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

    private void Update()
    {
        if (Screen.orientation == ScreenOrientation.Landscape && !gameContainer.activeSelf)
        {
            menuContainer.SetActive(false);
            gameContainer.SetActive(true);

        }
        else if (Screen.orientation == ScreenOrientation.Portrait && !menuContainer.activeSelf)
        {
            gameContainer.SetActive(false);
            menuContainer.SetActive(true);
            text.text = "Desliza y Navega\nToca y Elije";
        }
    }

    public void pauseGame()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    public void playGame()
    {
        Screen.orientation = ScreenOrientation.Landscape;
    }
}
