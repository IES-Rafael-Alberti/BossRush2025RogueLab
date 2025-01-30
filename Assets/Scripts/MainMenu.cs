using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject Buttons;

    public void Play()
    {
        SceneManager.LoadScene("Demo");
    }

    public void Settings()
    {
        SaveCurrentScene();
        SceneManager.LoadScene("SettingsMenu");
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void SaveCurrentScene()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("SavedScene", sceneName);
        PlayerPrefs.Save();
        Debug.Log("Escena guardada: " + sceneName);
    }
}
