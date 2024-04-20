using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SectariansService : MonoBehaviour
{
    [SerializeField] private TMP_Text _sectariansTextNumber;

    private int _maxSectarians;
    private int _currentSectarians;

    public void SetInfo(int population)
    {
        _maxSectarians = population;
        
        UpdateTextSectarians();
    }

    public void SectariansChange(int value)
    {
        _currentSectarians += value;

        UpdateTextSectarians();
    }

    private void UpdateTextSectarians()
    {
        _sectariansTextNumber.text = _currentSectarians + "/" + _maxSectarians + "M";
    }
}
