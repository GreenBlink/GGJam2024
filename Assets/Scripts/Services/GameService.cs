using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameService : MonoBehaviour
{
    [SerializeField] private List<CountryData> _data = new List<CountryData>();

    [SerializeField] private TMP_Text _daysText;

    [SerializeField] private int NumberOfDays;

    public int Population => _population;

    private int _population;
    private int _currentDay;

    void Awake()
    {
        foreach (var data in _data)
        {
            _population += data.Population;
        }
        _daysText.text = "0/10 Дней";
    }

    public void NextMove()
    {
        if (_currentDay < NumberOfDays)
        {
            _currentDay++;
            _daysText.text = _currentDay +"/10 Дней";
        }
    }
}
