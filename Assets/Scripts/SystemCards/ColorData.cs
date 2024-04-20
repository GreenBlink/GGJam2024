using UnityEngine;

[CreateAssetMenu(fileName = "ColorData", menuName = "Data/ColorData")]
public class ColorData : ScriptableObject
{
    [SerializeField] private Color _colorCommon;
    [SerializeField] private Color _colorChaos;
    [SerializeField] private Color _colorNeutral;
    [SerializeField] private Color _colorInquisition;
    
    public Color ColorCommon => _colorCommon;

    public Color ColorChaos => _colorChaos;

    public Color ColorNeutral => _colorNeutral;

    public Color ColorInquisition => _colorInquisition;
}