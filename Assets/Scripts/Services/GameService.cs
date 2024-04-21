using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameService : MonoBehaviour
{
    [SerializeField] private List<CountryData> _data = new List<CountryData>();
    [SerializeField] private CardsService _cardService;
    [SerializeField] private SacrifaicesService _sacrifaicesService;
    [SerializeField] private SectariansService _sectariansService;
    [SerializeField] private InqusitionService _inqusitionService;
    [SerializeField] private ShopService _shopService;
    [SerializeField] private PointsService _pointsService;
    [SerializeField] private RemoveCardService _removeCardService;
    [SerializeField] private TMP_Text _movesText;
    [SerializeField] private int _maxSacrifaicesForWin;
    [SerializeField] private int _PercentPerDay;

    private int _population;
    private int _currentMove;

    void Awake()
    {
        _cardService.OnChoiceCard += ChoiceCard;
        
        UpdateTextMoves();
        CalculatePopulation();

        _sacrifaicesService.SetInfo(_maxSacrifaicesForWin);
        _sectariansService.SetInfo(_population);
        _inqusitionService.SetInfo(0);
    }

    private void Start()
    {
        NextMove();
    }

    public void NextMove()
    {
        _currentMove++;
        Debug.Log(_currentMove +": ����� ����");
        _cardService.NextHand();
        _pointsService.ResetPoints();
        _shopService.SetNewOrder();
        _inqusitionService.PercentChange(_PercentPerDay);
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
        _inqusitionService.PercentChange(data.Inquisition);

        if (data.RemoveCard)
        {
            _removeCardService.OpenRemoveCard(_cardService.DataDeck, _cardService.DataReset);
        }

        if (data.AddCard > 0 && _cardService.IsExistTypeCardInHand(data.Type))
        {
            _cardService.GetCardInDeck(data.AddCard);
        }
        
        Debug.Log(data.Name + " ��� ��������� �����");
        Debug.Log(data.Secta + "+ ��������� � �����");
        Debug.Log(data.Points + " ��������� � �������");
        Debug.Log(data.Inquisition + " ��������� � ����������");
    }
}
