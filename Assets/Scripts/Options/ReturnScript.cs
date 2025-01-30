using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnScript : MonoBehaviour
{
    public void ReturnScene()
    {
        if (PlayerPrefs.HasKey("SavedScene"))
        {
            string lastScene = PlayerPrefs.GetString("SavedScene");
            SceneManager.LoadScene(lastScene);
        }
        else
        {
            Debug.LogWarning("No hay una escena guardada para volver.");
        }
    }
}
