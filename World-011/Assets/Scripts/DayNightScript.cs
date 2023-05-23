using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightScript : MonoBehaviour
{
    [SerializeField]
    private Material daySkybox;

    [SerializeField]
    private Material nightSkybox;

    private Light _sun;
    private Light _moon;

    private GameObject _lightElem;
    private GameObject _sunObj;
    private GameObject _moonObj;

    const float _fullDayTime = 30f;                     // Cекунд на суточный цикл
    const float _deltaAngel = -360 / _fullDayTime;       // Угол поворота света за 1 сек
    float _dayTime;                                     // Текущее время
    float _dayPhase;

    private AudioSource _daySound;
    private AudioSource _nightSound;

    void Start()
    {
        _sunObj = GameObject.Find("SunLight");
        _moonObj = GameObject.Find("MoonLight");

        _sun = GameObject.Find("SunLight").GetComponent<Light>();
        _moon = GameObject.Find("MoonLight").GetComponent<Light>();
        _lightElem = GameObject.Find("LightElem");

        AudioSource[] audioSources = this.GetComponents<AudioSource>();
        _daySound = audioSources[0];
        _nightSound = audioSources[1];
    }

    void LateUpdate()
    {
        _dayTime += Time.deltaTime;
        _dayTime %= _fullDayTime;
        _dayPhase = _dayTime / _fullDayTime;

        //_sun.transform.Rotate(_deltaAngel * Time.deltaTime, 0, 0);
        //_moon.transform.Rotate(_deltaAngel * Time.deltaTime, 0, 0);

        _lightElem.transform.Rotate(_deltaAngel * Time.deltaTime, 0, 0);

        float koef = Mathf.Abs(Mathf.Cos(_dayPhase * 2 * Mathf.PI));

        if(_dayPhase > 0.25f && _dayPhase < 0.75f)
        {
            if(!_nightSound.isPlaying)
            {
                _nightSound.Play();
                _daySound.Stop();
            }

            if(RenderSettings.skybox != nightSkybox)
            {
                RenderSettings.skybox = nightSkybox;
            }

            RenderSettings.ambientIntensity = koef / 2f;

            _sunObj.SetActive(false);
            _moonObj.SetActive(true);
        }
        else
        {
            if (!_daySound.isPlaying)
            {
                _daySound.Play();
                _nightSound.Stop();
            }

            if (RenderSettings.skybox != daySkybox)
            {
                RenderSettings.skybox = daySkybox;
            }

            RenderSettings.ambientIntensity = koef;

            _sunObj.SetActive(true);
            _moonObj.SetActive(false);
        }

        _daySound.mute = _nightSound.mute = GameSettings.IsMuted;
        _daySound.volume = _nightSound.volume = GameSettings.BackgroundVolum;

        RenderSettings.skybox.SetFloat("_Exposure", 0.1f + koef * 0.9f);
    }
}
