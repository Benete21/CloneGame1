using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_MANAGER : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject playScreen;

    public void StartMenu() 
    {
        startScreen.SetActive(true);
        playScreen.SetActive(false);
    }
    
    public void StartGame()
    {
        startScreen.SetActive(false);
        playScreen.SetActive(true);
    }

    public void PlayButton()
    {
        Topdown();
    }

    public void Start()
    {
        StartMenu();
    }

    public void Topdown()
    {
        SceneManager.LoadScene("ThorisoScene");
    }

    public void BattleState()
    {
        SceneManager.LoadScene("BennettScene");
    }
}
