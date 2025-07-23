using UnityEngine;
using UnityEngine.Pool;

public class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;

    protected int defaultCapacity = 3;
    protected int maxCapacity = 10;

    protected ObjectPool<T> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<T>(
            createFunc: Create,
            actionOnGet: Enable,
            actionOnRelease: Disable,
            actionOnDestroy: Destroy,
            collectionCheck: true,
            defaultCapacity: defaultCapacity,
            maxSize: maxCapacity);
    }

    private T Create()
    {
        T obj = Instantiate(_prefab);
        return obj;
    }

    private void Enable(T obj)
    {
        obj.gameObject.SetActive(true);
    }

    private void Disable(T obj)
    {
        obj.gameObject.SetActive(false);
    }

    private void Destroy(T obj)
    {
        Destroy(obj.gameObject);
    }
}