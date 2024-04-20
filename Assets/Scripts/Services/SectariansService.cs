using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SectariansService : MonoBehaviour
{
    [SerializeField] private TMP_Text _sectariansTextNumber;
    [SerializeField] private GameObject _winWindowBySectarians;

    public int CurrentSectarians => _currentSectarians;

    private int _maxSectarians;
    private int _currentSectarians;

    public event Action<int> OnSectariansChanged;

    public void SetInfo(int population)
    {
        _maxSectarians = population;
        
        UpdateTextSectarians();
    }

    public void SectariansChange(int value)
    {
        _currentSectarians += value;
        OnSectariansChanged?.Invoke(value);
        UpdateTextSectarians();

        if (_currentSectarians >= _maxSectarians)
        {
            WinBySect();
        }
    }

    private void UpdateTextSectarians()
    {
        _sectariansTextNumber.text = _currentSectarians + "/" + _maxSectarians + "M";
    }

    private void WinBySect()
    {
        _winWindowBySectarians.SetActive(true);
    }
}
