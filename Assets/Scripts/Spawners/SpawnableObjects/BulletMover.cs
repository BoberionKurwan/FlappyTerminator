using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletMover<T> : MonoBehaviour where T : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    protected float _speed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody.linearVelocity = new Vector2(_speed, 0);
    }
}
