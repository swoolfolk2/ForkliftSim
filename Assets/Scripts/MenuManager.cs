using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    public GameObject gameContainer;
    public GameObject statusContainer;
    public GameObject selectionContainer;
    public GameObject controllerContainer;
    public GameObject controllerButton;
    public GameObject statusIconButton;
    // Start is called before the first frame update
    void Start()
    {
        selectionContainer.SetActive(true);
        statusContainer.SetActive(false);
        controllerContainer.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(controllerButton);
    }
    public void SetMenuContainerActive()
    {
        gameObject.SetActive(true);
        gameContainer.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(controllerButton);
    }
    public void SetStatusIconContainerActive()
    {
        statusContainer.SetActive(true);
        selectionContainer.SetActive(false);
    }
    public void SetControllerContainerActive()
    {
        EventSystem.current.SetSelectedGameObject(null);
        controllerContainer.SetActive(true);
        selectionContainer.SetActive(false);
    }
    public void GoBack()
    {
        if (selectionContainer.activeSelf)
        {
            gameContainer.SetActive(true);
            gameObject.SetActive(false);
        }
        else if (statusContainer.activeSelf)
        {
            selectionContainer.SetActive(true);
            statusContainer.SetActive(false);
        }
        else if (controllerContainer.activeSelf)
        {
            selectionContainer.SetActive(true);
            controllerContainer.SetActive(false);
        }
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(controllerButton);
    }
}
