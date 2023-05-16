using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayScript : MonoBehaviour
{
    [SerializeField]
    private GameObject character;

    [SerializeField]
    private GameObject coin;

    [SerializeField]
    private TMPro.TextMeshProUGUI textDistance;

    const float neutralDistance = 7f;

    void Start()
    {
        
    }


    void Update()
    {
        float distance = Vector3.Distance(character.transform.position, coin.transform.position);

        textDistance.text = distance.ToString("0.0");

        distance /= neutralDistance;

        textDistance.color = new Color(1 / (1 + distance), 0.2f, distance / (1 + distance));
    }
}
