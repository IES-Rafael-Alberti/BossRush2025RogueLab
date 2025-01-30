using UnityEngine;
using UnityEngine.UI;

public class VsyncOption : MonoBehaviour
{
    public Toggle vsyncToggle;

    void Start()
    {
        // Cargar configuración guardada
        int vsyncValue = PlayerPrefs.GetInt("VSync", 0);
        QualitySettings.vSyncCount = vsyncValue;
        vsyncToggle.isOn = (vsyncValue > 0);

        // Asignar el evento
        vsyncToggle.onValueChanged.AddListener(SetVSync);
    }

    public void SetVSync(bool isEnabled)
    {
        QualitySettings.vSyncCount = isEnabled ? 1 : 0;
        PlayerPrefs.SetInt("VSync", isEnabled ? 1 : 0);
        PlayerPrefs.Save();
    }
}
