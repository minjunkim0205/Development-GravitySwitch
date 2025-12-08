using UnityEngine;
using UnityEngine.UI;

public class BGMVolumeSlider : MonoBehaviour
{
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("BGMVolume", 1f);

        slider.value = savedVolume;

        if (BGMManager.Instance != null)
            BGMManager.Instance.SetVolume(savedVolume);

        slider.onValueChanged.AddListener(OnSliderChanged);
    }

    private void OnSliderChanged(float value)
    {
        if (BGMManager.Instance != null)
            BGMManager.Instance.SetVolume(value);
    }
}
