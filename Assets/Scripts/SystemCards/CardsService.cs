using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardsService : MonoBehaviour
{
    [SerializeField] private Transform m_container;
    [SerializeField] private CardView m_prefabCard;
    [SerializeField] private List<CardData> m_dataStartDeck = new List<CardData>();

    private Queue<CardData> m_dataDeck = new Queue<CardData>();
    private List<CardData> m_dataReset = new List<CardData>();
    private List<CardView> m_cards = new List<CardView>();

    private const int START_COUNT_CARDS_IN_HAND = 5;

    private void Awake()
    {
        m_dataStartDeck = Shuffle(m_dataStartDeck);
        
        foreach (var data in m_dataStartDeck)
        {
            m_dataDeck.Enqueue(data);
        }
    }

    private List<CardData> Shuffle(List<CardData> data)
    {
        return data.OrderBy(x => UnityEngine.Random.value).ToList();
    }

    [ContextMenu("NextHand")]
    public void NextHand()
    {
        ResetHand();
            
        for (int i = 0; i < START_COUNT_CARDS_IN_HAND; i++)
        {
            CheckNeedRefresh();

            if (m_dataDeck.Count == 0)
            {
                return;
            }
            
            GetCardView(i).SetInfo(m_dataDeck.Dequeue());
        }
    }

    private void CheckNeedRefresh()
    {
        if (m_dataDeck.Count != 0 || m_dataReset.Count == 0)
        {
            return;
        }
        
        m_dataReset = Shuffle(m_dataReset);

        foreach (var data in m_dataReset)
        {
            m_dataDeck.Enqueue(data);
        }
        
        m_dataReset.Clear();
        
        // размешать колоду
        // анимация перехода карт из сбора в колоду
    }
    
    private void ResetHand()
    {
        foreach (var card in m_cards)
        {
            if (card.IsActive)
            {
                m_dataReset.Add(card.CurrentData);
                card.Hide();
            }
        }
    }

    private CardView GetCardView(int index)
    {
        if (m_cards.Count <= index)
        {
            m_cards.Add(Instantiate(m_prefabCard, m_container));
        }
        
        return m_cards[index];
    }
}