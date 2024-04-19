using System.Collections.Generic;
using UnityEngine;

public class CardFan : MonoBehaviour
{
    public GameObject poolObject;
    public int numberOfCards = 5;
    public float fanAngle = 30f;
    public float radius = 2f;

    void Start()
    {
        if (poolObject == null)
        {
            Debug.LogError("Pool object is not assigned!");
            return;
        }

        for (int i = 0; i < numberOfCards; i++)
        {
            float angle = i * fanAngle - ((numberOfCards - 1) * fanAngle / 2f);
            float x = radius * Mathf.Sin(Mathf.Deg2Rad * angle);
            float y = radius * Mathf.Cos(Mathf.Deg2Rad * angle);

            GameObject card = poolObject.transform.GetChild(i).gameObject;
            if (card != null)
            {
                GameObject instantiatedCard = Instantiate(card, new Vector3(x, y, 0f), Quaternion.identity);
                instantiatedCard.transform.SetParent(transform);
            }
            else
            {
                Debug.LogError("CardPrefab" + i + " not found in the pool!");
            }
        }
    }
}
