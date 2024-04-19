using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void BackToTitle()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void ToControls()
    {
        SceneManager.LoadScene("ControlsScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}