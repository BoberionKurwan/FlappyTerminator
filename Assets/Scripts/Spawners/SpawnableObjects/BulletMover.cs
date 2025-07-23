using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletMover : MonoBehaviour 
{
    [SerializeField] private float _speed;
    
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody.linearVelocity = new Vector2(_speed, 0);
    }
}
