using TMPro;
using UnityEngine;

public class PointsService : MonoBehaviour
{
    [SerializeField] private TMP_Text _pointsText;
    
    private int _currentPoints;
    
    public void PointsChange(int value)
    {
        _currentPoints += value;

        UpdateText();
    }

    public void ResetPoints()
    {
        _currentPoints = 0;
        
        UpdateText();
    }
    
    private void UpdateText()
    {
        _pointsText.text = _currentPoints.ToString();
    }
}