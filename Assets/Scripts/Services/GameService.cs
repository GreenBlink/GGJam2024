using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameService : MonoBehaviour
{
    [SerializeField] private List<CountryData> _data = new List<CountryData>();
    [SerializeField] private CardsService _cardService;
    [SerializeField] private SacrifaicesService _sacrifaicesService;
    [SerializeField] private SectariansService _sectariansService;
    [SerializeField] private PointsService _pointsService;
    [SerializeField] private TMP_Text _movesText;
    [SerializeField] private int _maxSacrifaicesForWin;

    private int _population;
    private int _currentMove;

    void Awake()
    {
        _cardService.OnChoiceCard += ChoiceCard;
        
        UpdateTextMoves();
        CalculatePopulation();

        _sacrifaicesService.SetInfo(_maxSacrifaicesForWin);
        _sectariansService.SetInfo(_population);
    }

    public void NextMove()
    {
        _currentMove++;
        _cardService.NextHand();
        _pointsService.ResetPoints();

        UpdateTextMoves();
    }

    private void CalculatePopulation()
    {
        foreach (var data in _data)
        {
            _population += data.Population;
        }
    }

    private void UpdateTextMoves()
    {
        _movesText.text = _currentMove.ToString();
    }
    
    private void ChoiceCard(CardData data)
    {
        _sacrifaicesService.SacrificesChange(data.Sacrifice);
        _sectariansService.SectariansChange(data.Secta);
        _pointsService.PointsChange(data.Points);
        //_sectariansService.SectariansChange(data.Inquisition);
    }
}
