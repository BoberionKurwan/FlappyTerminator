using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Mover), typeof(InputReader), typeof(CapsuleCollider2D))]
[RequireComponent(typeof(BulletSpawner))]
public class Player : MonoBehaviour
{
    private Mover _mover;
    private InputReader _inputReader;
    private BulletSpawner _bulletSpawner;
    private CapsuleCollider2D _capsuleCollider;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _inputReader = GetComponent<InputReader>();
        _bulletSpawner = GetComponent<BulletSpawner>();
        _capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    private void FixedUpdate()
    {
        if (_inputReader.GetIsJump())
            _mover.Jump();

        if (_inputReader.GetIsShot())
            _bulletSpawner.Spawn();
    }

    private void OnTriggerEnter2D()
    {
        ReloadScene();
    }

    private void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
