using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowRemoveCards : MonoBehaviour
{
    [SerializeField] private CardView _cardPrefab;
    [SerializeField] private Transform _container;

    private List<CardView> m_cards = new List<CardView>();
    
    public event Action<CardData> OnRemoveCard;

    public void Show(List<CardData> cardData)
    {
        gameObject.SetActive(true);

        int i = 0;
        for (; i < cardData.Count; i++)
        {
            GetCardView(i).SetInfo(cardData[i]);
        }

        for (; i < m_cards.Count; i++)
        {
            m_cards[i].Hide();
        }
    }

    private void RemoveCard(CardView card)
    {
        OnRemoveCard?.Invoke(card.CurrentData);
        gameObject.SetActive(false);
    }

    private CardView GetCardView(int index)
    {
        if (m_cards.Count <= index)
        {
            m_cards.Add(Instantiate(_cardPrefab, _container));
            m_cards[index].OnClickCard += RemoveCard;
        }
        
        return m_cards[index];
    }
}
