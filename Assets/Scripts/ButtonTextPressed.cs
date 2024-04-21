using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonTextPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private RectTransform m_text;
    [SerializeField] private Button m_btn;
    

    public void OnPointerUp(PointerEventData eventData)
    {
        m_text.anchoredPosition = new Vector2(0, 0);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        m_text.anchoredPosition = new Vector2(0, -8);
    }
}
