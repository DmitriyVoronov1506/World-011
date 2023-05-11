using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class CameraScript : MonoBehaviour
{
    private GameObject _character;  // Ссылка на персонажа
    private Vector3 _offset;        // Смещение камеры и персонажа
    private float _angelX;          // Накопленный угол поворота камеры по X
    private float _angelY;          // Накопленный угол поворота камеры по Y
    private float _sensX = 150;
    private float _sensY = 100;

    void Start()
    {
        _character = GameObject.Find("Character");
        _offset = this.transform.position - _character.transform.position;
        _angelX = 0;
        _angelY = this.transform.eulerAngles.x;
    }

    private void Update()
    {
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        _angelX += mx * Time.deltaTime * _sensX;
        _angelY -= my * Time.deltaTime * _sensY;     // -= для инверсии  
    }

    void LateUpdate()
    {
        this.transform.position = _character.transform.position +  Quaternion.Euler(0, _angelX, 0) * _offset;
        this.transform.eulerAngles = new Vector3(_angelY, _angelX, 0);

        if(!Input.GetMouseButton(0))
        {
            // Вращаем персонажа по камере, если не зажата ЛКМ

            _character.transform.eulerAngles = new Vector3(0, _angelX, 0);
        }
    }
}
