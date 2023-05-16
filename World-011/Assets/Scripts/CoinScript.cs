using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Collector"))
        {
            _animator.SetBool("isCollected", true);
        }
    }

    public void Disapeared()
    {
        //Debug.Log("Disapeared");

        this.transform.position += Vector3.forward * 10;
        _animator.SetBool("isCollected", false);
    }
}
