using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private Animator _animator;

    const float minDistance = 10f;
    const float maxDistance = 21f;

    const int minDirection = 0;
    const int maxDirection = 4;

    enum Direction
    {
        Forward,
        Back,
        Left,
        Right
    }

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

        SpawnCoin();
        _animator.SetBool("isCollected", false);
    }

    private void SpawnCoin()
    {
        System.Random random = new System.Random();

        while (true)
        {
            random.Next();
            Direction direction = (Direction)random.Next(minDirection, maxDirection);

            float val = ((float)(random.NextDouble() * (maxDistance - minDistance) + minDistance));

            switch (direction)
            {
                case Direction.Forward:
                    {
                        Vector3 temp = this.transform.position + Vector3.forward * val;

                        if(temp.z < 965)
                        {
                            this.transform.position += Vector3.forward * val;
                            return;
                        }

                        break;
                    }

                case Direction.Back:
                    {
                        Vector3 temp = this.transform.position + Vector3.back * val;

                        if (temp.z > 30)
                        {
                            this.transform.position += Vector3.back * val;
                            return;
                        }

                        break;
                    }

                case Direction.Left:
                    {
                        Vector3 temp = this.transform.position + Vector3.left * val;

                        if (temp.x > 30)
                        {
                            this.transform.position += Vector3.left * val;
                            return;
                        }

                        break;
                    }

                case Direction.Right:
                    {
                        Vector3 temp = this.transform.position + Vector3.right * val;

                        if (temp.x < 960)
                        {
                            this.transform.position += Vector3.right * val;
                            return;
                        }

                        break;
                    }

            }
        }
    }
}
