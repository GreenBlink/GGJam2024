using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class CardsService : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_countDeck;
    [SerializeField] private TextMeshProUGUI m_countReset;
    [SerializeField] private Transform m_container;
    [SerializeField] private CardView m_prefabCard;
    [SerializeField] private List<CardData> m_dataStartDeck = new List<CardData>();
    [SerializeField] private CardData m_dataAddCardInReset;
    
    private Queue<CardData> m_dataDeck = new Queue<CardData>();
    private List<CardData> m_dataReset = new List<CardData>();
    private List<CardView> m_cards = new List<CardView>();

    private const int START_COUNT_CARDS_IN_HAND = 5;

    public event Action<CardData> OnChoiceCard;

    private void Awake()
    {
        m_dataStartDeck = Shuffle(m_dataStartDeck);
        
        foreach (var data in m_dataStartDeck)
        {
            m_dataDeck.Enqueue(data);
        }

        UpdateCountDeck();
        UpdateCountReset();
    }

    [ContextMenu("AddCard")]
    public void AddCard()
    {
        if (m_dataAddCardInReset == null)
        {
            Debug.LogError("Нужно добавить данные в CardsService.DataAddCardInReset!");
            return;
        }
        
        AddCard(m_dataAddCardInReset);
    }
    
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

        UpdateCountDeck();
    }

    public void AddCard(CardData data)
    {
        m_dataReset.Add(data);
        UpdateCountReset();
    }

    public void RemoveCard()
    {
        
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
        UpdateCountDeck();
        UpdateCountReset();

        // размешать колоду
        // анимация перехода карт из сбора в колоду
    }
    
    private void ResetHand()
    {
        foreach (var card in m_cards)
        {
            if (card.IsActive)
            {
                CardToReset(card);
            }
        }
    }

    private CardView GetCardView(int index)
    {
        if (m_cards.Count <= index)
        {
            m_cards.Add(Instantiate(m_prefabCard, m_container));
            m_cards[index].ChoiceCard += ChoiceCard;
        }
        
        return m_cards[index];
    }
    
    private void UpdateCountDeck()
    {
        m_countDeck.text = m_dataDeck.Count.ToString();
    }
    
    private void UpdateCountReset()
    {
        m_countReset.text = m_dataReset.Count.ToString();
    }

    private void ChoiceCard(CardView card)
    {
        OnChoiceCard?.Invoke(card.CurrentData);
        CardToReset(card);
    }

    private void CardToReset(CardView card)
    {
        m_dataReset.Add(card.CurrentData);
        card.Hide();
        
        UpdateCountReset();
    }
    
    private List<CardData> Shuffle(List<CardData> data)
    {
        return data.OrderBy(x => UnityEngine.Random.value).ToList();
    }
}