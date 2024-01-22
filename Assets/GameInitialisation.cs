using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameInitialisation : MonoBehaviour
{
    public string MainMenuScene;
    public GameObject meep;
    public GameObject canvasUI;
    public GameObject keybinds;
    public GameObject continueText;

    private void Start()
    {
        canvasUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1)) 
        {
            canvasUI.SetActive(true);
            keybinds.SetActive(false);
            continueText.SetActive(false);
        }
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene(MainMenuScene);
    }

    
}
