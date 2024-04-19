using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{ 
    [SerializeField] private RectTransform m_rect;
    [SerializeField] private Image m_background;

    private const int MAX_VALUE_Y_FOCUS = 80;
    private const float DURATION_ANIM_FOCUS = 0.5f;
    private const float SCALE_FOCUS = 1.2f;

    public CardData CurrentData { get; private set; }
    public bool IsActive => gameObject.activeInHierarchy;

    public void SetInfo(CardData data)
    {
        CurrentData = data;
        m_background.sprite = data.Background;

        Show();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        //анимация для появления из колоды
    }

    public void Hide()
    {
        CurrentData = null;
        gameObject.SetActive(false);
        //анимация для ухода в сброс
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        m_rect.DOAnchorPosY(MAX_VALUE_Y_FOCUS, DURATION_ANIM_FOCUS);
        m_rect.DOScale(SCALE_FOCUS, DURATION_ANIM_FOCUS);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_rect.DOAnchorPosY(0, DURATION_ANIM_FOCUS);
        m_rect.DOScale(1, DURATION_ANIM_FOCUS);
    }
}
