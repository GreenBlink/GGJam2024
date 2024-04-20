using System;
using System.Collections.Generic;
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
    [SerializeField] private ColorData m_dataColor;
    [SerializeField] private List<MaskableGraphic> m_objectsColorist;
    
    [SerializeField] private ModView m_sect;
    [SerializeField] private ModView m_inquisition;
    [SerializeField] private ModView m_sacrifice;
    [SerializeField] private ModView m_cost;
    [SerializeField] private ModView m_points;

    private Dictionary<CardType, Color> _colorData;

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
        
        m_sect.SetInfo(data.Secta);
        m_inquisition.SetInfo(data.Inquisition);
        m_sacrifice.SetInfo(data.Sacrifice);
        m_cost.SetInfo(data.Cost);
        m_points.SetInfo(data.Points);

        Colorist();
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
    
    private void Colorist()
    {
        _colorData ??= new Dictionary<CardType, Color>
        {
            { CardType.None, m_dataColor.ColorCommon },
            { CardType.Chaos, m_dataColor.ColorChaos },
            { CardType.Neutral, m_dataColor.ColorNeutral },
            { CardType.Inquisition, m_dataColor.ColorInquisition },
        };
        
        foreach (var obj in m_objectsColorist)
        {
            obj.color = _colorData[CurrentData.Type];
        }
    }

}
