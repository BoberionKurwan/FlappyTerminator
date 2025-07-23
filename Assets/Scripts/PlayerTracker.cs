using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _xOffset = 0f;

    private float _initialY;

    private void Start()
    {
        _initialY = transform.position.y;
    }

    private void LateUpdate()
    {
        transform.position = new Vector2(_target.position.x + _xOffset, _initialY);
    }
}