using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// public class CardClickView : MonoBehaviour, IPointerClickHandler
// {
//     
// }

public class CardView : MonoBehaviour, IPointerClickHandler, IDragHandler, IEndDragHandler, IBeginDragHandler
{ 
    [SerializeField] private RectTransform m_rect;
    [SerializeField] private Image m_background;
    [SerializeField] private TextMeshProUGUI m_name;
    [SerializeField] private GameObject m_buyingBlock;
    [SerializeField] private bool m_isSystemDrag = true;
    
    [SerializeField] private TextMeshProUGUI m_sect;
    [SerializeField] private TextMeshProUGUI m_inquisition;
    [SerializeField] private TextMeshProUGUI m_sacrifice;
    [SerializeField] private TextMeshProUGUI m_cost;
    [SerializeField] private TextMeshProUGUI m_points;

    private Vector3 m_startDragMousePosition;

    private const int MAX_VALUE_Y_FOCUS = 80;
    private const float DURATION_ANIM_FOCUS = 0.5f;

    public CardData CurrentData { get; private set; }
    public bool IsActive => gameObject.activeInHierarchy;

    public event Action<CardView> ChoiceCard;
    public event Action<CardView> ClickCard;

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
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!m_isSystemDrag)
        {
            return;
        }
        
        DOTween.Kill("Move");
        m_startDragMousePosition = (Vector2) m_rect.position - eventData.position;
        m_startDragMousePosition.z = 0;
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        if (!m_isSystemDrag)
        {
            return;
        }
        
        Vector3 mousePosition = eventData.position;
        mousePosition.z = 0f;
        
        m_rect.position = mousePosition + m_startDragMousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!m_isSystemDrag)
        {
            return;
        }
        
        if (m_rect.anchoredPosition.y > 300)
        {
            ChoiceCard?.Invoke(this);
            return;
        }
        
        m_rect.DOAnchorPos(Vector2.zero, DURATION_ANIM_FOCUS).SetId("Move");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ClickCard?.Invoke(this);
    }
}
