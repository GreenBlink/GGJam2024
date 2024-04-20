using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SectariansService : MonoBehaviour
{
    [SerializeField] private GameService _gameService;
    [SerializeField] private TMP_Text _sectariansTextNumber;

    private int _currentSectarians;
    private void Start()
    {
        _sectariansTextNumber.text = _currentSectarians.ToString() + "/" + _gameService.Population.ToString() + "M";
    }

    private void OnSectariansChanged()
    {

    }
}
