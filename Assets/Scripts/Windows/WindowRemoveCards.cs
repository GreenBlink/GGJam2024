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

    private void OnDisable()
    {
        for (int i = 0; i < m_cards.Count; i++)
        {
            m_cards[i].Hide();
        }
    }

    public void Show(List<CardData> dataDeck, List<CardData> dataReset)
    {
        gameObject.SetActive(true);

        int index = 0;
        for (int i = 0; i < dataDeck.Count; i++)
        {
            GetCardView(index).SetInfo(dataDeck[i]);
            index++;
        }
        
        for (int j = 0; j < dataReset.Count; j++)
        {
            GetCardView(index).SetInfo(dataReset[j]);
            index++;
        }

        for (; index < m_cards.Count; index++)
        {
            m_cards[index].Hide();
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
