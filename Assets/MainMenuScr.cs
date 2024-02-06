using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string GameScene; //name of the scene is input
    public GameObject mainScreenPanel;
    public GameObject questPanel; //different panels but same scene
    public GameObject gameScene;

    private void Start()
    {
        mainScreenPanel.SetActive(true);    //when the game starts, main screen shows
        questPanel.SetActive(false);  //other panels will be set to false so that they are hidden
        
    }

    public void OnPlayButton()  //will change to a different scene of that name under variable (GameScene)
    {
        SceneManager.LoadScene("Game Screen");
    }
    public void OnQuestButton()  //switches to the screens
    {
        if (questPanel != null)
        {
            questPanel.gameObject.SetActive(true);
            mainScreenPanel.SetActive(false);

        }
    }

    public void GoHomeButton()
    {
        if (mainScreenPanel != null)
        {
            mainScreenPanel.SetActive(true);
            questPanel.SetActive(false);
        }
    }
}
