using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField] 
    private GameObject _menuContent;

    void Start()
    {
        GameSettings.LoadSettings();
        GameObject.Find("MuteToggle").GetComponent<Toggle>().isOn = GameSettings.IsMuted;
        GameObject.Find("BgSlider").GetComponent<Slider>().value = GameSettings.BackgroundVolum;

        Time.timeScale = _menuContent.activeInHierarchy ? 0.0f : 1.0f;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Time.timeScale = _menuContent.activeInHierarchy ? 1.0f : 0.0f;
            _menuContent.SetActive(!_menuContent.activeInHierarchy);
        }
    }

    public void MuteChanged(bool state)
    {
        GameSettings.IsMuted = state;
    }

    public void BackgroundVolumChanged(Single value)
    {
        GameSettings.BackgroundVolum = value;
    }
}
