using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameService : MonoBehaviour
{
    [SerializeField] private List<CountryData> _data = new List<CountryData>();
    [SerializeField] private CardsService _cardService;
    [SerializeField] private TMP_Text _daysText;

    public int Population => _population;

    private int _population;
    private int _currentMove;

    void Awake()
    {
        _cardService.OnChoiceCard += ChoiceCard;
        
        CalculatePopulation();
        UpdateDays();
    }

    public void NextMove()
    {
        _currentMove++;
        _cardService.NextHand();

        UpdateDays();
    }

    private void CalculatePopulation()
    {
        foreach (var data in _data)
        {
            _population += data.Population;
        }
    }

    private void UpdateDays()
    {
        _daysText.text = _currentMove.ToString();
    }
    
    private void ChoiceCard(CardData data)
    {
        
    }
}
