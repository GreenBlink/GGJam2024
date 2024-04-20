using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "CardsData", order = 51)]
public class CardsDatabase : ScriptableObject
{
    [SerializeField] private List<CardData> m_cards;

    public List<CardData> Cards => m_cards;
}