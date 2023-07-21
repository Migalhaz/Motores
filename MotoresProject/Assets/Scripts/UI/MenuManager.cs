using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : Singleton<MenuManager>
{
    private void Start()
    {
        Time.timeScale = 1f;
    }
    public void Play()
    {
        SceneManager.LoadScene("Cena1");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
