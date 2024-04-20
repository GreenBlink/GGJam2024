using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShowAllCards : MonoBehaviour
{
    [SerializeField] private CardsDatabase _deck;
    [SerializeField] private CardView m_prefabCard;
    [SerializeField] private Transform m_container;
    [SerializeField] private List<CardData> m_starterCards = new List<CardData>();

    private List<CardView> m_cards = new List<CardView>();
    private bool m_isInitiate = false;

    private void OnDisable()
    {
        foreach (var card in m_cards)
        {
            card.gameObject.SetActive(false);
        }
    }

    public void ShowAllCard()
    {
        gameObject.SetActive(true);
        
        if (!m_isInitiate)
        {
            var distinctCards = _deck.Cards.Distinct().ToList();
            foreach (var card in m_starterCards)
            {
                distinctCards.Add(card);
            }

            var sortedCards = distinctCards.OrderBy(x => x.Type);
            foreach (var card in sortedCards)
            {
                var temp = Instantiate(m_prefabCard, m_container);
                temp.SetInfo(card);
                m_cards.Add(temp);
            }

            m_isInitiate = true;
            return;
        }
        
        foreach (var card in m_cards)
        {
            card.gameObject.SetActive(true);
        }
    }
}
