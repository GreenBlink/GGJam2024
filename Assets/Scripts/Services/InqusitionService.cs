using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InqusitionService : MonoBehaviour
{
    [SerializeField] private TMP_Text _inqusitionTextNumber;
    [SerializeField] private GameObject _looseWindow;
    [SerializeField] private Image _inqusitionBar;
    [SerializeField] private AudioSource _looseAudioSource;

    private float _maxPercent = 100f;
    private float _currentPercent;

    public void SetInfo(int percent)
    {
        _currentPercent = percent;

        UpdateTextInqusition();
    }

    private void Awake()
    {
        _inqusitionBar.fillAmount = 0;
    }

    private void Update()
    {
        var sectarians = _currentPercent;
        var maxpercent = _maxPercent;
        var percent = (float)sectarians / maxpercent;
        _inqusitionBar.DOFillAmount(percent, 1f);;
    }

    public void PercentChange(int value)
    {
        if (_currentPercent < _maxPercent)
        {
            _currentPercent += value;
            if (_currentPercent < 0)
            {
                _currentPercent = 0;
            }
        }
        if (_currentPercent >= _maxPercent)
        {
            _looseWindow.SetActive(true);
            _looseAudioSource.Play();
        }
        UpdateTextInqusition();
    }

    private void UpdateTextInqusition()
    {
        _inqusitionTextNumber.text = _currentPercent +" %";
    }
}
