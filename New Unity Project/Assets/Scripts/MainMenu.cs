using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{


    public AudioMixer AudioMixer;

    public void Update()
    {
        
    }



    public void QuitGame()
    {
        Application.Quit();
    }
    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Level2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void Level3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void Retry()
    {
        string x;
        x=PlayerPrefs.GetString("Scena");
        SceneManager.LoadScene(x);
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void GoToNextLevel()
    {
        int x;
        x = PlayerPrefs.GetInt("Nivel");
        SceneManager.LoadScene(x + 1);
    }
    public void SetVolume(float volume)
    {
        AudioMixer.SetFloat("Volume", Mathf.Log10(volume)*20);
    }
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
