using UnityEngine;

public class EngineSpriteSwitcher : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _idle;
    [SerializeField] private Sprite _active;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float treshhold = 0.1f;

    private void Update()
    {
        bool isEngineActive = _rigidbody.linearVelocity.y > treshhold;

        _spriteRenderer.sprite = isEngineActive ? _active : _idle;
    }
}
