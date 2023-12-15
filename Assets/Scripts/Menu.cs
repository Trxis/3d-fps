using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

        public void OnPlayButton ()
        {
        SceneManager.LoadScene(1);
        }

    public void OnQuitButton ()
    {
        Application.Quit();
        Debug.Log("You have quit this application");
    }

    public void menu()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("Menu");
    }



}
