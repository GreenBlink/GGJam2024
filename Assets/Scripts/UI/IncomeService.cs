using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IncomeService : MonoBehaviour
{
    [SerializeField] private TMP_Text _sectariansTextNumber;
    [SerializeField] private TMP_Text _sacrifacesTextNumber;

    [SerializeField] private List<CountryData> _data = new List<CountryData>();

    [SerializeField] private int _population;

    private int _currentSectarians;
    private int _currentSacrifaices;

    public event Action OnSectariansChanged;
    public event Action OnSacrifaicesChanged;

    void Start()
    {
        foreach (var data in _data)
        {
            _population += data.Population;
        }
        _sectariansTextNumber.text = _currentSectarians.ToString() + "/" + _population.ToString() + "M";
        _sacrifacesTextNumber.text = _currentSacrifaices.ToString() + "/" + _population.ToString() + "M";
    }
 
}
