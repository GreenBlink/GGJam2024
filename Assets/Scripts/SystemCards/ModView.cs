using TMPro;
using UnityEngine;

public class ModView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_text;

    public void SetInfo(int value)
    {
        if (value == 0)
        {
            gameObject.SetActive(false);
            return;
        }
        
        gameObject.SetActive(true);
        m_text.text = value.ToString();
    }
}