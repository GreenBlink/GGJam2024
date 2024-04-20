using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InqusitionService : MonoBehaviour
{
    [SerializeField] private TMP_Text _inqusitionTextNumber;

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
        }

        UpdateTextInqusition();
    }

    private void UpdateTextInqusition()
    {
        _inqusitionTextNumber.text = _currentPercent +" %";
    }
}
