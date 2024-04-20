using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SacrifaicesService : MonoBehaviour
{
    [SerializeField] private GameService _gameService;
    [SerializeField] private TMP_Text _sacrifacesTextNumber;

    private int _currentSacrifaices;
    private void Start()
    {
        _sacrifacesTextNumber.text = _currentSacrifaices.ToString() + "/" + _gameService.Population.ToString() + "M";
    }

    private void OnSacrifacesChanged()
    {

    }
}
