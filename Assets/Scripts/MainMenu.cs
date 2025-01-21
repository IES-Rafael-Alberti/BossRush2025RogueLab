using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject Buttons;

    public void Play()
    {
        SceneManager.LoadScene("Arena");
    }

    public void Settings()
    {
        //Show canvas settings and to hind play and quit buttons
        Buttons.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
