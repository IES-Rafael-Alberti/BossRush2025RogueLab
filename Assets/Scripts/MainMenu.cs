using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject Buttons;
    public AudioSource audioSource;


    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(PlayAudio);
    }
    public void Play()
    {
        StartCoroutine(Wait());
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

    void PlayAudio()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
    }
}
