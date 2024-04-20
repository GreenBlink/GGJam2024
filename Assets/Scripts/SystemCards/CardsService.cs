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
    
    private Queue<CardData> m_dataDeck = new Queue<CardData>();
    private List<CardData> m_dataReset = new List<CardData>();
    private List<CardView> m_cardsPool = new List<CardView>();
    private List<CardView> m_cardsInHand = new List<CardView>();

    private const int START_COUNT_CARDS_IN_HAND = 5;

    public List<CardData> DataReset => m_dataReset;
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
    
    public void NextHand()
    {
        ResetHand();
        GetCardInDeck(START_COUNT_CARDS_IN_HAND);
    }

    public void AddCard(CardData data)
    {
        m_dataReset.Add(data);
        UpdateCountReset();
    }

    public void GetCardInDeck(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GetCardInDeck();
        }
    }

    public void RemoveCard(CardData data)
    {
        m_dataReset.Remove(data);
        UpdateCountReset();
    }
    
    public bool IsExistTypeCardInHand(CardType cardType)
    {
        return m_cardsInHand.Exists(x => x.CurrentData.Type == cardType);
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
        for (int i = m_cardsInHand.Count - 1; i >= 0; i--)
        {
            CardToReset(m_cardsInHand[i]);
        }
    }

    private CardView GetCardView(int index)
    {
        if (m_cardsPool.Count <= index)
        {
            m_cardsPool.Add(Instantiate(m_prefabCard, m_container));
            m_cardsPool[index].OnChoiceCard += ChoiceCard;
        }
        
        return m_cardsPool[index];
    }
    
    private void GetCardInDeck()
    {
        CheckNeedRefresh();

        if (m_dataDeck.Count == 0)
        {
            return;
        }
            
        CardView cardView = GetCardView(m_cardsInHand.Count);
        cardView.SetInfo(m_dataDeck.Dequeue());
        m_cardsInHand.Add(cardView);
        
        UpdateCountDeck();
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
        m_cardsInHand.Remove(card);
        m_dataReset.Add(card.CurrentData);
        card.Hide();
        
        UpdateCountReset();
    }
    
    private List<CardData> Shuffle(List<CardData> data)
    {
        return data.OrderBy(x => UnityEngine.Random.value).ToList();
    }
}