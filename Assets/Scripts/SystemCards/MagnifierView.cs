using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class MagnifierView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private RectTransform m_rect;

    private bool _isActive = true;
    
    private const float DURATION_ANIM_FOCUS = 0.5f;
    private const float SCALE_FOCUS = 1.2f;

    public void SetActive(bool isActive)
    {
        _isActive = isActive;

        if (!_isActive)
        {
            m_rect.DOScale(1, DURATION_ANIM_FOCUS);
        }
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!_isActive)
        {
            return;
        }
        
        m_rect.DOScale(SCALE_FOCUS, DURATION_ANIM_FOCUS);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_rect.DOScale(1, DURATION_ANIM_FOCUS);
    }
}