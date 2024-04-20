using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WindowShop : MonoBehaviour
{
    [SerializeField] private List<CardView> _cards;
    [SerializeField] private TextMeshProUGUI _points;

    private List<CardData> m_data;

    public event Action<CardData> OnBuyCard;

    private void Awake()
    {
        for (int i = 0; i < _cards.Count; i++)
        {
            _cards[i].ClickCard += BuyCard;
        }
    }

    public void Show(int points, List<CardData> data, List<bool> isBuyCards)
    {
        _points.text = points.ToString();

        int i = 0;
        for (; i < _cards.Count && i < data.Count; i++)
        {
            _cards[i].SetInfo(data[i]);
            _cards[i].SetBuyingState(isBuyCards[i]);
        }

        for (;i < _cards.Count; i++)
        {
            _cards[i].Hide();
        }
        
        gameObject.SetActive(true);
    }

    private void BuyCard(CardView card)
    {
        OnBuyCard?.Invoke(card.CurrentData);
    }
}