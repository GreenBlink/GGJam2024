using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWindow : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    public void OpenWindow()
    {
        _canvas.gameObject.SetActive(true);
    }
    public void CloseWindow()
    {
        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.1f);
        _canvas.gameObject.SetActive(false);
    }
}
