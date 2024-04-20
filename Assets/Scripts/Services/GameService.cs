using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameService : MonoBehaviour
{
    [SerializeField] private List<CountryData> _data = new List<CountryData>();

    [SerializeField] private TMP_Text _daysText;
    [SerializeField] private TMP_Text _inqusitionPercentText;

    [SerializeField] private int NumberOfDays;
    [SerializeField] private float InqusitionPerDay;

    public int Population => _population;

    private int _population;
    private int _currentDay;
    private float _inqusitionPerñent;

    void Awake()
    {
        foreach (var data in _data)
        {
            _population += data.Population;
        }
        _daysText.text = "0 Äåíü";
        _inqusitionPercentText.text = 0 + "%";
    }

    public void NextMove()
    {
        if (_currentDay < NumberOfDays)
        {
            _currentDay++;
            
            if (_inqusitionPerñent < 100)
            {
                _inqusitionPerñent += InqusitionPerDay;
            }
            _inqusitionPercentText.text = _inqusitionPerñent + "%";
            _daysText.text = _currentDay + " Äåíü";
        }
    }
}
