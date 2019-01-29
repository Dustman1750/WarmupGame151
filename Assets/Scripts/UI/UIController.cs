using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject PauseMenu;

    public GameObject TitleSecret;

    public GameObject HowToScreen;

    public GameObject MainScreen;

    public void Title()
    {
        if(TitleSecret.activeInHierarchy)
        {
            TitleSecret.SetActive(false);
            MainScreen.SetActive(true);
        }
        else
        {
            TitleSecret.SetActive(true);

            MainScreen.SetActive(false);
        }
    }

    public void HowTo()
    {
        if (HowToScreen.activeInHierarchy)
        {
            HowToScreen.SetActive(false);
            MainScreen.SetActive(true);
        }
        else
        {
            HowToScreen.SetActive(true);
            MainScreen.SetActive(false);
        }
    }

    public void GoToStart()
    {
        SceneManager.LoadScene("Level");
    }

    public void Quit()
    {
        Maneger.Instance.Save();

        Application.Quit();

        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");

        if(Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }
    }

    public void Pause()
    {
        PauseMenu.SetActive(true);
        Debug.Log("Pause");
        Time.timeScale = .01f;
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        Debug.Log("Resume");
        Time.timeScale = 1;
    }

    public void OnDiveComplete()
    {
        Maneger.Instance.OnDiveComplete();
    }
}
