using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SacrifaicesService : MonoBehaviour
{
    [SerializeField] private TMP_Text _sacrifacesTextNumber;

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

        UpdateTextSacrifices();
    }
    
    private void UpdateTextSacrifices()
    {
        _sacrifacesTextNumber.text = _currentSacrifices + "/" + _maxSacrifices + "M";
    }
}
