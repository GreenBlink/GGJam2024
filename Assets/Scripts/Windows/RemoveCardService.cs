using System.Collections.Generic;
using UnityEngine;

public class RemoveCardService : MonoBehaviour
{
    [SerializeField] private CardsService _cardsService;
    [SerializeField] private WindowRemoveCards _window;

    private void Awake()
    {
        _window.OnRemoveCard += _cardsService.RemoveCard;
    }

    public void OpenRemoveCard(List<CardData> data)
    {
        _window.Show(data);
    }
}