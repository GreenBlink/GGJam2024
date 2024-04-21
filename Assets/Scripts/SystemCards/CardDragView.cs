using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardDragView : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    [SerializeField] private RectTransform m_rect;
    [SerializeField] private CardView m_card;
    
    private Vector3 m_startDragMousePosition;
    
    private const int POSITION = 200;
    private const float DURATION_ANIM_FOCUS = 0.5f;

    public void OnBeginDrag(PointerEventData eventData)
    {
        DOTween.Kill("Move");
        m_startDragMousePosition = (Vector2) m_rect.position - eventData.position;
        m_startDragMousePosition.z = 0;
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePosition = eventData.position;
        mousePosition.z = 0f;

        m_card.SetVfxState(m_rect.anchoredPosition.y > POSITION);
        m_rect.position = mousePosition + m_startDragMousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (m_rect.anchoredPosition.y > POSITION)
        {
            m_card.ChoiceCard();
            return;
        }
        
        m_rect.DOAnchorPos(Vector2.zero, DURATION_ANIM_FOCUS).SetId("Move");
    }
}