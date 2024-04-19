using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioService : MonoBehaviour
{
    [SerializeField] private AudioSource _music;
    [SerializeField] private Slider _musicSlider;

    public void OnValueChanged()
    {
        _music.volume = _musicSlider.value / 10f;
    }
}
