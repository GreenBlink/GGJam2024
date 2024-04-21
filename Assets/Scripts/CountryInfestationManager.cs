using Scripts.Countries;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountryInfestationManager : MonoBehaviour
{

    [SerializeField] private List<CountryData> _data = new List<CountryData>();
    [SerializeField] private SectariansService _sectariansService;
    [SerializeField] private List<Image> _countries;

    private void Awake()
    {
        foreach (var data in _data)
        {
             data.Sectarians = 0;
        }
        _sectariansService.OnSectariansChanged += PickRandomCountry;
    }
    private void OnDestroy()
    {
        _sectariansService.OnSectariansChanged -= PickRandomCountry;
    }
    private void PickRandomCountry(int value)
    {
        var id = Random.Range(0, _data.Count);
        if (_data[id].Sectarians < _data[id].Population)
        {
            _data[id].Sectarians += value;
            return;
        }
        if (_data[id].Sectarians == _data[id].Population)
        {
            foreach (var item in _data)
            {
                if (item.Sectarians < item.Population)
                {
                    item.Sectarians += value;
                    return;
                }
            }
        }
    }

    private void Update()
    {
        FillCountry();
    }
    private void FillCountry()
    {
        foreach(var country in _countries)
        {
            var sectarians = country.GetComponent<CountryStateManager>().CountryData.Sectarians;
            var population = country.GetComponent<CountryStateManager>().CountryData.Population;
            var percent = (float)sectarians / population;
           // country.fillAmount = Mathf.Lerp(country.fillAmount, percent, Time.deltaTime * 0.5f);
            Color c = country.color;
            c.a = Mathf.Lerp(c.a, percent, Time.deltaTime * 0.5f);
            country.color = c;
        }
    }
}
