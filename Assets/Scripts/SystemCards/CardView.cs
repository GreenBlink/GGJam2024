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
    [SerializeField] private GameObject m_backCost;
    [SerializeField] private GameObject m_vfx;
    [SerializeField] private MagnifierView m_magnifier;
    [SerializeField] private CardDragView m_drag;
    [SerializeField] private CanvasGroup m_canvasGroup;
    [SerializeField] private LayoutElement m_elementLayout;
    [SerializeField] private bool m_anim;
    
    [SerializeField] private ModView m_sect;
    [SerializeField] private ModView m_inquisition;
    [SerializeField] private ModView m_sacrifice;
    [SerializeField] private ModView m_cost;
    [SerializeField] private ModView m_points;
    [SerializeField] private ModView m_removeCard;
    [SerializeField] private ModView m_chaos;
    [SerializeField] private ModView m_add;

    private Dictionary<CardType, Color> _colorData;

    private const int MAX_VALUE_Y_FOCUS = 80;
    private const float DURATION_ANIM_FOCUS = 0.5f;

    public CardData CurrentData { get; private set; }

    public event Action<CardView> OnChoiceCard;
    public event Action<CardView> OnClickCard;

    public void SetInfo(CardData data)
    {
        CurrentData = data;
        m_name.text = data.Name;
        m_background.sprite = data.Background;
        
        m_sect.SetInfo(data.Secta);
        m_sacrifice.SetInfo(data.Sacrifice);
        m_cost.SetInfo(data.Cost);
        m_points.SetInfo(data.Points);
        m_add.SetInfo(data.AddCard);
        m_removeCard.gameObject.SetActive(data.RemoveCard);
        m_backCost.SetActive(data.Cost != 0);

        if (data.Inquisition > 0)
        {
            m_inquisition.SetInfo(data.Inquisition);
            m_chaos.Hide();
        }
        else
        {
            m_chaos.SetInfo(-data.Inquisition);
            m_inquisition.Hide();
        }

        Colorist();
        Show();
    }
    
    public void SetBuyingState(bool isBuy)
    {
        m_buyingBlock.SetActive(isBuy);
        m_magnifier.SetActive(!isBuy);
    }

    public void ChoiceCard()
    {
        OnChoiceCard?.Invoke(this);
    }

    public void Show()
    {
        if (!m_anim)
        {
            gameObject.SetActive(true);
            m_rect.anchoredPosition = Vector2.zero;
            m_rect.localScale = Vector3.one;
            return;
        }
        
        gameObject.SetActive(true);
        m_elementLayout.ignoreLayout = false;
        m_canvasGroup.alpha = 0;
        
        SetVfxState(false);
        
        DOTween.Kill("Hide");
        m_rect.anchoredPosition = new Vector3(0, MAX_VALUE_Y_FOCUS);
        m_rect.localScale = Vector3.one;
        
        m_rect.DOAnchorPos(new Vector2(0,0), DURATION_ANIM_FOCUS).SetId("Move");
        m_canvasGroup.DOFade(1, DURATION_ANIM_FOCUS).OnComplete(ShowActivate);
        //анимация для появления из колоды
    }

    private void ShowActivate()
    {
        m_magnifier.enabled = true;
        
        if (m_drag)
        {
            m_drag.enabled = true;
        }
    }
    
    public void Hide()
    {
        CurrentData = null;
        
        if (!m_anim)
        {
            gameObject.SetActive(false);
            return;
        }
        
        m_magnifier.enabled = false;
        m_elementLayout.ignoreLayout = true;

        if (m_drag)
        {
            m_drag.enabled = false;
        }
        
        m_canvasGroup.DOFade(0f, 0.2f).OnComplete(() => { gameObject.SetActive(false); }).SetId("Hide");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClickCard?.Invoke(this);
    }
    
    public void SetVfxState(bool isActive)
    {
        m_vfx.SetActive(isActive);
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
