using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShopService : MonoBehaviour
{
    [SerializeField] private List<CardData> _data = new List<CardData>();
    [SerializeField] private PointsService _pointsService;
    [SerializeField] private CardsService _cardsService;
    [SerializeField] private WindowShop _windowShop;
    
    private List<CardData> _availableCards = new List<CardData>(COUNT_BUY_CARD);
    private List<bool> _buyCards = new List<bool>(COUNT_BUY_CARD);
    
    private const int COUNT_BUY_CARD = 3;

    private void Awake()
    {
        _windowShop.OnBuyCard += BuyCard;

        for (int i = 0; i < COUNT_BUY_CARD; i++)
        {
            _buyCards.Add(false);
        }
    }

    public void OpenShop()
    {
        _windowShop.Show(_pointsService.CurrentPoints, _availableCards, _buyCards);
    }

    public void SetNewOrder()
    {
        for (int i = 0; i < _availableCards.Count; i++)
        {
            if (!_buyCards[i])
            {
                _data.Add(_availableCards[i]);
            }

            _buyCards[i] = false;
        }
       
        _availableCards.Clear();

        for (int i = 0; i < COUNT_BUY_CARD && _data.Count != 0; i++)
        {
            _availableCards.Add(GetRandomCard());
        }
    }

    private void BuyCard(CardData cardData, int index)
    {
        if (cardData.Cost > _pointsService.CurrentPoints || _buyCards[index])
        {
            return;
        }
        
        _buyCards[index] = true;
        _cardsService.AddCard(cardData);
        _pointsService.PointsChange(-cardData.Cost);

        OpenShop();
    }

    private CardData GetRandomCard()
    {
        CardData cardData = _data[Random.Range(0, _data.Count)];
        _data.Remove(cardData);
        
        return cardData;
    }
}