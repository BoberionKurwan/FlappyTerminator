using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour 
{
    private Collider2D _collider;

    public event Action<Bullet> ReturnToPool;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ReturnToPool?.Invoke(this);
    }
}