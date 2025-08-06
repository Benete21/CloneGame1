using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_MANAGER : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject playScreen;

    [Header("Fading")]
    public Image BlackSqaure;
    public float fadeSpeed = 1f;
    public float fadelegth = 1f;
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
        SceneManager.LoadScene("BennettScene");
    }

    public void Start()
    {
        StartMenu();
    }

    public void BattleState()
    {
        SceneManager.LoadScene("BennettScene");
    }

   
    public IEnumerator FadeIn()
    {
        float elepsedtime = 0f;
        Color colour = BlackSqaure.color;
        colour.a = 0f;

        BlackSqaure.color = colour;

        while (elepsedtime < fadelegth)
        {
            colour.a = Mathf.Clamp01(elepsedtime / fadelegth);
            BlackSqaure.color = colour;
            elepsedtime += Time.deltaTime * fadeSpeed;
            yield return null;
        }

        colour.a = 1f;
        BlackSqaure.color = colour;
    }

    public IEnumerator FadeOut()
    {
        float elepsedtime = 0f;
        Color colour = BlackSqaure.color;
        colour.a = 1f;

        BlackSqaure.color = colour;

        while (elepsedtime < fadelegth)
        {
            colour.a = 1f - Mathf.Clamp01(elepsedtime / fadelegth);
            BlackSqaure.color = colour;
            elepsedtime += Time.deltaTime * fadeSpeed;
            yield return null;
        }

        colour.a = 0f;
        BlackSqaure.color = colour;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
