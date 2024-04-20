using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SacrifaicesService : MonoBehaviour
{
    [SerializeField] private TMP_Text _sacrifacesTextNumber;
    [SerializeField] private GameObject _winWindowBySacriface;

    private int _maxSacrifices;
    private int _currentSacrifices;
    
    public void SetInfo(int maxSacrifices)
    {
        _maxSacrifices = maxSacrifices;
        
        UpdateTextSacrifices();
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
        _sacrifacesTextNumber.text = _currentSacrifices + "/" + _maxSacrifices + "M";
    }
    private void WinBySacrifaces()
    {
        _winWindowBySacriface.SetActive(true);
    }
}
