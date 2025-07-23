using UnityEngine;

public class InputReader : MonoBehaviour
{
    private bool _isJump;
    private bool _isShoot;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _isJump = true;
        if (Input.GetKeyDown(KeyCode.Mouse0))
            _isShoot = true;
    }

    public bool GetIsJump() => GetBoolAsTrigger(ref _isJump);
    public bool GetIsShot() => GetBoolAsTrigger(ref _isShoot);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
}