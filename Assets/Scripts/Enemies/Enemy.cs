using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy> ReturnToPool;

    private void OnTriggerEnter2D()
    {
        ReturnToPool?.Invoke(this);
    }
}
