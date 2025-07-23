using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _xOffset = 0f;

    private float _initialY;
    private float _initialZ;

    private void Start()
    {
        _initialY = transform.position.y;
        _initialZ = transform.position.z;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(
            _target.position.x + _xOffset,
            _initialY,
            _initialZ
        );
    }
}