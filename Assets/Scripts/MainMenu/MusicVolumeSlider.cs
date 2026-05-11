using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeSlider : MonoBehaviour
{
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Start()
    {
        if (MusicManager.Instance != null)
        {
            slider.value = MusicManager.Instance.GetMusicVolume();
            slider.onValueChanged.AddListener(MusicManager.Instance.SetMusicVolume);
        }
    }

    private void OnDestroy()
    {
        if (MusicManager.Instance != null && slider != null)
        {
            slider.onValueChanged.RemoveListener(MusicManager.Instance.SetMusicVolume);
        }
    }
}