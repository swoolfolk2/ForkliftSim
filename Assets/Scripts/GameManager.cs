using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject menuContainer;
    public GameObject gameContainer;
    void Start()
    {
        gameContainer.SetActive(true);
        menuContainer.SetActive(false);
    }
    public void SetGameContainerActive()
    {
        gameContainer.SetActive(true);
        menuContainer.SetActive(false);
    }
}
