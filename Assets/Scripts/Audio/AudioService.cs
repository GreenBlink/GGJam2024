using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioService : MonoBehaviour
{
    [SerializeField] private AudioSource _music;
    [SerializeField] private Slider _musicSlider;

    private float _volume;

    private void Start()
    {
        LoadGame();
    }

    public void OnValueChanged()
    {
        _music.volume = _musicSlider.value / 10f;
        _volume = _music.volume;
        SaveData();
    }

    public void SaveData()
    {
        _volume = _music.volume;
        PlayerPrefs.SetFloat("Volume", _volume);
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            _music.volume = PlayerPrefs.GetFloat("Volume");
            _musicSlider.value = _music.volume * 10f;
        }
        else
            Debug.LogWarning("There is no save data!");
    }
}
