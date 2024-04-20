using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardView : MonoBehaviour, IPointerClickHandler
{ 
    [SerializeField] private RectTransform m_rect;
    [SerializeField] private Image m_background;
    [SerializeField] private TextMeshProUGUI m_name;
    [SerializeField] private GameObject m_buyingBlock;
    
    [SerializeField] private TextMeshProUGUI m_sect;
    [SerializeField] private TextMeshProUGUI m_inquisition;
    [SerializeField] private TextMeshProUGUI m_sacrifice;
    [SerializeField] private TextMeshProUGUI m_cost;
    [SerializeField] private TextMeshProUGUI m_points;

    private const int MAX_VALUE_Y_FOCUS = 80;
    private const float DURATION_ANIM_FOCUS = 0.5f;

    public CardData CurrentData { get; private set; }
    public bool IsActive => gameObject.activeInHierarchy;

    public event Action<CardView> OnChoiceCard;
    public event Action<CardView> OnClickCard;

    public void SetInfo(CardData data)
    {
        CurrentData = data;
        m_name.text = data.Name;
        m_background.sprite = data.Background;

        m_sect.text = data.Secta.ToString();
        m_inquisition.text = data.Inquisition.ToString();
        m_sacrifice.text = data.Sacrifice.ToString();
        m_cost.text = data.Cost.ToString();
        m_points.text = data.Points.ToString();

        Show();
    }

    public void SetBuyingState(bool isBuy)
    {
        m_buyingBlock.SetActive(isBuy);
    }

    public void ChoiceCard()
    {
        OnChoiceCard?.Invoke(this);
    }

    public void Show()
    {
        m_rect.anchoredPosition = Vector2.zero;
        m_rect.localScale = Vector3.one;
        
        gameObject.SetActive(true);
        //анимация для появления из колоды
    }

    public void Hide()
    {
        CurrentData = null;
        gameObject.SetActive(false);
        //анимация для ухода в сброс
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClickCard?.Invoke(this);
    }
}
