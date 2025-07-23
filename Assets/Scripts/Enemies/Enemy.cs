using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy> ReturnToPool;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ReturnToPool?.Invoke(this);
    }
}
