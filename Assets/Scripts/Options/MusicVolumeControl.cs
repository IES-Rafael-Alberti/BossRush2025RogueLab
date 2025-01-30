using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeControl : MonoBehaviour
{
    public Slider volumeSlider; // Referencia al Slider
    public AudioSource musicSource; // Audio Source de la música

    private const string VolumePref = "MusicVolume"; // Clave para guardar el volumen

    void Start()
    {
        // Cargar volumen guardado o establecer un valor por defecto
        float savedVolume = PlayerPrefs.GetFloat(VolumePref, 0.5f);
        musicSource.volume = savedVolume;
        volumeSlider.value = savedVolume;

        // Agregar el listener al Slider
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float value)
    {
        musicSource.volume = value;
        PlayerPrefs.SetFloat(VolumePref, value); // Guardar configuración
        PlayerPrefs.Save(); // Guardar cambios
    }
}
