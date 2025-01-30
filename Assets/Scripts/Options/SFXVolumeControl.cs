using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SFXVolumeControl : MonoBehaviour
{
    public Slider sfxSlider; // Referencia al Slider
    public AudioMixer audioMixer; // Audio Mixer para controlar los SFX

    private const string SFXVolumeParam = "SFXVolume"; // Nombre del par�metro en el Audio Mixer
    private const string VolumePref = "SFXVolume"; // Clave para guardar el volumen

    void Start()
    {
        // Cargar volumen guardado o establecer un valor por defecto
        float savedVolume = PlayerPrefs.GetFloat(VolumePref, 0.5f);
        sfxSlider.value = savedVolume;
        SetSFXVolume(savedVolume);

        // Agregar listener al Slider
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    public void SetSFXVolume(float value)
    {
        audioMixer.SetFloat(SFXVolumeParam, Mathf.Log10(value) * 20); // Convierte lineal a logar�tmico
        PlayerPrefs.SetFloat(VolumePref, value); // Guardar configuraci�n
        PlayerPrefs.Save(); // Guardar cambios
    }
}
