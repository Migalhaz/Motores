using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUIManager : MonoBehaviour
{
    bool paused;
    private void Awake()
    {
        paused = false;
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void PauseInput()
    {
        if (paused)
        {
            Unpause();
        }
        else
        {
            Pause();
        }
    }

    public void Pause()
    {
        GameManager.Instance.ButtonSFX();
        paused = true;
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Unpause()
    {
        GameManager.Instance.ButtonSFX();
        paused = false;
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        GameManager.Instance.ButtonSFX();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Cena1");
    }
}
