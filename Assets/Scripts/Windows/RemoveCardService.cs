using System.Collections.Generic;
using UnityEngine;

public class RemoveCardService : MonoBehaviour
{
    [SerializeField] private CardsService _cardsService;
    [SerializeField] private WindowRemoveCards _window;

    private void Awake()
    {
        _window.OnRemoveCard += _cardsService.RemoveCardAndRefresh;
    }

    public void OpenRemoveCard(List<CardData> dataDeck, List<CardData> dataReset)
    {
        _window.Show(dataDeck, dataReset);
    }
}