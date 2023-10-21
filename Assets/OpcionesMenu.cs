using UnityEngine;
using UnityEngine.UI;

public class OpcionesMenu : MonoBehaviour
{
    [SerializeField] Slider VolumeSlider;
    [SerializeField] AudioSource AudioSource;

    [Range(0, 1)] float _currentVolume;
    string _playerPrefKey = "Volumen";


    public void OnEnable()
    {
        try
        {
            _currentVolume = PlayerPrefs.GetFloat(_playerPrefKey);
        }
        catch
        {
            _currentVolume = AudioSource.volume;
            PlayerPrefs.SetFloat(_playerPrefKey, _currentVolume);
        }

        AudioSource.volume = _currentVolume;
        VolumeSlider.value = _currentVolume;

        VolumeSlider.onValueChanged.RemoveAllListeners();
        VolumeSlider.onValueChanged.AddListener((value) =>
        {
            VolumeChange(value);
        });
    }
    void VolumeChange(float volume)
    {
        _currentVolume = volume;
        AudioSource.volume = volume;
        PlayerPrefs.SetFloat(_playerPrefKey, _currentVolume);
    }
}
