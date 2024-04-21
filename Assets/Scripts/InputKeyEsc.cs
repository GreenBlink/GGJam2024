using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKeyEsc : MonoBehaviour
{
    [SerializeField] private GameObject _windowShop;
    [SerializeField] private GameObject _windowCards;
    [SerializeField] private GameObject _windowMenu;
    [SerializeField] private GameObject _windowRules;
    [SerializeField] private GameObject _windowWin;
    [SerializeField] private GameObject _windowLoose;
    
    [SerializeField] private GameService _gameService;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _gameService.NextMove();
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_windowShop.gameObject.activeInHierarchy)
            {
                _windowShop.gameObject.SetActive(false);
                return;
            }
            
            if (_windowCards.gameObject.activeInHierarchy)
            {
                _windowCards.gameObject.SetActive(false);
                return;
            }
            
            if (_windowMenu.gameObject.activeInHierarchy)
            {
                _windowMenu.gameObject.SetActive(false);
                return;
            }
            
            if (_windowRules.gameObject.activeInHierarchy)
            {
                _windowRules.gameObject.SetActive(false);
                return;
            }
            
            if (_windowWin.gameObject.activeInHierarchy || _windowLoose.gameObject.activeInHierarchy)
            {
                return;
            }
            
            _windowMenu.gameObject.SetActive(true);
        }
    }
}
