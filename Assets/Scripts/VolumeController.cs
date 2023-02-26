using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider;
    public TextMeshProUGUI volumeTextUI;



    private void Start()
    {
        LoadValues();
    }

    public void SaveVolumeButton()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadValues();
    }

    void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
        UpdateVolumeText(volumeValue);
    }

    private void UpdateVolumeText(float volume)
    {
        volumeTextUI.text = "Volume Level: " + Mathf.RoundToInt(volume * 100) + "%";
    }
}