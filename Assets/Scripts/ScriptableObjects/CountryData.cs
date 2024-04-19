using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "CountryData", order = 51)]
public class CountryData : ScriptableObject
{
    public string CountryName;

    public int Sacrifices;
    public int Sectarians;
    public int Population;
}