using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "CountryData", order = 51)]
public class CountryData : ScriptableObject
{
    public string CountryName;

    public int Population;
}