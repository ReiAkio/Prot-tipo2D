using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject firstButton;
    public GameObject mainMenu;
    public GameObject optionMenu;
    public GameObject firstOptionButton;
    
    public void playGame()
    {
        SceneManager.LoadScene("TestScene");
    }

    public void option()
    {
        optionMenu.SetActive(true);
        mainMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(firstOptionButton);
    }

    public void quitGame()
    {
        Application.Quit();
        Debug.Log("QUIT");
    }

    public void Update()
    {
        if (GameObject.ReferenceEquals(EventSystem.current.currentSelectedGameObject, null))
        {

            EventSystem.current.SetSelectedGameObject(firstButton);
        }

    }
}
