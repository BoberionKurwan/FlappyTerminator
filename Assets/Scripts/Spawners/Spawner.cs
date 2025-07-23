using UnityEngine;
using UnityEngine.Pool;

public class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;

    protected int DefaultCapacity = 3;
    protected int MaxCapacity = 10;

    protected ObjectPool<T> Pool;

    private void Awake()
    {
        Pool = new ObjectPool<T>(
            createFunc: Create,
            actionOnGet: Enable,
            actionOnRelease: Disable,
            actionOnDestroy: Destroy,
            collectionCheck: true,
            defaultCapacity: DefaultCapacity,
            maxSize: MaxCapacity);
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