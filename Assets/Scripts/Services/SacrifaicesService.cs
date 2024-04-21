using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SacrifaicesService : MonoBehaviour
{
    [SerializeField] private TMP_Text _sacrifacesTextNumber;
    [SerializeField] private GameObject _winWindowBySacriface;
    [SerializeField] private Image _sacrifaceBar;

    private int _maxSacrifices;
    private int _currentSacrifices;
    
    public void SetInfo(int maxSacrifices)
    {
        _maxSacrifices = maxSacrifices;
        
        UpdateTextSacrifices();
    }
    private void Awake()
    {
        _sacrifaceBar.fillAmount = 0;
    }

    private void Update()
    {
        var sacrifaces = _currentSacrifices;
        var population = _maxSacrifices;
        var percent = (float)sacrifaces / population;
        _sacrifaceBar.DOFillAmount(percent, 1f);
    }

    public void SacrificesChange(int value)
    {
        _currentSacrifices += value;

        if (_currentSacrifices >= _maxSacrifices)
        {
            WinBySacrifaces();
        }

        UpdateTextSacrifices();
    }
    
    private void UpdateTextSacrifices()
    {
        _sacrifacesTextNumber.text = _currentSacrifices + " / " + _maxSacrifices;
    }
    private void WinBySacrifaces()
    {
        _winWindowBySacriface.SetActive(true);
    }
}
