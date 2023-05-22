using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    [SerializeField] 
    private GameObject _menuContent;

    void Start()
    {
        Time.timeScale = 0.0f;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Time.timeScale = _menuContent.activeInHierarchy ? 1.0f : 0.0f;
            _menuContent.SetActive(!_menuContent.activeInHierarchy);
        }
    }
}
