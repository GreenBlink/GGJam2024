using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Data/CardData")]
public class CardData : ScriptableObject
{
    [SerializeField] private CardType m_type;
    [SerializeField] private Sprite m_background;
    [SerializeField] private string m_name;
    [SerializeField] private int m_cost;
    [SerializeField] private int m_points;
    [SerializeField] private int m_secta;
    [SerializeField] private int m_inquisition;
    [SerializeField] private int m_sacrifice;
    [SerializeField] private int m_addCard;
    [SerializeField] private bool m_removeCard;
    
    public CardType Type => m_type;
    public Sprite Background => m_background;
    public string Name => m_name;
    public int Cost => m_cost;
    public int Points => m_points;
    public int Secta => m_secta;
    public int Inquisition => m_inquisition;
    public int Sacrifice => m_sacrifice;
    public int AddCard => m_addCard;
    public bool RemoveCard => m_removeCard;
}