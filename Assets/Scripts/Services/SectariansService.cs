using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SectariansService : MonoBehaviour
{
    [SerializeField] private TMP_Text _sectariansTextNumber;
    [SerializeField] private GameObject _winWindowBySectarians;
    [SerializeField] private Image _sectariansBar;
    [SerializeField] private AudioSource _winAudioSource;
    public int CurrentSectarians => _currentSectarians;

    private int _maxSectarians;
    private int _currentSectarians;

    public event Action<int> OnSectariansChanged;

    public void SetInfo(int population)
    {
        _maxSectarians = population;
        
        UpdateTextSectarians();
    }

    private void Awake()
    {
        _sectariansBar.fillAmount = 0;
    }

    private void Update()
    {
        var sectarians = _currentSectarians;
        var population = _maxSectarians;
        var percent = (float)sectarians / population;
        _sectariansBar.DOFillAmount(percent, 1f);
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
        _sectariansTextNumber.text = _currentSectarians + " / " + _maxSectarians;
    }

    private void WinBySect()
    {
        _winWindowBySectarians.SetActive(true);
        _winAudioSource.Play();
    }
}
