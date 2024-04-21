using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InqusitionService : MonoBehaviour
{
    [SerializeField] private TMP_Text _inqusitionTextNumber;
    [SerializeField] private GameObject _looseWindow;
    [SerializeField] private Image _inqusitionBar;

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
        _inqusitionBar.fillAmount = Mathf.Lerp(_inqusitionBar.fillAmount, percent, Time.deltaTime * 0.5f);
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
        else
        {
            _looseWindow.SetActive(true);
        }

        UpdateTextInqusition();
    }

    private void UpdateTextInqusition()
    {
        _inqusitionTextNumber.text = _currentPercent +" %";
    }
}
