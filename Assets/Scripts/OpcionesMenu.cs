using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpcionesMenu : MonoBehaviour
{
    [SerializeField] Slider VolumeSlider;
    [SerializeField] Slider SFXSlider;
    [SerializeField] AudioSource MusicAudioSource;
    [SerializeField] SFX SFX;
    [SerializeField] bool MainGame;
    [Range(0, 1)] float _currentVolumeMusic;
    [Range(0, 1)] float _currentVolumeSFX;
    string _playerPrefKeyMusic = "Volumen";
    string _playerPrefKeySFX = "SFXVolumen";


    void Awake()
    {
        if (MainGame)
        {
            try { _currentVolumeSFX = PlayerPrefs.GetFloat(_playerPrefKeySFX); }
            catch
            {
                _currentVolumeSFX = SFX.CurrentVolumen;
                PlayerPrefs.SetFloat(_playerPrefKeySFX, _currentVolumeSFX);
            }

            SFXSlider.onValueChanged.AddListener((value) => { VolumeChangeSFX(value); });
            SFXSlider.value = _currentVolumeSFX;
        }

        try { _currentVolumeMusic = PlayerPrefs.GetFloat(_playerPrefKeyMusic); }
        catch
        {
            _currentVolumeMusic = MusicAudioSource.volume;
            PlayerPrefs.SetFloat(_playerPrefKeyMusic, _currentVolumeMusic);
        }

        VolumeSlider.onValueChanged.AddListener((value) => { VolumeChangeMusic(value); });
        VolumeSlider.value = _currentVolumeMusic;

    }

    void VolumeChangeMusic(float volume)
    {
        _currentVolumeMusic = volume;
        MusicAudioSource.volume = volume;
        PlayerPrefs.SetFloat(_playerPrefKeyMusic, _currentVolumeMusic);
    }
    void VolumeChangeSFX(float volume)
    {
        _currentVolumeSFX = volume;
        SFX.CurrentVolumen=volume;
        PlayerPrefs.SetFloat(_playerPrefKeySFX, _currentVolumeSFX);
    }

    public void BackMainMenu() => SceneManager.LoadScene(0);
    public void QuitGame()=> Application.Quit();

}
