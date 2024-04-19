using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpService : MonoBehaviour
{
    [SerializeField] private RectTransform _popupPrefab;
    [SerializeField] private Transform _map;
    [SerializeField] private float _cooldown;

    void Start()
    {
        StartCoroutine(Spawn());
    }


    IEnumerator Spawn()
    {
        var x = Random.Range(-920, 920);
        var y = Random.Range(-420, 420);
        var popup = Instantiate(_popupPrefab, new Vector3(0,0,0), Quaternion.identity);
        popup.parent = _map.transform;
        popup.anchoredPosition = new Vector2(x, y);
        yield return new WaitForSeconds(_cooldown);
        StartCoroutine(Spawn());
    }
}
