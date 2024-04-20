using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InqusitionService : MonoBehaviour
{
    [SerializeField] private TMP_Text _inqusitionTextNumber;
    [SerializeField] private GameObject _looseWindow;

    private float _maxPercent = 100f;
    private float _currentPercent;

    public void SetInfo(int percent)
    {
        _currentPercent = percent;

        UpdateTextInqusition();
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
